using System;
using Pony.GtkSharp.Demo.Domain;
using Pony.Views;

namespace Pony.GtkSharp.Demo
{
	public partial class ItemEditor : ViewDialog<Item>, IView<Item>
	{
		public ItemEditor (IPonyApplication ponyApplication) : base (ponyApplication)
		{
		}

		public ViewResult ShowDialog ()
		{
			this.Build ();
			this.Run ();
			this.Destroy ();
			return _result;
		}
	}
}

