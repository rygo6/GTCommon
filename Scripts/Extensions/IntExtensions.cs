namespace GeoTetra.GTCommon.Extensions
{
    public static class IntExtensions
    {
        public static int NegativeToZero(this int value)
        {
            if (value < 0) value = 0;
            return value;
        }

        public static int NegativeToPositive(this int value)
        {
            if (value < 0)
            {
                value *= -1;
                value--;
            }

            return value;
        }
    }
}