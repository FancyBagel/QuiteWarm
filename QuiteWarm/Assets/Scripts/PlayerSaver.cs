using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    
    public PlayerHealth healthManager;
    public PlayerRespawn respManager;
    public int lastClearedRoom = 0;

    void Start () {
        int nowLoadingGame = PlayerPrefs.GetInt("Game_Starting_Loading", 0);

        if (nowLoadingGame == 1) { //game is loading from save
            LoadPlayerInfo();
        }
    }

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

        int currentSeed = PlayerPrefs.GetInt("CurrentSeed");

        PlayerPrefs.SetInt(savePath + "/Seed", currentSeed);

        savePath+="/Player/";

        PlayerPrefs.SetInt(savePath + "health", healthManager.health);
        PlayerPrefs.SetInt(savePath + "numOfHearts", healthManager.numOfHearts);
        PlayerPrefs.SetInt(savePath + "lastClearedRoom", lastClearedRoom);

        PlayerPrefs.SetFloat(savePath + "respawn_pos_x", respManager.respawnPoint.x);
        PlayerPrefs.SetFloat(savePath + "respawn_pos_y", respManager.respawnPoint.y);

        PlayerPrefs.SetFloat(savePath + "camera_respawn_pos_x", respManager.respawnCamera.x);
        PlayerPrefs.SetFloat(savePath + "camera_respawn_pos_y", respManager.respawnCamera.y);

       
    }

    void LoadPlayerInfo() {
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

        savePath+="/Player/";

        healthManager.health = PlayerPrefs.GetInt(savePath + "health", 3);
        healthManager.numOfHearts = PlayerPrefs.GetInt(savePath + "numOfHearts", 3);
        lastClearedRoom = PlayerPrefs.GetInt(savePath + "lastClearedRoom", 0);

        respManager.respawnPoint.x = PlayerPrefs.GetFloat(savePath + "respawn_pos_x", 0);
        respManager.respawnPoint.y = PlayerPrefs.GetFloat(savePath + "respawn_pos_y", 0);

        // Vector2 pos;

        // pos.x = respManager.respawnPoint.x;
        // pos.y = respManager.respawnPoint.y;
        
        // transform.position = pos;

        respManager.respawnCamera.x = PlayerPrefs.GetFloat(savePath + "camera_respawn_pos_x", respManager.respawnCamera.x);
        respManager.respawnCamera.y = PlayerPrefs.GetFloat(savePath + "camera_respawn_pos_y", respManager.respawnCamera.y);
    }


}
