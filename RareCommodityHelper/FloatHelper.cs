using System.Globalization;

namespace RareCommodityHelper
{
    public static class FloatHelper
    {
        public static float AsFloat(string input)
        {
            float outFloat;
            return float.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out outFloat) ? outFloat : 0.0f;
        }
    }
}