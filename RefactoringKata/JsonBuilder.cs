using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class JsonBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private readonly Dictionary<string, object> _properties;
        public readonly string Separator = ", ";

        public JsonBuilder(Dictionary<string, object> properties)
        {
            _properties = properties;
        }

        public string ToJson()
        {
            _stringBuilder.Append("{");
            foreach (var property in _properties)
            {
                _stringBuilder.AppendFormat("\"{0}\"", property.Key);
                _stringBuilder.Append(": ");
                _stringBuilder.Append(GetValueJson(property.Value));
                _stringBuilder.Append(Separator);
            }
            if (_properties.Count > 0)
            {
                _stringBuilder.Remove(_stringBuilder.Length - 2, 2);
            }

            _stringBuilder.Append("}");
            return _stringBuilder.ToString();
        }

        private string GetValueJson(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (value is string)
            {
                return string.Format("\"{0}\"", value);
            }

            if (value is IEnumerable<JsonBuilder>)
            {
                return GetArrayJson((IEnumerable<JsonBuilder>)value);
            }
            return value.ToString();
        }

        private string GetArrayJson(IEnumerable<JsonBuilder> value)
        {
            return string.Format("[{0}]", string.Join(Separator, value.Select(builder => builder.ToJson())));
        }
    }
}