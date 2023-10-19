using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
	internal record Command
	{
		public Person Person { get; set; }
		public List<Product>ProductList { get; set; }
	}
}
