using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScaling : MonoBehaviour
{
    public bool wet;
    SurfaceDetection[] surfaceDetections;
    string XSurface, YSurface, ZSurface, activeSurface;
    [SerializeField]
    private float reduceAmount;
    // Start is called before the first frame update
    void Start()
    {
        surfaceDetections = GetComponentsInChildren<SurfaceDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        XSurface = surfaceDetections[0].surfaceName;
        YSurface = surfaceDetections[1].surfaceName;
        ZSurface = surfaceDetections[2].surfaceName;
        Debug.Log("XSurface: " + XSurface + "    YSurface: " + YSurface + " ZSurface: " + ZSurface);
        if (transform.localScale.x * transform.localScale.y * transform.localScale.z > 0) { 
            if (XSurface != "")
            {
                transform.localScale = new Vector3(transform.localScale.x - reduceAmount * Time.deltaTime, transform.localScale.y, transform.localScale.z);
            }
            else if(YSurface != "")
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - reduceAmount * Time.deltaTime, transform.localScale.z);
            }
            else if (ZSurface != "")
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - reduceAmount * Time.deltaTime);
            }
            else
            {
                
            }
        }
        else
        {
            Destroy(transform.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Water")
            wet = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
            wet = false;
    }
}
