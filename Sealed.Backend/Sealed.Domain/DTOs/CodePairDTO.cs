using Sealed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sealed.Domain.DTOs
{
    public record CodePairDTO
    {
        public string PrivateCode { get; set; }
        public string PublicCode { get; set; }
        
    }
}
