using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIClickableElements : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public GameObject soapTopView;
    private RectTransform soapTopViewRect, rect;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        if (soapTopView != null)
        {
            soapTopViewRect = soapTopView.GetComponent<RectTransform>();
            rect = GetComponent<RectTransform>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        if (soapTopView != null)
            soapTopViewRect.position = rect.position;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.name == "Exit")
        {
            Application.Quit();
        }
        if (eventData.pointerPress)
        {
            Debug.Log("Pressed");
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
