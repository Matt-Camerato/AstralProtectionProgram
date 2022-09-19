using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public int Score = 0;
    public bool gameIsOver = false;

    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _finalScoreText;

    private void Awake() => Instance = this;

    private void OnEnable()
    {
        Bullet.HitAsteroid += HitAsteroid;
        PlanetController.PlanetDied += GameOver;
    }

    private void OnDisable()
    {
        Bullet.HitAsteroid -= HitAsteroid;
        PlanetController.PlanetDied += GameOver;
    }

    private void Update()
    {
        if (gameIsOver) return;

        _scoreText.text = Score.ToString();
        Score++;
    }

    private void HitAsteroid(int size) => Score += 50 * (1 + size);
    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _finalScoreText.text = "Your Final Score: " + Score;
        gameIsOver = true;
    }

    public void QuitGame() => SceneManager.LoadScene(0);
}
