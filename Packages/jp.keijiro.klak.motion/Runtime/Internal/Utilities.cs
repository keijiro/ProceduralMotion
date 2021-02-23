namespace Klak.Motion
{
    static class Utilities
    {
        public static Unity.Mathematics.Random Random(uint seed)
        {
            // Auto reseeding
            if (seed == 0) seed = (uint)UnityEngine.Random.Range(0, 0x7fffffff);

            var random = new Unity.Mathematics.Random(seed);

            // Abandon a few first numbers to warm up the PRNG.
            random.NextUInt();
            random.NextUInt();

            return random;
        }
    }
}

