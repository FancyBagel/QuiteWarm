using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    
    public PlayerHealth healthManager;
    public PlayerRespawn respManager;

    void OnEnable() {
        SaveManager.OnGameSave += SavePlayerInfo;
        SaveManager.OnGameLoad += LoadPlayerInfo;
    }

    void OnDisable() {
        SaveManager.OnGameSave -= SavePlayerInfo;
        SaveManager.OnGameLoad -= LoadPlayerInfo;
    }

    void SavePlayerInfo() {
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

        savePath+="/Player/";

        PlayerPrefs.SetFloat(savePath + "pos_x", transform.position.x);
        PlayerPrefs.SetFloat(savePath + "pos_y", transform.position.y);

        PlayerPrefs.SetInt(savePath + "health", healthManager.health);
        PlayerPrefs.SetInt(savePath + "numOfHearts", healthManager.numOfHearts);

        PlayerPrefs.SetFloat(savePath + "respawn_pos_x", respManager.respawnPoint.x);
        PlayerPrefs.SetFloat(savePath + "respawn_pos_y", respManager.respawnPoint.y);
    }

    void LoadPlayerInfo() {
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

        savePath+="/Player/";

        Vector2 pos;

        pos.x = PlayerPrefs.GetFloat(savePath + "pos_x", 0);
        pos.y = PlayerPrefs.GetFloat(savePath + "pos_y", 0);
        
        transform.position = pos;

        healthManager.health = PlayerPrefs.GetInt(savePath + "health", 3);
        healthManager.numOfHearts = PlayerPrefs.GetInt(savePath + "numOfHearts", 3);

        respManager.respawnPoint.x = PlayerPrefs.GetFloat(savePath + "respawn_pos_x", 0);
        respManager.respawnPoint.y = PlayerPrefs.GetFloat(savePath + "respawn_pos_y", 0);
    }


}
