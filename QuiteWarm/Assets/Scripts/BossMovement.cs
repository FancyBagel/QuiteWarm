using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float currentCooldown = 0;
    public float phaseCooldown = 300000000f;
    public Rigidbody2D bossBody;
    private GameObject player;
    public float dashSpeed = 10f;
    private float currentSpeed = 0;
    public float dashTime = 100f;
    private float dashStopCooldown = 0;
    Vector2 dashVector;
    public GameObject weapons;
    public Animator animator;

    void Start()
    {
        currentCooldown = phaseCooldown / 2f;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentCooldown <= 0) {
            int weaponToBeGiven = Random.Range(0, 3);

            selectWeapon(weaponToBeGiven);
            animator.SetInteger("Attack mode", weaponToBeGiven);

            if (weaponToBeGiven == 2) 
                setupDash();

            currentCooldown = phaseCooldown;
        }
    }

    void FixedUpdate()
    {
        currentCooldown -= Time.timeScale;
        dashStopCooldown -= Time.timeScale;
        Move();
    }

    void setupDash() {
        dashStopCooldown = dashTime;
        dashVector = player.transform.position - bossBody.transform.position;
        currentSpeed = dashSpeed;
    }

    void selectWeapon(int no) {
        int i = 0;
        foreach (Transform weapon in weapons.transform)
        {
            if (i == no)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            
            i++;
        }
    }

    void fixRotation() {
        Vector2 lookDir = player.transform.position - bossBody.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        bossBody.rotation = angle;
    }

    void Move() {
        if (dashStopCooldown >=0 ) {
            bossBody.velocity = new Vector2(dashVector.x * currentSpeed, dashVector.y * currentSpeed);
        }
        else {
            fixRotation();
            bossBody.velocity = new Vector2(0,0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.layer != 6) {// bullets
            dashStopCooldown /=2;
        }
    }
}
