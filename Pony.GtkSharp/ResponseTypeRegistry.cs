using System;
using System.Collections.Generic;
using Gtk;

namespace Pony.GtkSharp
{
    public static class ResponseTypeRegistry
    {
        public static List<ResponseType> PositiveResponseTypes = new List<ResponseType>{
            ResponseType.Accept,
            ResponseType.Ok
        };
    }
}

