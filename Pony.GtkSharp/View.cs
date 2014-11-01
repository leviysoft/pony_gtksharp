using System;
using Pony;

namespace Pony.GtkSharp
{
	public class View<T> : Gtk.Window where T : class, new()
	{
		protected ViewResult _result;

		private readonly IPonyApplication _ponyApplication;

		public T Model { get; private set; }

		protected delegate void BindingEvent();

		protected event BindingEvent ModelChanged;

		protected View (IPonyApplication ponyApplication) : base(Gtk.WindowType.Toplevel)
		{
			_result = ViewResult.OK;
			_ponyApplication = ponyApplication;
			DeleteEvent += (o, args) => {if (Model == null) Model = new T(); };
		}

		public void SetModel(T model)
		{
			Model = model;
			if (ModelChanged != null) ModelChanged();
		}
	}
}

