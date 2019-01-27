using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    [SerializeField] Transform homeSpawn;
    [SerializeField] PlayerController player;

    bool shouldGoHome = false;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable() {
        instance = this;
    }

    void Update() {
        if (shouldGoHome) {
            SceneManager.LoadScene("Home");
            shouldGoHome = false;
        }
    }

    public void GoHome() {
        shouldGoHome = true;
    }
}