using System;
using Gtk;

namespace Pony.GtkSharp
{
	public static class ResponseTypeExtensions
	{
		public static ViewResult ToViewResult(this ResponseType responseType)
		{
			switch (responseType)
			{
				case ResponseType.None:
				case ResponseType.Help:
					return ViewResult.None;
				case ResponseType.Yes:
					return ViewResult.Yes;
				case ResponseType.No:
					return ViewResult.No;
				case ResponseType.Cancel:
				case ResponseType.Reject:
				case ResponseType.Close:
				case ResponseType.DeleteEvent:
					return ViewResult.Cancel;
				case ResponseType.Ok:
				case ResponseType.Accept:
				case ResponseType.Apply:
					return ViewResult.OK;
				default:
				return ViewResult.None;
			}
		}
	}
}

