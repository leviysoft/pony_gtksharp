using System;
using Gtk;
using Pony;
using Pony.Views;

public partial class MainWindow: Gtk.Window, IView
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void CreateBtnClick(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
		
	public ViewResult ShowDialog ()
	{
		Show ();
		return ViewResult.OK;
	}
}
