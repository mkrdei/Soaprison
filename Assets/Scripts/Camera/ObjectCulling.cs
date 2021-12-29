using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCulling : MonoBehaviour
{
    public GameObject player;
    private Renderer playerRenderer;
    private List<Renderer> partiallyVisibleObjectsRenderersList;
    private Renderer[] partiallyVisibleObjectsRenderers;
    // Start is called before the first frame update
    void Start()
    {
        partiallyVisibleObjectsRenderersList = new List<Renderer>();
        playerRenderer = player.GetComponent<Renderer>();
        foreach (GameObject partiallyVisibleObject in FindGameObjectsWithLayer(7))
        {
            partiallyVisibleObjectsRenderersList.Add(partiallyVisibleObject.GetComponent<Renderer>());
        }
        partiallyVisibleObjectsRenderers = partiallyVisibleObjectsRenderersList.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerRenderer.isVisible)
        {
            Debug.Log("Player is invisible");
            foreach(Renderer partiallyVisibleObjectRenderer in partiallyVisibleObjectsRenderers)
            {
                partiallyVisibleObjectRenderer.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
            }
        }
    }
    private GameObject[] FindGameObjectsWithLayer(int layer){
        GameObject[] goArray = GameObject.FindObjectsOfType<GameObject>();
        var goList = new List<GameObject>();
     for (var i = 0; i<goArray.Length; i++) {
         if (goArray[i].layer == layer) {
             goList.Add(goArray[i]);
         }
     }
     if (goList.Count == 0) {
         return null;
     }
     return goList.ToArray();
 }
}
