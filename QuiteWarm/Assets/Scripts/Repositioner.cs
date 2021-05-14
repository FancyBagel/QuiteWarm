using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repositioner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject entityBoi;
    private Vector3 respawnPoint;

    public void SaveLocation() {
        respawnPoint = entityBoi.transform.position;
    }

    public void Reposition()
    {
        entityBoi.transform.position = respawnPoint;
    }
}
