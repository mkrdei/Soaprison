using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveLight : MonoBehaviour
{
    private Light _light;
    [SerializeField]
    private Color defaultColor = MyColors.Lights.soapPink;
    // Start is called before the first frame update
    void Awake()
    {
        
        _light = GetComponent<Light>();
        defaultColor.a = 100;
        _light.color = defaultColor;
        
    }
    private void Start()
    {
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
    }
}
