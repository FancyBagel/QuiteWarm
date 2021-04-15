using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireCooldown = 50f;
    public bool isAutomatic = false;
    public float spreadAngle = 0;
    public int bulletCount = 1;

    private float cd = 50f;

    // Update is called once per frame
    void Update()
    {
            if(cd <= 0) {
                for (int i = 0; i < bulletCount; i++)
                    Shoot();
                cd = fireCooldown;
            }
        cd -= Time.timeScale;
    }

    void Shoot() {
        foreach (Transform firePoint in firePoints)
        {
            Vector3 spread = new Vector3(0, 0, Random.Range(-spreadAngle, spreadAngle));
            Quaternion rotation = Quaternion.Euler(firePoint.rotation.eulerAngles + spread);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }
}