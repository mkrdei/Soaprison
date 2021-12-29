using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveLight : MonoBehaviour
{
    private Light _light;
    [SerializeField]
    private Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        _light.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    public IEnumerator Blink(float time, Color color, bool stay)
    {
        _light.color = color;
        Debug.Log("Blink!!");
        if (stay) { }
        else
        {
            yield return new WaitForSeconds(time);
            _light.color = defaultColor;
        }
            
        
        // Code to execute after the delay
    }
}
