using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class Product
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        public string Code { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        private readonly Dictionary<int, string> _colorMapping = new Dictionary<int, string>()
        {
            { 1, "blue" },
            { 2, "red" },
            { 3, "yellow" }
        };

        private readonly Dictionary<int, string> _sizeMapping = new Dictionary<int, string>()
        {
            { 1, "XS" },
            { 2, "S" },
            { 3, "M" },
            { 4, "L" },
            { 5, "XL" },
            { 6, "XXL" }
        };

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        public string GetColorText()
        {
            string result;
            if (!_colorMapping.TryGetValue(Color, out result))
            {
                result = "no color";
            }
            return result;
        }

        public string GetSizeText()
        {
            string result;
            if (!_sizeMapping.TryGetValue(Size, out result))
            {
                result = "Invalid Size";
            }
            return result;
        }

        public bool IsSizeApplicable()
        {
            return Size != Product.SIZE_NOT_APPLICABLE;
        }
    }
}
