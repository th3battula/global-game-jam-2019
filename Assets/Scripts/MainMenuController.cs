using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public void PlayButtonClicked() {
        SceneManager.LoadScene("Wilderness");
    }

    public void ExitButtonClicked() {
        Application.Quit();
    }

    public void CreditsButtonClicked() {
        SceneManager.LoadScene("Credits");
    }
}
