using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
	
		[AsChoice]

		public static partial class Quantity
		{
			public interface IQuantity { }
			public record Units (int number):IQuantity;
		 public record Kilograms(double numberOfKg): IQuantity;
		public record Undefined (string undefined): IQuantity;	
		}

	
}
