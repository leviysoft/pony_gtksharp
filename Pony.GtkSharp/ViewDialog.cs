using System;

namespace Pony.GtkSharp
{
	public class ViewDialog<T> : Gtk.Dialog where T : class, new()
	{
		protected ViewResult _result;

		private readonly IPonyApplication _ponyApplication;

		public T Model { get; private set; }

		protected delegate void BindingEvent();

		protected event BindingEvent ModelChanged;

		public ViewDialog (IPonyApplication ponyApplication)
		{
			_result = ViewResult.None;
			_ponyApplication = ponyApplication;
            DeleteEvent += (o, args) => { if (Model == null) Model = new T (); };
            DestroyEvent += (o, args) => { if (Model == null) Model = new T (); };
            Response += (o, args) => { if (Model == null) Model = new T (); };
		}

		public void SetModel(T model)
		{
			Model = model;
			if (ModelChanged != null) ModelChanged();
		}

		public new void Show()
		{
            //This is required for instantiation of ViewDialog without showing it.
		}
	}
}

