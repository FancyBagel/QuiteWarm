using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject[] nextRooms;
    public GameObject lastRoom;
    public Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 5) >= 1) {
            int roomNumber = Random.Range(0, nextRooms.Length);
            Instantiate(nextRooms[roomNumber], transform.position + spawnLocation, Quaternion.identity);
        }
        else {
            Instantiate(lastRoom, transform.position + spawnLocation, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
