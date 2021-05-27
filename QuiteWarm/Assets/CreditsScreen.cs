using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
    public void LoadMenu() {
        PlayerPrefs.SetInt("Loading menu", 0);
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
