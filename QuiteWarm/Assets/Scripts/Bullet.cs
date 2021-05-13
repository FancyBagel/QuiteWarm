using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isDestructible = true;
    
    void OnCollisionEnter2D(Collision2D collision) {
         if (isDestructible) {
            Destroy(gameObject);
        }
    }
    
    void OnEnable() {
        PlayerHealth.OnPlayerDeath += DespawnBullet;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= DespawnBullet;
    }
   
   void DespawnBullet() {
       Destroy(gameObject);
   }
   
}

