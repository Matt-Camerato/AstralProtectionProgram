using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager Instance;

    [SerializeField] private List<GameObject> _asteroidPrefabs;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _initialCount;
    public float spawnRangeX, spawnRangeY;

    private List<GameObject> _asteroids = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < _initialCount; i++) SpawnAsteroid();
    }

    private void Start() => StartCoroutine(SpawnAsteroids());

    private IEnumerator SpawnAsteroids()
    {
        yield return new WaitForSeconds(_spawnDelay);

        SpawnAsteroid();

        StartCoroutine(SpawnAsteroids());
    }

    public void SpawnAsteroid()
    {
        int index = Random.Range(0, _asteroidPrefabs.Count);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
        GameObject asteroid = Instantiate(_asteroidPrefabs[index], spawnPos, Quaternion.identity);
        asteroid.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized, ForceMode2D.Impulse);
        _asteroids.Add(asteroid);
    }
}
