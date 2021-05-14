using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom : MonoBehaviour
{
    private EntityManager entityManager;
    void OnTriggerEnter2D(Collider2D collision) {
         if (collision.gameObject.tag == "Player") {
            Camera.main.transform.position = transform.parent.position + new Vector3(0, 0, -10);

            AstarPath.active.data.gridGraph.center = transform.parent.position;
            AstarPath.active.Scan();

            if (!entityManager.cleared && !entityManager.entered) {
                entityManager.EnemyRespawn();
                entityManager.ObstacleRespawn();
            }
            entityManager.entered = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        entityManager = transform.parent.gameObject.GetComponent<EntityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
