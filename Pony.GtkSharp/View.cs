using System;
using Pony;

namespace Pony.GtkSharp
{
	public class View<T> : Gtk.Window where T : class, new()
	{
		protected View (IPonyApplication ponyApplication) : base(Gtk.WindowType.Toplevel)
		{
		}
	}
}

