using System;
using Pony.GtkSharp.Demo.Domain;
using Pony.Views;

namespace Pony.GtkSharp.Demo
{
	public partial class ItemEditor : View<Item>, IView<Item>
	{
		public ItemEditor (IPonyApplication ponyApplication) : base (ponyApplication)
		{
		}
			
		public ViewResult ShowDialog ()
		{
			this.Build ();
			return _result;
		}
	}
}

