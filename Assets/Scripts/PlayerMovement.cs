using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private CameraView cameraView;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer cinemachineTransposer;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float maxAngularVelocity;

    private Vector3 desiredMoveDirection;

    private float clampMovementRadius = 1;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraView = mainCamera.GetComponent<CameraView>();
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (cameraView.fps)
        {
            Vector3 forward = cinemachineVirtualCamera.transform.forward;
            Vector3 right = cinemachineVirtualCamera.transform.right;

            //project forward and right vectors on the horizontal plane (y = 0)
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            //this is the direction in the world space we want to move:
            desiredMoveDirection = forward * -horizontalAxis + right * verticalAxis;
        }
        if (cameraView.tps)
        {
            desiredMoveDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        }
        

        //now we can apply the movement:
        rb.angularVelocity = Vector3.ClampMagnitude(desiredMoveDirection, clampMovementRadius)* horizontalSpeed;
    }
}
