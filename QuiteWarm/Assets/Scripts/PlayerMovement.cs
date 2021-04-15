using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 moveDirection;
    private Vector2 mousePos;

    //private float slowMo = 0.1f;

    public float scale = 0.02f;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        AdjustTime();
    }

    void FixedUpdate() {
        //fiza
        Move();
        Rotate();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void AdjustTime() {
        // = rb.velocity.magnitude / moveSpeed;

        if (rb.velocity.magnitude == 0.0f) {
            scale = 0.02f;
        }
        else {
            scale +=0.002f;
        }
        Time.timeScale = Mathf.Min(scale, 1);
        Time.fixedDeltaTime = 0.005f * Time.timeScale;
    }

    void Move() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Rotate() {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
