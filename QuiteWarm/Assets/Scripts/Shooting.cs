using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireCooldown = 50f;
    public bool isAutomatic = false;
    public float spreadAngle = 0;
    public int bulletCount = 1;
    public bool isEnemy = false;

    private float cd = 0f;

    public AudioSource audio;
    public AudioClip clip;

    void Start()
    {
        cd = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        audio.pitch = Time.timeScale;
        //nk jakis min bo dzwiek jest giga cursed jak jest bardzo powoli
        if ((!isAutomatic && Input.GetButtonDown("Fire1")) || (isAutomatic && Input.GetButton("Fire1")) || isEnemy) {
            if(cd <= 0) {
                audio.PlayOneShot(clip, 1);
                for (int i = 0; i < bulletCount; i++)
                    Shoot();
                cd = fireCooldown;
            }
        }
    }
    void FixedUpdate()
    {
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
