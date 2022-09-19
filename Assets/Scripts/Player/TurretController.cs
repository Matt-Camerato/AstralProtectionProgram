using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletPrefab;

    private void OnEnable() => ShipController.Fire += Fire;
    private void OnDisable() => ShipController.Fire -= Fire;

    private void Fire()
    {
        if (GameplayManager.Instance.gameIsOver) return;

        GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
    }
}
