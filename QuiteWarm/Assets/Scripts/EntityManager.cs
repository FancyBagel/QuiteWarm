using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject[] doors;

    public bool cleared = false;
    public bool entered = false;

    public Vector3 respawnPoint;

    void Start() {
        EnemyDisable();
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
        cleared = true;
        GameObject.Find("Player").GetComponent<PlayerRespawn>().respawnPoint = respawnPoint + transform.position;
        GameObject.Find("Player").GetComponent<PlayerRespawn>().respawnCamera = transform.position;
        openDoors();
    }

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += ExitRoom;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= ExitRoom;
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
}
