using System;
using Pony.GtkSharp.Demo.Domain;
using Pony.Views;

namespace Pony.GtkSharp.Demo
{
	public partial class ItemEd : ViewDialog<Item>, IView<Item>
	{
		public ItemEd (IPonyApplication application): base(application)
		{
		}

		public ViewResult ShowDialog()
		{
			this.Build ();
			this.Run ();
			this.Destroy ();
			return _result;
		}
	}
}

