using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        // if (!collision.gameObject.CompareTag("FamiliarBullet")) {
            Destroy(gameObject);
        //}
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

