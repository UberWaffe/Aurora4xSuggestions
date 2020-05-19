using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuroraUIMockup.Helpers
{
    public static class TextConversionsHelper
    {
        public static double ConvertTextToDouble(string text)
        {
            double result = 0.0;
            var converted = Double.TryParse(text, out result);
            if (converted)
            {
                return result;
            }
            else
            {
                throw new FormatException($"{text} is not a valid double value.");
            }
        }

        public static long ConvertTextToLong(string text)
        {
            long result = 0;
            var converted = long.TryParse(text, out result);
            if (converted)
            {
                return result;
            }
            else
            {
                throw new FormatException($"{text} is not a valid long (Int64) value.");
            }
        }
    }
}
