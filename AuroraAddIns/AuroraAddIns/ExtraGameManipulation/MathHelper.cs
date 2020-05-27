using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.ExtraGameManipulation
{
    public static class MathHelper
    {
        public static int LimitRange(int value, int min = int.MinValue, int max = int.MaxValue)
        {
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
