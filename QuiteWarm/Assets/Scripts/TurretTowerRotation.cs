using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTowerRotation : MonoBehaviour
{

    public Rigidbody2D self;
    public Rigidbody2D target;

    void Start() {
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 lookDir = target.position - self.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        self.rotation = angle;
        
    }
}
