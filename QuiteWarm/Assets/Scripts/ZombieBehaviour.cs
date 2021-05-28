using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
	public float rotationSpeed = 90;
	public float rotationDelay = 3;
	public float moveSpeed;
	public float hearingDistance = 10;
	public float viewDistance = 5;
	public float fieldOfView = 30;
	public LayerMask layerMask;

	private Transform player;
    private float rotation = 0;
	private float rotationCD = 0;

	public MonoBehaviour aStar;
	public MonoBehaviour AIDestinationSetter;
	public Transform target;

    // Start is called before the first frame update
    void Start()
    {    
		player = GameObject.Find("Player").transform;

        transform.Rotate(Vector3.forward, Random.Range(-180, 180));
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateMovement();   
    }

    void UpdateMovement()
    {
		Vector2 lookDir = player.position - transform.position;
		float lookAngle = Vector2.Angle(transform.up, lookDir);
		RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, lookDir, viewDistance, layerMask);

		bool targetFound = false;

    	if (lookAngle <= fieldOfView && raycastHit2D.collider != null && raycastHit2D.collider.tag == "Player") {
			target.position = player.position;
        	// ai.canMove = true;
			aStar.enabled = true;
			AIDestinationSetter.enabled = true;
    	}
    	else {
			float dist = hearingDistance;
			foreach(Transform obj in SoundDecoyScript.decoys) {
				float d = (obj.position - transform.position).sqrMagnitude;
				if (d < dist) {
					dist = d;
					target.position = obj.position;
					targetFound = true;
				}
			}

			if (!targetFound) {
				foreach(Transform obj in SoundDecoyScript.footsteps) {
					float d = (obj.position - transform.position).sqrMagnitude;
					if (d < dist) {
						dist = d;
						target.position = obj.position;
						targetFound = true;
					}
				}
			}

			if (targetFound) {
				aStar.enabled = true;	
				AIDestinationSetter.enabled = true;
			}
			else {
				aStar.enabled = false;
				AIDestinationSetter.enabled = false;
				Wander();
			}
    	}
    }

	void Wander() {
		if (rotationCD <= 0) {
			rotation = Random.Range(-rotationSpeed, rotationSpeed);
			rotationCD = rotationDelay;
		}
			
		rotationCD -= Time.deltaTime;

		transform.rotation = transform.rotation * Quaternion.Euler(Vector3.forward * rotation * Time.deltaTime);
		rb.velocity = transform.up * moveSpeed;
	}
}