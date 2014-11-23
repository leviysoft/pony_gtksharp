using System;
using Pony.Validation;

namespace Pony.GtkSharp.Demo.Domain
{
	public class Item
	{
		public string Name { get; set; }

        [IntIsInRange(5, 10, "Больше 5, но меньше 10")]
		public int Amount { get; set; }
		public string Comment { get; set; }
        public bool IsActive { get; set; }
	}
}

