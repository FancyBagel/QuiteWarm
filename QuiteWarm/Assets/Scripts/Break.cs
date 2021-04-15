using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int HP = 3;

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer == 6) {// bullets
            --HP;
            if (HP <= 0) {
                Destroy(gameObject);
                AstarPath.active.Scan();
            }
        }
    }
}
