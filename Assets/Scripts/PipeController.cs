using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PipeController : MonoBehaviour
{
    [SerializeField]
    public bool freezeXPos, freezeYPos, freezeZPos;

    public bool doorRelated;
    private Door relatedDoor;
    public float waterSpeed;
    public Vector3 scaleAmount;
    public Vector3 waterOffset;
    private Vector3 initialScale;
    private Vector3 initialPos;
    private Vector3 finalScale;
    private Vector3 scaleDifference;
    public GameObject water;
    private GameObject instantiatedWater;
    public bool isBroken;
    // Start is called before the first frame update
    void Start()
    {
        if (doorRelated)
        {
            relatedDoor = GetComponentInParent<Door>();
        }
        InstantiateWater();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (relatedDoor != null)
            if (relatedDoor.open)
                isBroken = true;
        if (isBroken)
        {
            instantiatedWater.transform.localScale = Vector3.MoveTowards(instantiatedWater.transform.localScale, finalScale, waterSpeed * Time.deltaTime);

            
            instantiatedWater.transform.position = Vector3.MoveTowards(instantiatedWater.transform.position, new Vector3(
                initialPos.x + (freezeXPos? 0: (initialScale.x + scaleAmount.x)/2),
                initialPos.y + (freezeYPos ? 0 : (initialScale.y + scaleAmount.y) / 2),
                initialPos.z + (freezeZPos ? 0 : (initialScale.z + scaleAmount.z) / 2)),
                (waterSpeed / 2) * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.name == "Metal Ball") && !isBroken)
        {
            isBroken = true;
        }
        
        
    }
    private void InstantiateWater()
    {
        instantiatedWater = Instantiate(water);
        instantiatedWater.transform.position = transform.position + waterOffset;

        initialScale = instantiatedWater.transform.localScale;
        finalScale = new Vector3(initialScale.x + scaleAmount.x, initialScale.y + scaleAmount.y, initialScale.z + scaleAmount.z);
        scaleDifference = (finalScale - initialScale);
        initialPos = instantiatedWater.transform.localPosition;
        
    }
}
