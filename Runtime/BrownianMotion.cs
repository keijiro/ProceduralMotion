using UnityEngine;
using Unity.Mathematics;

namespace Klak.Motion
{
    [AddComponentMenu("Klak/Procedural Motion/Brownian Motion")]
    public sealed class BrownianMotion : MonoBehaviour
    {
        #region Editable attributes

        public Vector3 positionAmount = Vector3.one;
        public Vector3 rotationAmount = Vector3.one * 10;
        public float frequency = 1;
        public int octaves = 2;

        #endregion

        #region Public method

        public void Rehash()
        {
            var rand = new Unity.Mathematics.Random(_sharedSeed++);
            _positionOffset = rand.NextFloat3(-1e3f, 1e3f);
            _rotationOffset = rand.NextFloat3(-1e3f, 1e3f);
        }

        #endregion

        #region Private Members

        static uint _sharedSeed = 1;

        float3 _positionOffset;
        float3 _rotationOffset;
        float _time;

        Vector3 _initialPosition;
        Quaternion _initialRotation;

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

        void Update()
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

            transform.localPosition = _initialPosition + (Vector3)np;
            transform.localRotation = Quaternion.Euler(nr) * _initialRotation;

            _time += Time.deltaTime * frequency;
        }

        #endregion
    }
}
