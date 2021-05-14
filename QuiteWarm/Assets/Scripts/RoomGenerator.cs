using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject[] nextRooms;
    public GameObject lastRoom;
    public Vector3 spawnLocation;

    public int roomsToGenerate = 5;
    public bool startingRoom = false;
    public int startingSeed = 1;
    public bool setSeed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (startingRoom) {
            GenerateRoom();
            if (setSeed)
                Random.seed = startingSeed;
        }
    }

    public void GenerateRoom() 
    {
        if (roomsToGenerate >= 1) {
            int roomNumber = Random.Range(0, nextRooms.Length);
            GameObject generated = Instantiate(nextRooms[roomNumber], transform.position + spawnLocation, Quaternion.identity);
            generated.GetComponent<RoomGenerator>().roomsToGenerate = roomsToGenerate - 1;
            generated.GetComponent<RoomGenerator>().GenerateRoom();
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
