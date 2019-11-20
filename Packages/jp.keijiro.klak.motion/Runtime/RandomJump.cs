using Unity.Mathematics;

namespace Klak.Motion
{
    [UnityEngine.AddComponentMenu("Klak/Procedural Motion/Random Jump")]
    public sealed class RandomJump : UnityEngine.MonoBehaviour
    {
        #region Editable attributes

        public float minDistance = 0;
        public float maxDistance = 1;

        public float minAngle = 0;
        public float maxAngle = 90;

        #endregion

        #region Public method

        public void Jump()
        {
            var rand = new Random(_sharedSeed++);

            // Abandon a few first numbers to warm up the PRNG.
            rand.NextUInt(); rand.NextUInt();

            var dp = rand.NextFloat3Direction();
            dp *= rand.NextFloat(minDistance, maxDistance);

            var angle = math.radians(rand.NextFloat(minAngle, maxAngle));
            var dr = quaternion.AxisAngle(rand.NextFloat3Direction(), angle);

            transform.localPosition = (float3)transform.localPosition + dp;
            transform.localRotation = math.mul(dr, transform.localRotation);
        }

        #endregion

        #region Private members

        static uint _sharedSeed = 1;

        #endregion
    }
}
