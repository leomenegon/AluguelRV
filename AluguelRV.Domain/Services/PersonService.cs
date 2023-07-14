using AluguelRV.Domain.Interfaces;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.Interfaces.Services;
using AluguelRV.Domain.Models;
using AluguelRV.Shared.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelRV.Domain.Services;
public class PersonService : IPersonService
{
    private readonly IPersonData _personData;
    private readonly IMapper _mapper;

    public PersonService(IPersonData personData, IMapper mapper)
    {
        _personData=personData;
        _mapper=mapper;
    }

    public async Task<ResponseHandler> GetAll()
    {
        var response = new ResponseHandler();

        var data = await _personData.GetAll();

        if (data.Any())
            response.Value = _mapper.Map<IEnumerable<PersonViewModel>>(data);
        else
            response.SetAsNotFound();

        return response;
    }

    public async Task<ResponseHandler> GetById(int id)
    {
        var response = new ResponseHandler();

        var data = await _personData.GetById(id);

        if (data != null)
            response.Value = _mapper.Map<PersonViewModel>(data);
        else
            response.SetAsNotFound();

        return response;
    }
}