using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    private PipeController pipeController;
    private Door door;
    // Start is called before the first frame update
    void Start()
    {
        pipeController = GetComponentInChildren<PipeController>();
        door = GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.open)
        {
            pipeController.isBroken = true;
        }   
    }
}
