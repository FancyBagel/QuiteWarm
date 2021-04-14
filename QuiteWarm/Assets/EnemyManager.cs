using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform zombieSpawnPoint;
    //public GameObject zombiePrefab;
    //public GameObject startingZombie;
    public GameObject zombieBoi;

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += EnemyRespawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= EnemyRespawn;
    }

    void EnemyRespawn() {
        zombieBoi.GetComponent<ZombieHealth>().ActivateZombie();
    }
}
