using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform zombieSpawnPoint;
    public GameObject zombiePrefab;

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += EnemyRespawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= EnemyRespawn;
    }

    void EnemyRespawn() {
        GameObject zombie = Instantiate(zombiePrefab, zombieSpawnPoint.position, zombieSpawnPoint.rotation);
    }
}
