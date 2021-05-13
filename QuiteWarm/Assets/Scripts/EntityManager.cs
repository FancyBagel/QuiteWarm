using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] obstacles;

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += EnemyRespawn;
        PlayerHealth.OnPlayerDeath += ObstacleRespawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= EnemyRespawn;
        PlayerHealth.OnPlayerDeath -= ObstacleRespawn;
    }

    void EnemyRespawn() {
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<EntityHealth>().ActivateEntity();
        }
    }

    void ObstacleRespawn() {
        foreach (GameObject obstacle in obstacles) {
            obstacle.GetComponent<EntityHealth>().ActivateEntity();
        }
    }
}
