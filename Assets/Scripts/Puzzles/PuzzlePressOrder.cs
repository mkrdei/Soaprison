using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PuzzlePressOrder : MonoBehaviour
{
    public bool solved;
    [SerializeField]
    private float delayedRefreshTime;
    PhysicsButton[] buttons;
    public GameObject[] desiredPressOrder;
    public GameObject[] pressOrder;
    private bool allPressed;
    // Start is called before the first frame update
    void Awake()
    {
        
        buttons = GetComponentsInChildren<PhysicsButton>();
        pressOrder = new GameObject[buttons.Length];

        // desiredPressOrder shuffled and reversed inside SymbolChanger.cs
        
    }

    // Update is called once per frame
    void Update()
    {

            foreach (PhysicsButton button in buttons)
            {
                if (button.isPressed)
                {
                    if (!System.Array.Exists(pressOrder, element => element == button.transform.parent.gameObject))
                    {
                        for (int i = pressOrder.Length - 1; i > 0; i--)
                        {
                            pressOrder[i] = pressOrder[i - 1];
                        }
                        pressOrder[0] = button.transform.parent.gameObject;
                    }
                }

            }
        
        if(pressOrder[pressOrder.Length-1] != null)
        {
            bool isEqual = Enumerable.SequenceEqual(desiredPressOrder, pressOrder);
            if (isEqual)
            {
                Debug.Log("Puzzle solved.");
                solved = true;
                StartCoroutine(GetComponentInChildren<InteractiveLight>().Blink(delayedRefreshTime, MyColors.Lights.green, true));
            }
            else
            {
                StartCoroutine(GetComponentInChildren<InteractiveLight>().Blink(delayedRefreshTime, MyColors.Lights.red, false));
                foreach (PhysicsButton button in buttons)
                {
                    button.Invoke("DelayedRefresh", delayedRefreshTime);
                }
                pressOrder = new GameObject[buttons.Length];
            }
            

        }
            
           
                
        
    }
}
