using System;
using Pony;

namespace Pony.GtkSharp
{
	public class View<T> : Gtk.Window where T : class, new()
	{
		protected ViewResult Result;

		private readonly IPonyApplication _ponyApplication;

		public T Model { get; private set; }

		protected delegate void BindingEvent();

		protected event BindingEvent ModelChanged;

		protected View (IPonyApplication ponyApplication) : base(Gtk.WindowType.Toplevel)
		{
			Result = ViewResult.OK;
		}

		public void SetModel(T model)
		{
			Model = model;
			if (ModelChanged != null) ModelChanged();
		}

		public ViewResult ShowDialog()
		{
			Show ();
			return Result;
		}
	}
}

