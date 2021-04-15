using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireCooldown = 50f;

    private float cd = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if(cd <= 0) {
                Shoot();
                cd = fireCooldown;
            }
        }
        cd -= Time.timeScale;
    }

    void Shoot() {
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }
}
