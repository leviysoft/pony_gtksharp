using System;
using Pony.GtkSharp.Demo.Domain;
using Pony.Views;

namespace Pony.GtkSharp.Demo
{
	public partial class ItemEd : ViewDialog<Item>, IView<Item>
	{
		public ItemEd (IPonyApplication application): base(application)
		{
            Bind(m => m.Name, (ItemEd f) => f.NameEditor);
            Bind(m => m.Amount, (ItemEd f) => f.AmountEditor);
            Bind(m => m.Comment, (ItemEd f) => f.CommentEditor);
		}

		public ViewResult ShowDialog()
		{
			this.Build ();
            var result = (Gtk.ResponseType)this.Run ();
			this.Destroy ();
            return result.ToViewResult();
		}
	}
}

