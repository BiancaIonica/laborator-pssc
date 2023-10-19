using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tema.Domain.ShoppingCart;

namespace Tema.Domain.Models
{
	public record PublishProductsCommand
	{
		public PublishProductsCommand(IReadOnlyCollection<UnvalidatedProductCode> inputShopping)
		{
			InputExamGrades = inputShopping;
		}

		public IReadOnlyCollection<UnvalidatedProductCode> InputExamGrades { get; }
	}
}
