using System.Drawing;

namespace Calendar.Utils
{
    public static class Utils
    {
        public static uint ColorToHexUInt(Color color)
        {
            return (uint)((color.R << 16) | (color.G << 8) | color.B);
        }

        public static string ColorToHexString(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static string UintHexToString(uint value)
        {
            return "#" + value.ToString("X");
        }

        public static string ConvertDate(DateTime date)
        {
            return date.ToString("dddd - dd MMM hh:mm tt");
        }
    }
}
