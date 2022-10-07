using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelRV.Domain.ViewModels;
public record PersonViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
