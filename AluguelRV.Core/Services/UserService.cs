using AluguelRV.Core.Data.DbAccess;
using AluguelRV.Core.Models;
using AluguelRV.Shared.Dtos;
using AluguelRV.Shared.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AluguelRV.Core.Services;
public class UserService
{
    private readonly AluguelContext _context;
    private readonly ResponseHandler _response;

    public UserService(AluguelContext context)
    {
        _context = context;
        _response = new ResponseHandler();
    }

    public async Task<ResponseHandler> Create(CreateUserRequest request)
    {
        Person? person;

        if (request.PersonId != null)
        {
            person = await GetPersonWithoutUserOrThrow(request.PersonId.Value);
        }
        else if (request.Person != null)
        {
            person = new Person
            {
                Name = request.Person.Name,
                Resident = request.Person.Resident
            };

            await _context.People.AddAsync(person);
        }
        else
        {
            throw new InvalidOperationException("Forneça uma pessoa para vincular ao usuário!");
        }

        Hash(request.Password, out byte[] hash, out byte[] salt);

        var user = new User
        {
            Username = request.Username,
            Password = hash,
            Salt = salt,
            Person = person,
            Role = RoleType.User
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        _response.SetAsCreated(user.Adapt<UserDto>(), $"api/user/{user.Id}");

        return _response;
    }

    public async Task<ResponseHandler> ChangePassword(ChangePasswordRequest request)
    {
        var user = await _context.Users.FindAsync(request.UserId);

        if (user == null)
            throw new KeyNotFoundException("Usuário não encontrado!");

        using var oldHmac = new HMACSHA512(user.Salt);
        var oldHash = oldHmac.ComputeHash(Encoding.UTF8.GetBytes(request.OldPassword));

        if (!oldHash.SequenceEqual(user.Password))
            throw new UnauthorizedAccessException("Senha antiga incorreta!");

        if (request.OldPassword == request.NewPassword)
            throw new InvalidOperationException("Senha iguais!");

        Hash(request.NewPassword, out byte[] hash, out byte[] salt);

        user.Password = hash;
        user.Salt = salt;

        await _context.SaveChangesAsync();

        _response.Message = "Senha alterada com sucesso!";

        return _response;
    }

    private void Hash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();

        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private async Task<Person> GetPersonWithoutUserOrThrow(int personId)
    {
        var existingPerson = await _context.People.FindAsync(personId);

        if (existingPerson == null)
        {
            throw new KeyNotFoundException("Pessoa não encontrada!");
        }
        else
        {
            var existingUser = await _context.Users.Where(u => u.PersonId == existingPerson.Id).FirstOrDefaultAsync();

            if (existingUser == null)
                return existingPerson;
        }

        throw new InvalidOperationException("Essa pessoa já possui uma conta!");
    }
}