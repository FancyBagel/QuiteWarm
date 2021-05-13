using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{

    private float cd = 0f;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        cd = Random.Range(50f, 150f);
    }

    // Update is called once per frame
    void Update()
    {
        audio.pitch = 0.5f + Time.timeScale / 2;
        if(cd <= 0) {
            audio.Play(0);
            cd = Random.Range(50f, 150f);
        }
    }

    void FixedUpdate()
    {
        cd -= Time.timeScale;
    }
}
