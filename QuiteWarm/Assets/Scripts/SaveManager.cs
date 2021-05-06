using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public delegate void GameSaveAction();
    public static event GameSaveAction OnGameSave;

    public delegate void GameLoadAction();
    public static event GameLoadAction OnGameLoad;

    public static void triggerSave() {
        OnGameSave();
    }




    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
