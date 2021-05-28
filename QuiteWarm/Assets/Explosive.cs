using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float fuse = 2f;
    public GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        fuse -= Time.deltaTime;
        if (fuse <= 0) {
            Instantiate(explosion, transform.position, transform.rotation);  
            Destroy(gameObject);
        }
    }
}
