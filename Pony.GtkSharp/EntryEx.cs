using System;
using Gtk;
using Pony.Validation;
using System.Collections.Generic;
using Pony.Serialization;

namespace Pony.GtkSharp
{
    public static class EntryEx
    {
        public static string Validate<TProp>(this Entry control, ISerializer<TProp> serializer, List<PropertyValidationAttribute> validationRules)
        {
            var error = "";
            try
            {
                var value = serializer.Deserialize(control.Text);
                foreach (var attribute in validationRules)
                {
                    if (!attribute.GetValidator()(value))
                    {
                        error = attribute.ErrorMessage;
                        break;
                    }    
                }
            }
            catch (Exception)
            {
                error = "Invalid value format";
            }
            return error;
        }
    }
}

