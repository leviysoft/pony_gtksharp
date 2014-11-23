using System;
using Gtk;

namespace Pony.GtkSharp
{
    public static class GtkErrorVisualizer
    {
        public static void OnErrorSet(Widget control, string error)
        {
            Gdk.Color col = new Gdk.Color();
            Gdk.Color.Parse("pink", ref col);
            control.ModifyBase(StateType.Normal, col);
            control.TooltipText = error;
        }

        public static void OnErrorRelease(Widget control)
        {
            control.ModifyBase(StateType.Normal);
            control.TooltipText = "";
        }
    }
}

