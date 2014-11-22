using System;
using Gtk;
using Pony;
using Pony.Views;
using Pony.GtkSharp.Demo.Domain;
using Pony.GtkSharp.Demo;

public partial class MainWindow: Gtk.Window, IView
{
	private readonly IPonyApplication _application;

	public MainWindow (IPonyApplication pony) : base (Gtk.WindowType.Toplevel)
	{
		_application = pony;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void CreateBtnClick(object sender, EventArgs e)
	{
		string message;
		var result = _application.Create<Pony.GtkSharp.Demo.Domain.Item> ();
		if (result.Status == OperationStatus.Completed)
		{
            message = string.Format ("{0} {1} {2} {3}", result.Result.Name, result.Result.Amount, result.Result.Comment, result.Result.IsActive);
		} 
		else 
		{
			message = "Fault";
		}
		var md = new MessageDialog (null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, message);
		md.Run ();
		md.Destroy ();
	}
		
	public ViewResult ShowDialog ()
	{
		Build ();
		return ViewResult.OK;
	}

    protected void EditClick(object sender, EventArgs e)
    {
        string message;
        var item = new Pony.GtkSharp.Demo.Domain.Item { Name = "Name", Comment = "Comment", Amount = 42 };
        var result = _application.Edit<Pony.GtkSharp.Demo.Domain.Item> (item);
        if (result.Status == OperationStatus.Completed)
        {
            message = string.Format ("{0} {1} {2} {3}", result.Result.Name, result.Result.Amount, result.Result.Comment, result.Result.IsActive);
        } 
        else 
        {
            message = "Fault";
        }
        var md = new MessageDialog (null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, message);
        md.Run ();
        md.Destroy ();
    }
}
