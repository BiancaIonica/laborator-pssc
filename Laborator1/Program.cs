
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;


namespace Laborator1
{
	internal class Program
	{

		private static void Main(string[] args)
		{
			IQuantity q = ConvertToQuantity("2");
			q.Match{
			whenKilograms: kilograms => kilograms;
			whenUndefined: undefined => undefined;
			whenUnits: units => print(units);
				Console.WriteLine(q.GetType());
				Person.person{ "Andrei" ,"Popescu", "1234567890","UPT"};
			}

			private static IQuantity ConvertToQuantity(string sal)
			{
				if (Int.TryParse(sal, out int units))
					return Units(units);
				else if (Double.TryParse(sal, out double kgs))
					return new Kilograms(kgs);
				else return new Undefined(sal);
			}
			private static Units print(Units units)
			{
				Console.WriteLine(units.number);
				return units;
			}

		}
	}

	public interface IQuantity
	{
	} }