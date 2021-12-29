using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColliderController : MonoBehaviour
{
    private SoapStats soapStats;
    SurfaceDetection[] surfaceDetections;
    string XSurface, YSurface, ZSurface, activeSurface;
    [SerializeField]
    private float reduceAmount;
    // Start is called before the first frame update
    void Start()
    {
        soapStats = GetComponent<SoapStats>();
        surfaceDetections = GetComponentsInChildren<SurfaceDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        XSurface = surfaceDetections[0].surfaceName;
        YSurface = surfaceDetections[1].surfaceName;
        ZSurface = surfaceDetections[2].surfaceName;
        Debug.Log("XSurface: " + XSurface + "    YSurface: " + YSurface + " ZSurface: " + ZSurface);
        if (transform.localScale.x * transform.localScale.y * transform.localScale.z > 0f) { 
            if (XSurface != "")
            {
                transform.localScale = new Vector3(transform.localScale.x - reduceAmount * Time.deltaTime, transform.localScale.y, transform.localScale.z);
            }
            if(YSurface != "")
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - reduceAmount * Time.deltaTime, transform.localScale.z);
            }
            if (ZSurface != "")
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - reduceAmount * Time.deltaTime);
            }
            
        }
        else
        {
            GetComponent<SoapStats>().alive = false; 
        }

    }
    private void OnTriggerEnter(Collider other)
    { 
            if (other.tag == "Water")
                soapStats.wet = true;
            if (other.tag == "PassArea" && transform.tag == "Player")
                GameObject.Find("Game Controller").GetComponent<GameController>().levelPassed = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
            soapStats.wet = false;
    }
}
