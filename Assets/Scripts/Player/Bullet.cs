using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public static event Action<int> HitAsteroid;

    [SerializeField] private float _despawnTime;

    private void Awake() => StartCoroutine(DespawnTimer());

    //despawn bullet after given despawn time has expired
    private IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(_despawnTime);
        Destroy(gameObject);
    }

    //destroy bullet if it hits anything (other than the player since they're on the same layer)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) HitAsteroid.Invoke(collision.gameObject.GetComponent<Breakable>().size);
        Destroy(gameObject);
    }
}