using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform zombieSpawnPoint;
    //public GameObject zombiePrefab;
    //public GameObject startingZombie;
    public GameObject zombieBoi1;
    public GameObject zombieBoi2;
    public GameObject turretBoi;

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += EnemyRespawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= EnemyRespawn;
    }

    void EnemyRespawn() {
        zombieBoi1.GetComponent<ZombieHealth>().ActivateZombie();
        zombieBoi2.GetComponent<ZombieHealth>().ActivateZombie();
        turretBoi.GetComponent<ZombieHealth>().ActivateZombie();
    }
}
