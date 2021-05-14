using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntitySaver : MonoBehaviour
{
    public EntityHealth healthManager;
    public Repositioner respManager;
    public GameObject entityBoi;

    // void OnEnable() {
    //     SaveManager.OnGameSave += SaveEntityInfo;
    //     SaveManager.OnGameLoad += LoadEntityInfo;
    // }

    // void OnDisable() {
    //     SaveManager.OnGameSave -= SaveEntityInfo;
    //     SaveManager.OnGameLoad -= LoadEntityInfo;
    // }

    void SaveEntityInfo() {
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

        string entityName = this.name;

        savePath+="/"+entityName+"/";

        PlayerPrefs.SetFloat(savePath + "pos_x", transform.position.x);
        PlayerPrefs.SetFloat(savePath + "pos_y", transform.position.y);

        PlayerPrefs.SetInt(savePath + "health", healthManager.health);
        PlayerPrefs.SetInt(savePath + "maxHealth", healthManager.maxHealth);

        // PlayerPrefs.SetFloat(savePath + "respawn_pos_x", respManager.respawnPoint.position.x);
        // PlayerPrefs.SetFloat(savePath + "respawn_pos_y", respManager.respawnPoint.position.y);

        int act = 1;

        if (entityBoi.activeInHierarchy == false) {
            act = 0;
        }

        PlayerPrefs.SetInt(savePath + "is_active", act);
    }

    void LoadEntityInfo() {

        entityBoi.SetActive(true);
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

        string entityName = this.name;

        savePath+="/"+entityName+"/";

        Vector2 pos;

        pos.x = PlayerPrefs.GetFloat(savePath + "pos_x", 0);
        pos.y = PlayerPrefs.GetFloat(savePath + "pos_y", 0);
        
        transform.position = pos;

        healthManager.health = PlayerPrefs.GetInt(savePath + "health", 5);
        healthManager.maxHealth = PlayerPrefs.GetInt(savePath + "maxHealth", 5);

        pos.x = PlayerPrefs.GetFloat(savePath + "respawn_pos_x", 0);
        pos.y = PlayerPrefs.GetFloat(savePath + "respawn_pos_y", 0);

        // respManager.respawnPoint.position = pos;

        int act = PlayerPrefs.GetInt(savePath + "is_active");

        if (act == 1) {
            entityBoi.SetActive(true);
        } else {
            entityBoi.SetActive(true);
        }
    }
}
