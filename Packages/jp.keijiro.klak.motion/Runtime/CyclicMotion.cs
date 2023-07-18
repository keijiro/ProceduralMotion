using UnityEngine;
using Unity.Mathematics;

namespace Klak.Motion {

[AddComponentMenu("Klak/Procedural Motion/Cyclic Motion")]
public sealed class CyclicMotion : MonoBehaviour
{
    #region Editable attributes

    [field:SerializeField] public float3 PositionAmount = new float3(1, 0, 0);
    [field:SerializeField] public float3 RotationAmount = new float3(0, 10, 0);
    [field:SerializeField] public float Frequency = 1;

    #endregion

    #region Private members

    float3 _initialPosition;
    quaternion _initialRotation;
    float _param;

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
        _initialPosition = transform.localPosition;
        _initialRotation = transform.localRotation;
    }

    void Update()
    {
        _param += Frequency * math.PI * Time.deltaTime;
        var w = math.sin(_param);
        var rot = quaternion.EulerZXY(math.radians(RotationAmount * w));
        transform.localPosition = _initialPosition + PositionAmount * w;
        transform.localRotation = math.mul(_initialRotation, rot);
    }

    #endregion
}

} // namespace Klak.Motion
