using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolChanger : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] symbols;
    public Material[] materials;
    public GameObject puzzleButtons;
    void Start()
    {

        // Fisher Yates Algorithm to shuffle materials.
        int ranzdomizeSeeds = new System.Random().Next(1,16);
        new System.Random(transform.GetSiblingIndex() + ranzdomizeSeeds).Shuffle(materials);
        new System.Random(transform.GetSiblingIndex() + ranzdomizeSeeds).Shuffle(puzzleButtons.GetComponent<PuzzlePressOrder>().desiredPressOrder);
        System.Array.Reverse(puzzleButtons.GetComponent<PuzzlePressOrder>().desiredPressOrder);

        symbols = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i) {
            symbols[i] = transform.GetChild(i).gameObject;
            symbols[i].GetComponent<MeshRenderer>().material = materials[i];
        }
            
    }

    void Update()
    {
        
    }
}
