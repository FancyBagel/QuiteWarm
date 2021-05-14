using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void SelectSlot1() {
        PlayerPrefs.SetInt("Game_Starting_Loading", 1);
        PlayerPrefs.SetString("CurrentSlot", "Slot 1");
        int currentSeed = PlayerPrefs.GetInt("Slot 1/Seed");
        PlayerPrefs.SetInt("CurrentSeed", currentSeed);
        SceneManager.LoadScene("Main");
    }

    public void SelectSlot2() {
        PlayerPrefs.SetInt("Game_Starting_Loading", 1);
        PlayerPrefs.SetString("CurrentSlot", "Slot 2");
        int currentSeed = PlayerPrefs.GetInt("Slot 2/Seed");
        PlayerPrefs.SetInt("CurrentSeed", currentSeed);
        SceneManager.LoadScene("Main");
    }

    public void SelectSlot3() {
        PlayerPrefs.SetInt("Game_Starting_Loading", 1);
        PlayerPrefs.SetString("CurrentSlot", "Slot 3");
        int currentSeed = PlayerPrefs.GetInt("Slot 3/Seed");
        PlayerPrefs.SetInt("CurrentSeed", currentSeed);
        SceneManager.LoadScene("Main");
    }
}
