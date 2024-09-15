using Sealed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sealed.Domain.DTOs
{
    public record KeyDTO
    {
        public string Code { get; set; }
    }
}
