using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public delegate void PlayerDeathAction();
    public static event PlayerDeathAction OnPlayerDeath;

    public float iFramesMax = 100f;
    public float iFrames = 0f; 

    void Update() {

        if (health > numOfHearts) {
            health = numOfHearts;
        }
        
        for (int i = 0; i < hearts.Length; i++) {

            if (i < health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0) {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
                health = numOfHearts;
            }
        }
    }

    void FixedUpdate()
    {
        iFrames -= Time.timeScale;
    }


    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 8) {// bullets or enemies
            if (iFrames <= 0) {
                --health;
                iFrames = iFramesMax;
            }
        }
    }
}
