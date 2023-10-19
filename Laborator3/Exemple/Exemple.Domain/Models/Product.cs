using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Domain.Models
{
    public record Product
    {
        public decimal Value { get; }

        public Product(decimal value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductCodeException($"{value:0.##} is an invalid value.");
            }
        }

        public static Product operator +(Product a, Product b) => new Product((a.Value + b.Value) / 2m);


        public Product Round()
        {
            var roundedValue = Math.Round(Value);
            return new Product(roundedValue);
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }

        public static bool TryParseGrade(string productString, out Product prod)
        {
            bool isValid = false;
            prod = null;
            if(decimal.TryParse(productString, out decimal numericProduct))
            {
                if (IsValid(numericProduct))
                {
                    isValid = true;
                    prod = new(numericProduct);
                }
            }

            return isValid;
        }

        private static bool IsValid(decimal numericProduct) => numericProduct> 0 && numericProduct<= 10;
    }
}
