using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public GameObject zombieBoi;
    public Transform zombieSpawnPoint;

    public Healthbar healthBar;

    public void Start() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void ActivateZombie() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        zombieBoi.transform.position = new Vector2(zombieSpawnPoint.position.x, zombieSpawnPoint.position.y);
        zombieBoi.SetActive(true);
        AstarPath.active.Scan();
    }

    void Update()
    {
        if (health <= 0) {
            zombieBoi.SetActive(false);
            AstarPath.active.Scan();

        }
        
    }
    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer == 6) {// bullets or enemies
            --health;
            healthBar.SetHealth(health);
        }
    }
}
