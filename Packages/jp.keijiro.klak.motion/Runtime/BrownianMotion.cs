using Unity.Mathematics;

namespace Klak.Motion
{
    [UnityEngine.AddComponentMenu("Klak/Procedural Motion/Brownian Motion")]
    public sealed class BrownianMotion : UnityEngine.MonoBehaviour
    {
        #region Editable attributes

        public float3 positionAmount = 1;
        public float3 rotationAmount = 10;
        public float frequency = 1;
        public int octaves = 2;

        #endregion

        #region Public method

        public void Rehash()
        {
            var rand = new Random(_sharedSeed++);

            // Abandon a few first numbers to warm up the PRNG.
            rand.NextUInt(); rand.NextUInt();

            _positionOffset = rand.NextFloat3(-1e3f, 1e3f);
            _rotationOffset = rand.NextFloat3(-1e3f, 1e3f);

            ApplyMotion();
        }

        #endregion

        #region Private members

        static uint _sharedSeed = 1;

        float3 _positionOffset;
        float3 _rotationOffset;
        float _time;

        float3 _initialPosition;
        quaternion _initialRotation;

        float Fbm(float x, float y, int octave)
        {
            var p = math.float2(x, y);
            var f = 0.0f;
            var w = 0.5f;
            for (var i = 0; i < octave; i++)
            {
                f += w * noise.snoise(p);
                p *= 2.0f;
                w *= 0.5f;
            }
            return f;
        }

        void ApplyMotion()
        {
            var np = math.float3(
                Fbm(_positionOffset.x, _time, octaves),
                Fbm(_positionOffset.y, _time, octaves),
                Fbm(_positionOffset.z, _time, octaves)
            );

            var nr = math.float3(
                Fbm(_rotationOffset.x, _time, octaves),
                Fbm(_rotationOffset.y, _time, octaves),
                Fbm(_rotationOffset.z, _time, octaves)
            );

            np = np * positionAmount / 0.75f;
            nr = nr * rotationAmount / 0.75f;

            var nrq = quaternion.EulerZXY(math.radians(nr));

            transform.localPosition = _initialPosition + np;
            transform.localRotation = math.mul(nrq, _initialRotation);
        }

        #endregion

        #region MonoBehaviour implementation

        void Start()
        {
            Rehash();
        }

        void OnEnable()
        {
            _initialPosition = transform.localPosition;
            _initialRotation = transform.localRotation;
        }

        void OnDisable()
        {
            transform.localPosition = _initialPosition;
            transform.localRotation = _initialRotation;
        }

        void Update()
        {
            _time += UnityEngine.Time.deltaTime * frequency;
            ApplyMotion();
        }

        #endregion
    }
}
