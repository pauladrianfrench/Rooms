namespace Rooms
{
    using System;
    public static class Utils
    {
        public static int Max(params int[] vals)
        {
            int ret = Int32.MinValue;

            foreach (int i in vals)
            {
                ret = (i > ret) ? i : ret;
            }
            return ret;
        }

        public static int Min(params int[] vals)
        {
            int ret = Int32.MaxValue;

            foreach (int i in vals)
            {
                ret = (i < ret) ? i : ret;
            }
            return ret;
        }
    }
}
