using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        PlayerPrefs.SetInt("Game_Starting_Loading", 0);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
