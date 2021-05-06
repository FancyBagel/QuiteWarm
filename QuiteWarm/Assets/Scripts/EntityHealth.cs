using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public bool isMobile;
    public bool hasHealthBar;
    public int health;
    public int maxHealth;
    public GameObject entityBoi;

    public Healthbar healthBar;

    public void Start() {
        health = maxHealth;
        if (hasHealthBar)
            healthBar.SetMaxHealth(maxHealth);
    }

    public void ActivateEntity() {
        health = maxHealth;
        if (hasHealthBar)
            healthBar.SetMaxHealth(maxHealth);
        if (isMobile) {
            entityBoi.GetComponent<Repositioner>().Reposition();
        }
        entityBoi.SetActive(true);
        AstarPath.active.Scan();
    }

    void Update()
    {
        if (healthBar)
            healthBar.SetHealth(health);

        if (health <= 0) {
            entityBoi.SetActive(false);
            AstarPath.active.Scan();

        }
        
    }
    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer == 6) {// bullets
            --health;
            if (healthBar)
                healthBar.SetHealth(health);
        }
    }
}
