using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 respawnPoint;

    void Start() {
        respawnPoint = new Vector2(0,0);
    }

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += Respawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= Respawn;
    }

    void Respawn() {
        rb.velocity = new Vector2(0,0);
        rb.position = respawnPoint;
        
    }
}
