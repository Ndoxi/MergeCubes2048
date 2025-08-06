using Extensions;

namespace Core.Data
{
    public readonly struct CubeData
    {
        public readonly int power;
        public readonly int value;

        public CubeData(int power)
        {
            this.power = power;
            value = power.AsPowerOfTwo();
        }
    }
}