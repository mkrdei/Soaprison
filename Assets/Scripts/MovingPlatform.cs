using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isMoving;
    public GameObject relatedPuzzle;
    private MovingObject movingObject;
    private PuzzlePressOrder puzzlePressOrder;
    public GameObject relatedButton;
    private PhysicsButton physicsButton;
    public float movementSpeed;
    public Vector3 movementAmount;
    private Vector3 initalPos;
    private Vector3 finalPos;
    // Start is called before the first frame update
    void Start()
    {
        movingObject = GetComponent<MovingObject>();
        initalPos = transform.position;
        if(relatedPuzzle != null)
            puzzlePressOrder = relatedPuzzle.GetComponent<PuzzlePressOrder>();
        if(relatedButton != null)
            physicsButton = relatedButton.GetComponentInChildren<PhysicsButton>();
        finalPos = new Vector3(transform.position.x + movementAmount.x, transform.position.y + movementAmount.y, transform.position.z + movementAmount.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (physicsButton != null)
            if (physicsButton.isPressed)
                MovePlatformToFinalPosition();
            else
                MovePlatformToInitialPosition();

        if (relatedPuzzle != null)
            if(puzzlePressOrder.solved)
                MovePlatformToFinalPosition();
            else
                MovePlatformToInitialPosition();
    }

    private void MovePlatformToFinalPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalPos, movementSpeed * Time.deltaTime);
        if (transform.position != finalPos)
        {
            movingObject.isMoving = true;
        }
        else
        {
            movingObject.isMoving = false;
        }
    }
    
    private void MovePlatformToInitialPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, initalPos, movementSpeed * Time.deltaTime);
    }
        

}

