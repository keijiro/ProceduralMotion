using Unity.Mathematics;

namespace Klak.Motion
{
    [UnityEngine.AddComponentMenu("Klak/Procedural Motion/Smooth Follow")]
    public sealed class SmoothFollow : UnityEngine.MonoBehaviour
    {
        #region Editable attributes

        public enum Interpolator { Exponential, Spring, DampedSpring }

        public UnityEngine.Transform target = null;
        public Interpolator interpolator = Interpolator.DampedSpring;
        [UnityEngine.Range(0, 20)] public float positionSpeed = 2;
        [UnityEngine.Range(0, 20)] public float rotationSpeed = 2;

        #endregion

        #region Public method

        public void Snap()
        {
            if (positionSpeed > 0) transform.position = target.position;
            if (rotationSpeed > 0) transform.rotation = target.rotation;
        }

        #endregion

        #region Private members

        float3 _vp;
        float4 _vr;

        #endregion

        #region MonoBehaviour implementation

        void Update()
        {
            var dt = UnityEngine.Time.deltaTime;

            if (positionSpeed > 0)
            {
                var p = (float3)transform.position;
                var pt = (float3)target.position;
                var sp = positionSpeed;

                if (interpolator == Interpolator.Exponential)
                {
                    p = math.lerp(pt, p, math.exp(sp * -dt));
                }
                else if (interpolator == Interpolator.Spring)
                {
                    _vp *= math.exp((1 + sp * 0.5f) * -dt);
                    _vp += (pt - p) * (sp * 0.1f);
                    p += _vp * dt;
                }
                else // interpolator == Interpolator.DampedSpring
                {
                    var n1 = _vp - (p - pt) * (sp * sp * dt);
                    var n2 = 1 + sp * dt;
                    _vp = n1 / (n2 * n2);
                    p += _vp * dt;
                }

                transform.position = p;
            }

            if (rotationSpeed > 0)
            {
                var r = ((quaternion)transform.rotation).value;
                var rt = ((quaternion)target.rotation).value;
                var sp = rotationSpeed;

                if (math.dot(r, rt) < 0) rt = -rt;

                if (interpolator == Interpolator.Exponential)
                {
                    r = math.lerp(rt, r, math.exp(sp * -dt));
                }
                else if (interpolator == Interpolator.Spring)
                {
                    _vr *= math.exp((1 + sp * 0.5f) * -dt);
                    _vr += (rt - r) * (sp * 0.1f);
                    r += _vr * dt;
                }
                else // interpolator == Interpolator.DampedSpring
                {
                    var n1 = _vr - (r - rt) * (sp * sp * dt);
                    var n2 = 1 + sp * dt;
                    _vr = n1 / (n2 * n2);
                    r += _vr * dt;
                }

                transform.rotation = math.normalize(math.quaternion(r));
            }
        }

        #endregion
    }
}
