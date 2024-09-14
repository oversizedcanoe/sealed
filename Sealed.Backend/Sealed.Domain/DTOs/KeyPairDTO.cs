using Sealed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sealed.Domain.DTOs
{
    public record KeyPairDTO
    {
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        
    }
}
