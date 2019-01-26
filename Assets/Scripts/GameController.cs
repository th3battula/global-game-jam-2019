using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] Transform homeSpawn;
    [SerializeField] GameObject player;

    bool shouldGoHome = false;

    private void Start() {
        // SceneManager.LoadScene("Home");
    }

    private void Update() {
        if (shouldGoHome) {
            SceneManager.LoadScene("Home");
            shouldGoHome = false;
        }
    }

    public void GoHome() {
        shouldGoHome = true;
    }
}