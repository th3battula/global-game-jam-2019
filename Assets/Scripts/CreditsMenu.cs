using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour {
    public void ReturnToMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}