using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraView : MonoBehaviour
{
    private CinemachineBrain cinemachineBrain;
    public CinemachineVirtualCamera fpsCamera, tpsCamera;
    public bool fps, tps;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeView();
    }
    private void ChangeView()
    {
        if (Input.GetButtonDown("View"))
        {
            fps = tps;
            tps = !fps;
            Debug.Log("Change View");
            if (fps)
            {
                ChangeViewToFPS();
            }
            if (tps)
            {
                ChangeViewToTPS();
            }
                
        }
    }
    private void ChangeViewToFPS()
    {
        fpsCamera.Priority = tpsCamera.Priority + 1;
    }
    private void ChangeViewToTPS()
    {
        tpsCamera.Priority = fpsCamera.Priority + 1;
    }
}
