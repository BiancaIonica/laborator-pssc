using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
	internal record Product
	{
		public string ProductCode { get; set; }
		public IQuantity Quantity { get; }
	}
}
