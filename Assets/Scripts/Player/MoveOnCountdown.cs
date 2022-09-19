using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveOnCountdown : MonoBehaviour
{
    [SerializeField] private float _moveForce = 1f;

    [SerializeField] private UnityEvent MovePlayer;

    private Rigidbody2D _rb;

    private void Start() => _rb = GetComponent<Rigidbody2D>();
    private void OnEnable() => PlayerCountdown.Move += Move;
    private void OnDisable() => PlayerCountdown.Move -= Move;

    private void Move(float count)
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        _rb.AddForce(transform.up * _moveForce, ForceMode2D.Impulse);

        MovePlayer.Invoke();
    }
}
