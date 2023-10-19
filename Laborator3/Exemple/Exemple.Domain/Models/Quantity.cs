using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Domain
{
    public record Quantity
    {
        public decimal Value { get; }
        
        public override string ToString()
        {
            return $"{Value:0.##}";
        }
    }
}
