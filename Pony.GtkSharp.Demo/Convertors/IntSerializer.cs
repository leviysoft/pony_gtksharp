using System;
using Pony.Serialization;
using System.Globalization;

namespace Pony.GtkSharp.Demo.Convertors
{
    public class IntSerializer : ISerializer<int>
    {
        public string Serialize(int instance)
        {
            return instance.ToString(CultureInfo.InvariantCulture);
        }

        public int Deserialize(string representation)
        {
            return int.Parse(representation, CultureInfo.InvariantCulture);
        }
    }
}

