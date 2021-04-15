using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Rigidbody2D rb;

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += Respawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= Respawn;
    }

    void Respawn() {
        rb.velocity = new Vector2(0,0);
        rb.position = new Vector2(0,0);
    }
}
