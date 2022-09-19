using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGameButton : MonoBehaviour
{
    public void BeginGame() => SceneManager.LoadScene(1);
}
