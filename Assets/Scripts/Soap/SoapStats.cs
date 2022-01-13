using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoapStats : MonoBehaviour
{
    public bool alive = true;
    public bool wet = false;
    int[] levelIndexes;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            if(transform.tag=="Player")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else
            {
                Destroy(transform.gameObject);
            }
        }
    }

       
}
