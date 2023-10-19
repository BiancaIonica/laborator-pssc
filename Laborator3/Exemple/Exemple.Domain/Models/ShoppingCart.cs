using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Domain.Models
{
    [AsChoice]
    public static partial class ShoppingCart
	{
        public interface IShoppingCart { }

        public record UnvalidatedProductCode : IShoppingCart
        {
            public UnvalidatedProductCode(IReadOnlyCollection<UnvalidatedProductCode> prodList)
            {
                ProductList = prodList;
            }

            public IReadOnlyCollection<UnvalidatedProductCode> ProductList { get; }
        }

        public record InvalidatedExamGrades: IShoppingCart
        {
            internal InvalidatedExamGrades(IReadOnlyCollection<UnvalidatedProductCode> prodList, string reason)
            {
				ProductList = prodList;
                Reason = reason;
            }

            public IReadOnlyCollection<UnvalidatedProductCode> ProductList { get; }
            public string Reason { get; }
        }

        public record ValidatedProductPrice : IShoppingCart
        {
            internal ValidatedProductPrice(IReadOnlyCollection<ValidatedProductPrice> prodList)
            {
				ProductList = prodList;
            }

            public IReadOnlyCollection<ValidatedProductPrice> ProductList { get; }
        }

        public record CalculatedProductPrice : IShoppingCart
        {
            internal CalculatedProductPrice(IReadOnlyCollection<CalculatedProductPrice> prodList)
            {
				ProductList = prodList;
            }

            public IReadOnlyCollection<CalculatedProductPrice> ProductList { get; }
        }

        public record PublishProductsCommand : IShoppingCart
        {
            internal PublishProductsCommand(IReadOnlyCollection<CalculatedProductPrice> prodList, string csv, DateTime publishedDate)
            {
				ProductList = prodList;
                PublishedDate = publishedDate;
                Csv = csv;
            }

            public IReadOnlyCollection<CalculatedProductPrice> ProductList { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
        }
    }
}
