using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded;
    private Camera mainCamera;
    private CameraView cameraView;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer cinemachineTransposer;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField]
    private float horizontalSpeed, jumpSpeed;
    [SerializeField]
    private float maxAngularVelocity;

    private Vector3 desiredMoveDirection;

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

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            //this is the direction in the world space we want to move:
            desiredMoveDirection = forward * -horizontalAxis + right * verticalAxis;
        }
        if (cameraView.tps)
        {
            desiredMoveDirection = new Vector3(verticalAxis, 0, -horizontalAxis);
        }
        
        rb.angularVelocity = desiredMoveDirection* horizontalSpeed;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, transform.localScale.y))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

    }
}
