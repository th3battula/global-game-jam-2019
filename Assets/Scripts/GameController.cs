using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    [SerializeField] Transform homeSpawn;
    [SerializeField] PlayerController player;

    bool shouldGoHome = false;

    void Awake() {
        GameObject[] gameControllers = GameObject.FindGameObjectsWithTag("GameController");
        //TAB
        Debug.Log("GameControllers in scene: " + gameControllers.Length);
        if (gameControllers.Length <= 1) {
            DontDestroyOnLoad(this.gameObject);
        }
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