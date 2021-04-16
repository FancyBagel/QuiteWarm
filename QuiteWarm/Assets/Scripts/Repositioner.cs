using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repositioner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject entityBoi;
    public Transform respawnPoint;

    public void Reposition()
    {
        entityBoi.transform.position = respawnPoint.position;
    }
}
