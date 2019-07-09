using Unity.Mathematics;

namespace Klak.Motion
{
    [UnityEngine.AddComponentMenu("Klak/Procedural Motion/Linear Motion")]
    public sealed class LinearMotion : UnityEngine.MonoBehaviour
    {
        #region Editable attributes

        public float3 velocity = new float3(0, 0, 1);
        public float3 angularVelocity = new float3(0, 90, 0);

        #endregion

        #region MonoBehaviour implementation

        void Update()
        {
            var dt = UnityEngine.Time.deltaTime;
            var dp = velocity * dt;
            var dr = quaternion.EulerZXY(math.radians(angularVelocity * dt));

            transform.localPosition += (UnityEngine.Vector3)dp;
            transform.localRotation *= dr;
        }

        #endregion
    }
}
