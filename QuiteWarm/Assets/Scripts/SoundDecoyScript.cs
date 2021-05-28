using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDecoyScript : MonoBehaviour
{
    public float timeLasting = 5;
    public bool isDecoy = false;
    public bool isFootstep = false;
   
    public bool isManager = false;
    public AudioSource audio;
    public AudioClip clip;

    public static HashSet<Transform> footsteps = new HashSet<Transform>();
    public static HashSet<Transform> decoys = new HashSet<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        if (!isManager) {
            audio.PlayOneShot(clip, 1);

            ParticleSystem exp = GetComponent<ParticleSystem>();
            exp.Play();
        }

        if (isDecoy)
            decoys.Add(transform);
        if (isFootstep)
            footsteps.Add(transform);

        Debug.Log(footsteps.Count);
    }

    // Update is called once per frame
    void Update()
    {
        audio.pitch = Time.timeScale;
        timeLasting -= Time.deltaTime;
        if (timeLasting <= 0 && !isManager)
            Despawn();
    }

    void OnEnable() {
        PlayerHealth.OnPlayerDeath += Despawn;
    }

    void OnDisable() {
        PlayerHealth.OnPlayerDeath -= Despawn;
    }

    void Despawn() {
       if (isDecoy)
            decoys.Remove(transform);
       if (isFootstep)
            footsteps.Remove(transform);

       Destroy(gameObject);
    }
}
