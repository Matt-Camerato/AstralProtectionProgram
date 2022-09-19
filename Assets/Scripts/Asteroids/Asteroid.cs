using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _maxLifespan;
    private float _lifespan;

    private void Awake() => _lifespan = _maxLifespan;

    private void Update()
    {
        _lifespan -= Time.deltaTime;
        if (_lifespan <= 0) Destroy(gameObject);

        if(Mathf.Abs(transform.position.x) > AsteroidManager.Instance.spawnRangeX ||
            Mathf.Abs(transform.position.y) > AsteroidManager.Instance.spawnRangeY)
        {
            AsteroidManager.Instance.SpawnAsteroid();
            Destroy(gameObject);
        }
    }
}
