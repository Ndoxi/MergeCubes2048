using UnityEngine;

namespace Core.Extensions
{
    public static class MathExtension
    {
        public static int AsPowerOfTwo(this int value)
        {
            return 1 << value;
        }
    }
}