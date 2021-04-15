using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public GameObject zombieBoi;
    public Transform zombieSpawnPoint;
    public HealthbarBehaviour Healthbar;

    public void ActivateZombie() {
        health = maxHealth;
        Healthbar.SetHealth(health, maxHealth);
        zombieBoi.transform.position = new Vector2(zombieSpawnPoint.position.x, zombieSpawnPoint.position.y);
        zombieBoi.SetActive(true);
    }

    void Start() {
        Healthbar.SetHealth(health, maxHealth);
    }

    void Update()
    {
        if (health <= 0) {
            zombieBoi.SetActive(false);

        }
        
    }
    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer == 6) {// bullets or enemies
            --health;
            Healthbar.SetHealth(health, maxHealth);
        }
    }
}
