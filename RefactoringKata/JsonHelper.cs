using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class JsonHelper
    {
        private static readonly string Separator = ", ";

        public static string ToJson(Dictionary<string, object> properties)
        {
            var builder = new StringBuilder();

            foreach (var property in properties)
            {
                builder.Append(Separator);
                builder.Append(GetStringJson(property.Key));
                builder.Append(": ");
                builder.Append(GetObjectJson(property.Value));
            }

            builder.Remove(0, Separator.Length);
            builder.Insert(0, "{");
            builder.Append("}");

            return builder.ToString();
        }

        private static string GetObjectJson(object value)
        {
            string result;

            if (value is string)
            {
                result = GetStringJson(value.ToString());
            }
            else if (value is IEnumerable<string>)
            {
                result = GetArrayJson((IEnumerable<string>)value);
            }
            else
            {
                result = value.ToString();
            }
            return result;
        }

        private static string GetArrayJson(IEnumerable<string> value)
        {
            return string.Format("[{0}]", string.Join(Separator, value));
        }

        private static string GetStringJson(string value)
        {
            return string.Concat('"', value, '"');
        }
    }
}