using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Domain.Models
{
	internal class UnvalidatedProductCode
	{
		public record UnvalidatedShoppingCart(string Quantity, string ProductCode, string Address);
	}
}
