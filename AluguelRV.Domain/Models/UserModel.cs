using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelRV.Domain.Models;
public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] Salt { get; set; }
    public int PersonId { get; set; }
    public bool Deleted { get; set; }
}
