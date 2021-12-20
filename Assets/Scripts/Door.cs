using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open, opening;
    [Header("Puzzle Types")]
    public bool orPuzzle;
    public bool anyPuzzle;
    private Animator anim;
    private MovingObject movingObject;
    public GameObject[] buttons, puzzles;
    private int numberOfButtonsPressed, numberOfPuzzlesSolved;
    [SerializeField]
    private bool pressedAllButtons, solvedAllPuzzles;
    // Start is called before the first frame update
    void Start()
    {
        movingObject = GetComponentInChildren<MovingObject>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If doors open without solving puzzles or buttons, check array length from the editor. If there are no buttons button array length should be zero, same for the puzzles.
        if(buttons.Length>0)
        {
            numberOfButtonsPressed = 0;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].GetComponentInChildren<PhysicsButton>().isPressed)
                {
                    numberOfButtonsPressed++;
                }
            }
            if (numberOfButtonsPressed == buttons.Length && numberOfButtonsPressed > 0)
            {
                pressedAllButtons = true;
            }
            else
            {
                pressedAllButtons = false;
            }
        }
        else
        {
            pressedAllButtons = true;
            Debug.Log("There are no enough buttons.");
        }

        if(puzzles.Length>0)
        {
            numberOfPuzzlesSolved = 0;
            foreach (GameObject puzzle in puzzles)
            {
                if (puzzle.GetComponent<PuzzlePressOrder>().solved)
                {
                    numberOfPuzzlesSolved++;
                }
            }
            if (numberOfPuzzlesSolved == puzzles.Length && numberOfPuzzlesSolved > 0)
            {
                solvedAllPuzzles = true;
            }
            else if(orPuzzle && numberOfPuzzlesSolved == puzzles.Length/2)
            {
                // Opens the door when one of the puzzles solved.
                solvedAllPuzzles = true;

            }
            else if (anyPuzzle && numberOfPuzzlesSolved == puzzles.Length / 2)
            {
                // Opens the door when any of the puzzles solved.
                solvedAllPuzzles = true;
            }
            else
            {
                solvedAllPuzzles = false;
            }
        }
        else
        {
            solvedAllPuzzles = true;
            Debug.Log("There are no enough puzzles.");
        }



        if (solvedAllPuzzles && pressedAllButtons)
        {
            open = true;
            anim.SetBool("Open", open);
        }
        else
        {
            open = false;
            anim.SetBool("Open", open);
        }
        if (!opening && open)
        {
            movingObject.isMoving = true;
            Invoke("StopMoving", movingObject.defaultWaitTime);
            opening = true;
        }
        
    }
    private void StopMoving()
    {
        movingObject.isMoving = false;
    }
}
