using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterance : MonoBehaviour
{
    public GameObject lastRoomEntered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "RoomEnterance")
        {
            lastRoomEntered = col.gameObject;
        }
    }
}
