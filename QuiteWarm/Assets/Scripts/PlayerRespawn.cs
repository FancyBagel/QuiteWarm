using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector3 respawnPoint;
    public Vector3 respawnCamera;


    void OnEnable() {
        PlayerHealth.OnPlayerDeath += Respawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= Respawn;
    }

    void Respawn() {
        rb.velocity = new Vector2(0,0);
        rb.position = respawnPoint;
        Camera.main.transform.position = respawnCamera;
    }
}
