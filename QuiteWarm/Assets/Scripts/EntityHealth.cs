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
    bool isShowing;

    public Healthbar healthBar;

    public GameObject onHit;

    public void Start() {
        health = maxHealth;
        if (hasHealthBar) {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetActive(false);
        }
    }

    public void ActivateEntity() {
        health = maxHealth;
        if (hasHealthBar) {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetActive(false);
        }
        if (isMobile) {
            entityBoi.GetComponent<Repositioner>().Reposition();
        }
        entityBoi.SetActive(true);
        AstarPath.active.Scan();
    }

    void Update()
    {
        isShowing = (health < maxHealth);

        if (healthBar) {
            healthBar.SetHealth(health);
            healthBar.SetActive(isShowing);
        }
        

        if (health <= 0) {
            GameObject weapons = GameObject.Find("WeaponHolder");
            WeaponSwitching weaponManager = weapons.GetComponent<WeaponSwitching>();
            weaponManager.addAmmoToRandWeapon(20);
            entityBoi.SetActive(false);
            AstarPath.active.Scan();

        }
        
    }
    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer == 6) {// bullets
            --health;
            Instantiate(onHit, collision.GetContact(0).point, Quaternion.identity);
            if (healthBar) {
                healthBar.SetHealth(health);
                healthBar.SetActive(true);
            }
        }
    }
}
