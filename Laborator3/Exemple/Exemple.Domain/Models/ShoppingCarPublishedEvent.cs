using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Domain.Models
{
    [AsChoice]
    public static partial class ShoppingCarPublishedEvent
    {
        public interface IShoppingCartPublishedEvent { }

        public record ShoppingCartPublishScucceededEvent : IShoppingCartPublishedEvent
		{
            public string Csv{ get;}
            public DateTime PublishedDate { get; }

            internal ShoppingCartPublishScucceededEvent(string csv, DateTime publishedDate)
            {
                Csv = csv;
                PublishedDate = publishedDate;
            }
        }

        public record ShoppingCartPublishFaildEvent : IShoppingCartPublishedEvent
		{
            public string Reason { get; }

            internal ShoppingCartPublishFaildEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
