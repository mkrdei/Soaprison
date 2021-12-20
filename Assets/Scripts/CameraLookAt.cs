using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraLookAt : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    public Transform[] movingObjects;
    [HideInInspector]
    public Transform playerPos;
    private bool cameraMoving;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (virtualCamera.LookAt == playerPos)
            cameraMoving = false;
        else
            cameraMoving = true;

        try
        {
            foreach (Transform movingObject in movingObjects)
            {
                if (movingObject.GetComponent<MovingObject>().isMoving)
                {
                    virtualCamera.m_LookAt = movingObject.transform;
                    break;
                }
                else
                {
                    virtualCamera.m_LookAt = playerPos;
                }
            }


        }
        catch
        {

        }
        
    }
}
