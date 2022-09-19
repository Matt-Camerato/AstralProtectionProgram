using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private bool _isCamera;

    private void LateUpdate() => transform.position = new Vector3(
        _targetTransform.position.x, _targetTransform.position.y,
        _isCamera ? -10f : _targetTransform.position.z);
}
