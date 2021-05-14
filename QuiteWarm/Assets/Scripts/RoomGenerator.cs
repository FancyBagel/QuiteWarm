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
    public int roomNo = 0; 
    public int seedNow = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (startingRoom) {

            int nowLoadingGame = PlayerPrefs.GetInt("Game_Starting_Loading", 0);

            string savePath = "CurrentSeed";

            startingSeed = Random.seed;
            setSeed = true;

            if (nowLoadingGame == 1) { //game is loading from save
                
                startingSeed = PlayerPrefs.GetInt(savePath);
                setSeed = true;
            }

            if (setSeed)
                Random.seed = startingSeed;
            else 
                startingSeed = Random.seed;

            PlayerPrefs.SetInt(savePath, startingSeed);

            GenerateRoom();
        }
    }

    public void GenerateRoom() 
    {
        if (roomsToGenerate >= 1) {
            int roomNumber = Random.Range(0, nextRooms.Length);
            GameObject generated = Instantiate(nextRooms[roomNumber], transform.position + spawnLocation, Quaternion.identity);
            generated.GetComponent<RoomGenerator>().roomsToGenerate = roomsToGenerate - 1;
            generated.GetComponent<RoomGenerator>().roomNo = roomNo + 1;
            generated.GetComponent<RoomGenerator>().GenerateRoom();
        }
        else {
            Instantiate(lastRoom, transform.position + spawnLocation, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        seedNow = Random.seed;
    }
}
