using Core.Extensions;

namespace Core.Data
{
    public readonly struct CubeData
    {
        public readonly int pot;
        public readonly int value;

        public CubeData(int pot)
        {
            this.pot = pot;
            value = pot.AsPowerOfTwo();
        }
    }
}