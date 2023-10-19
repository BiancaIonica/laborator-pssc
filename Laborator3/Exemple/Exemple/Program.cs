using Tema.Domain.Models;
using System;
using System.Collections.Generic;
using static Tema.Domain.Models.ShoppingCart;
using static Tema.Domain.ProductsOperation;
using Tema.Domain;

namespace Tema
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfGrades = ReadListOfGrades().ToArray();
            PublishProductsCommand command = new(listOfProducts);
            PublishProductWorkflow workflow = new PublishProductWorkflow();
            var result = workflow.Execute(command, (productCode) => true);

            result.Match(
                    whenExamGradesPublishFaildEvent: @event =>
                    {
                        Console.WriteLine($"Publish failed: {@event.Reason}");
                        return @event;
                    },
                    whenExamGradesPublishScucceededEvent: @event =>
                    {
                        Console.WriteLine($"Publish succeeded.");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
                );

            Console.WriteLine("Hello World!");
        }

        private static List<UnvalidatedProductCode> ReadListOfGrades()
        {
            List <UnvalidatedProductCode> listOfGrades = new();
            do
            {
                //read registration number and grade and create a list of greads
                var productCode = ReadValue("Product Code: ");
                if (string.IsNullOrEmpty(productCode))
                {
                    break;
                }

                var quantity = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                var address = ReadValue("Address: ");
                if (string.IsNullOrEmpty(address))
                {
                    break;
                }

                listOfGrades.Add(new ( quantity, productCode, address));
            } while (true);
            return listOfGrades;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
