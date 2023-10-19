using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema.Domain;

namespace Exemple.Domain
{
    public record ValidatedProductPrice(Quantity Quantity, ProductCode ProductCode, Address Address);
}
