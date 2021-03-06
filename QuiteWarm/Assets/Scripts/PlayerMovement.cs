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

    public GameObject footstep;

    private float noise = 0;
    private bool sneak = false;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        MakeNoise();
    }

    void MakeNoise() {
        if (sneak)
            noise += rb.velocity.magnitude * Time.deltaTime / 4;
        else
            noise += rb.velocity.magnitude * Time.deltaTime;

        if (noise >= 2) {
            noise = 0;
            Instantiate(footstep, transform);
        }
    }

    void FixedUpdate() {
        //fiza
        AdjustTime();
        Move();
        Rotate();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        sneak = Input.GetButton("Fire3");

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void AdjustTime() {
        // = rb.velocity.magnitude / moveSpeed;
        if (Time.timeScale == 0f)
            return;

        if (rb.velocity.magnitude == 0.0f) {
            scale = 0.1f;
        }
        else {
            scale +=0.02f;
        }
        if (sneak) {
            Time.timeScale = Mathf.Min(scale, 1);
        }
        else {
            Time.timeScale = Mathf.Min(scale, 1);
        }
        Time.fixedDeltaTime = 0.005f * Time.timeScale;
    }

    void Move() {
        if (sneak)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed / 2, moveDirection.y * moveSpeed / 2);
        else
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //TODO change to add force for smoother movement

    }

    void Rotate() {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
