using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject saveMenuUI;

    private static float prevTimeScale;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        saveMenuUI.SetActive(false);
        Time.timeScale = prevTimeScale;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        prevTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadSaveMenu() {
        pauseMenuUI.SetActive(false);
        saveMenuUI.SetActive(true);
    }

    public void LoadMenu() {
        //Time.timeScale = prevTimeScale;
        //SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        //Application.Quit();
        SaveManager.triggerLoad();
    }

    public void SetSlot1() {
        PlayerPrefs.SetString("CurrentSlot", "Slot 1");
    }

    public void SetSlot2() {
        PlayerPrefs.SetString("CurrentSlot", "Slot 2");
    }

    public void SetSlot3() {
        PlayerPrefs.SetString("CurrentSlot", "Slot 3");
    }

    public void SaveGame() {
        SaveManager.triggerSave();
        saveMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
