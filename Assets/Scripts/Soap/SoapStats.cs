using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoapStats : MonoBehaviour
{
    public bool alive = true;
    public bool wet = false;
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
                SceneManager.LoadScene("Levels");
            else
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
