using System;
using System.Collections.Generic;
using Gtk;

namespace Pony.GtkSharp
{
    public class GtkErrorProvider
    {
        private Gtk.Dialog Dialog;
        private Dictionary<Widget, string> Errors;

        public delegate void ErrorSetHandler(Widget control, string error);
        public event ErrorSetHandler ErrorSet;

        public delegate void ErrorReleasedHandler(Widget control);
        public event ErrorReleasedHandler ErrorReleased;

        public GtkErrorProvider(Gtk.Dialog dialog)
        {
            Dialog = dialog;
            Errors = new Dictionary<Widget, string>();
        }

        public void SetError(Widget control, string error)
        {
            if (Errors.ContainsKey(control))
            {
                Errors[control] = error;
            }
            else
            {
                Errors.Add(control, error);
            }
            if (ErrorSet != null)
                ErrorSet(control, error);
            ResponseTypeRegistry.PositiveResponseTypes.ForEach(t => Dialog.SetResponseSensitive(t, false));
        }

        public void ReleaseError(Widget control)
        {
            if (Errors.ContainsKey(control))
            {
                Errors.Remove(control);
            }

            if (ErrorReleased != null)
                ErrorReleased(control);

            if (!ErrorsPresent())
            {
                ResponseTypeRegistry.PositiveResponseTypes.ForEach(t => Dialog.SetResponseSensitive(t, true));
            }
        }

        public bool ErrorsPresent()
        {
            return Errors.Count != 0;
        }
    }
}

