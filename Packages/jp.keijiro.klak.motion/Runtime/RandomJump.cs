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

        public uint seed = 0;

        #endregion

        #region Public method

        public void Jump()
        {
            var dp = _random.NextFloat3Direction();
            dp *= _random.NextFloat(minDistance, maxDistance);

            var angle = math.radians(_random.NextFloat(minAngle, maxAngle));
            var dr = quaternion.AxisAngle(_random.NextFloat3Direction(), angle);

            transform.localPosition = (float3)transform.localPosition + dp;
            transform.localRotation = math.mul(dr, transform.localRotation);
        }

        #endregion

        #region Private members

        Random _random;

        #endregion

        #region MonoBehaviour implementation

        void Start() => _random = Utilities.Random(seed);

        #endregion
    }
}
