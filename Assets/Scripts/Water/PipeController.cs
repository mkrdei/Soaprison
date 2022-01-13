using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PipeController : MonoBehaviour
{
    [Header("Relation")]
    public bool doorRelated;
    public bool buttonRelated;
    [Header("Status")]
    [SerializeField]
    private bool running;
    public bool isBroken;
    [Header("")]
    [SerializeField]
    public bool freezeXPos;
    public bool freezeYPos;
    public bool freezeZPos;
    public GameObject relatedButton;
    public Door relatedDoor;
    public float waterSpeed;
    public Vector3 scaleAmount;
    public Vector3 movementOffset;
    private Vector3 pipeToWaterVectorTransform;
    private Vector3 initialScale;
    private Vector3 initialPos;
    private Vector3 finalScale;
    private Vector3 scaleDifference;
    private GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        water = transform.GetChild(0).gameObject;
        initialScale = water.transform.localScale;
        initialPos = water.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonRelated)
        {
            if (relatedButton.GetComponentInChildren<PhysicsButton>().isPressed)
            {
                RunWater();
            }
            else
            {
                RunWaterBack();

            }
        }
        if (doorRelated)
            if (relatedDoor.open)
                isBroken = true;

        if (isBroken)
        {
            RunWater();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.name == "Metal Ball"))
        {
            isBroken = true;
        }
    }
    private void RunWater()
    {
        running = true;
        water.transform.localScale = Vector3.MoveTowards(water.transform.localScale,  scaleAmount, waterSpeed * Time.deltaTime);
        water.transform.localPosition = Vector3.MoveTowards(water.transform.localPosition, new Vector3(
            initialPos.x + (freezeXPos ? 0 : scaleAmount.x / 2) + movementOffset.x,
            initialPos.y + (freezeYPos ? 0 : scaleAmount.y / 2) + movementOffset.y,
            initialPos.z + (freezeZPos ? 0 : scaleAmount.z / 2) + movementOffset.z),
            (waterSpeed / 2 * Time.deltaTime));
    }
    private void RunWaterBack()
    {
        running = false;
        water.transform.localScale = Vector3.MoveTowards(water.transform.localScale, initialScale, waterSpeed * Time.deltaTime);
        water.transform.localPosition = Vector3.MoveTowards(water.transform.localPosition, initialPos,
            (waterSpeed / 2) * Time.deltaTime);
    }
    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }
}
