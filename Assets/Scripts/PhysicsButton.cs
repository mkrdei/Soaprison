using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public bool stayPressed;
    public bool reverseButton;
    public Rigidbody buttonTopRigid;
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public AudioSource pressedSound;
    public AudioSource releasedSound;
    public Collider[] CollidersToIgnore;
    public UnityEvent onPressed;
    public UnityEvent onReleased;
    

    // Start is called before the first frame update
    void Start()
    {
        Collider localCollider = GetComponent<Collider>();
        if (localCollider != null)
        {
            Physics.IgnoreCollision(localCollider, buttonTop.GetComponentInChildren<Collider>());

            foreach (Collider singleCollider in CollidersToIgnore)
            {
                Physics.IgnoreCollision(localCollider, singleCollider);
            }
        }

        if (transform.eulerAngles != Vector3.zero)
        {
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        }
        else
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else
            buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
        {
            buttonTop.transform.position = new Vector3(buttonTop.transform.position.x, buttonLowerLimit.position.y, buttonTop.transform.position.z);
        }


        

        if (!reverseButton)
        {
            if (buttonTop.position.y-buttonLowerLimit.position.y <= threshHold)
                {
                isPressed = true;
                
                }
            else
                isPressed = false;
            }
        else
        {
            if (buttonTop.position.y - buttonLowerLimit.position.y <= threshHold)
                isPressed = false;
            else
                isPressed = true;
        }

        if (isPressed && prevPressedState != isPressed)
            Pressed();
        if (!isPressed && prevPressedState != isPressed)
            Released();
    }

    // void FixedUpdate(){
    //     Vector3 localVelocity = transform.InverseTransformDirection(buttonTop.GetComponent<Rigidbody>().velocity);
    //     Rigidbody rb = buttonTop.GetComponent<Rigidbody>();
    //     localVelocity.x = 0;
    //     localVelocity.z = 0;
    //     rb.velocity = transform.TransformDirection(localVelocity);
    // }

    void Pressed()
    {
        if (stayPressed)
        {
            buttonTopRigid.isKinematic = true;
            buttonTop.position = new Vector3(buttonTop.position.x, buttonLowerLimit.position.y, buttonTop.position.z);
        }
        prevPressedState = isPressed;
        /*pressedSound.pitch = 1;
        pressedSound.Play();*/
        onPressed.Invoke();
    }

    void Released()
    {
        prevPressedState = isPressed;
        /*releasedSound.pitch = Random.Range(1.1f, 1.2f);
        releasedSound.Play();*/
        onReleased.Invoke();
    }

    public void DelayedRefresh()
    {
        stayPressed = false;
        buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        buttonTopRigid.isKinematic = false;
        isPressed = false;
        stayPressed = true;
    }
    public void InvokingDelayedRefresh()
    {
        Invoke("DelayedRefresh()", 1f);
    }
}