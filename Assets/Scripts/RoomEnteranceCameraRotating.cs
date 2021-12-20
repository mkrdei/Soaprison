using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RoomEnteranceCameraRotating : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enterances;
    [SerializeField]
    private float cameraSpeed;

    public Vector3[] followOffsets;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer cinemachineTransposer;

    RoomEnterance roomEnterance;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        cinemachineTransposer.m_FollowOffset = followOffsets[0];

        roomEnterance = GameObject.FindGameObjectWithTag("Player").GetComponent<RoomEnterance>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<enterances.Length; i++)
        {
            if(roomEnterance.lastRoomEntered == enterances[i] && followOffsets != null)
            {
                Debug.Log("Last room entered: " + roomEnterance.lastRoomEntered);
                cinemachineTransposer.m_FollowOffset = Vector3.MoveTowards(cinemachineTransposer.m_FollowOffset, followOffsets[i], cameraSpeed*Time.deltaTime);
            }
        }
    }
}
