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
    }
}
