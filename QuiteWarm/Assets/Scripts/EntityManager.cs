using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityManager : MonoBehaviour
{
    public RoomGenerator roomGen;

    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject[] doors;

    public bool cleared = false;
    public bool entered = false;
    public bool lastRoom = false;

    public Vector3 respawnPoint;

    void Start() {
        EnemyDisable();

        int nowLoadingGame = PlayerPrefs.GetInt("Game_Starting_Loading", 0);

        if (nowLoadingGame == 1) { //game is loading from save
            string entityName = this.name;

            string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

            savePath+="/"+entityName+"/";

            int clear_int = PlayerPrefs.GetInt(savePath + "cleared", 0);

            if (clear_int == 1) {
                setClear();
            }
        }
    }

    void Update() {
        if (entered && !cleared)
            checkClear();
    }

    void checkClear() {
        foreach (GameObject enemy in enemies) {
            if (enemy.activeSelf)
                return;
        }
        setClear();
    }

    void setClear() {
        entered = true;
        cleared = true;
        GameObject.Find("Player").GetComponent<PlayerRespawn>().respawnPoint = respawnPoint + transform.position;
        GameObject.Find("Player").GetComponent<PlayerRespawn>().respawnCamera = transform.position;
        GameObject.Find("Player").GetComponent<PlayerSaver>().lastClearedRoom = roomGen.roomNo;
        openDoors();

        if (lastRoom) {
            SceneManager.LoadScene("Credits");
        }
    }

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += ExitRoom;
        SaveManager.OnGameSave += SaveRoomInfo;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= ExitRoom;
        SaveManager.OnGameSave -= SaveRoomInfo;
    }

    void openDoors() {
        foreach (GameObject door in doors) {
            door.SetActive(false);
        }
    }

    void closeDoors() {
        foreach (GameObject door in doors) {
            door.SetActive(true);
        }
    }

    public void EnemyRespawn() {
        closeDoors();
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<EntityHealth>().ActivateEntity();
        }
    }

    void ExitRoom() {
        entered = false;
        openDoors();
        foreach (GameObject enemy in enemies) {
            enemy.SetActive(false);
        }
    }

    void EnemyDisable() {
        openDoors();
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Repositioner>().SaveLocation();
            enemy.SetActive(false);
        }
    }

    public void ObstacleRespawn() {
        foreach (GameObject obstacle in obstacles) {
            obstacle.GetComponent<EntityHealth>().ActivateEntity();
        }
    }

    void SaveRoomInfo() {
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1");

        string entityName = this.name;

        savePath+="/"+entityName+"/";

        int clear_int = 0;

        if (cleared) {
            clear_int = 1;
        }

        PlayerPrefs.SetInt(savePath + "cleared", clear_int);
    }
}
