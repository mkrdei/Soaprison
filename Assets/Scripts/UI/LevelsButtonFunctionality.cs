using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelsButtonFunctionality : MonoBehaviour
{
    public string levelName;
    public bool available;
    // Start is called before the first frame update
    void Start()
    {
        if (UtilsScene.DoesSceneExist(levelName) == true)
        {
            available = true;
            GetComponent<Button>().onClick.AddListener(TaskOnClick);
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        if (levelName != "")
        {
            SceneManager.LoadScene(levelName);
        }
        
    }

    private void TaskOnClick()
    {
        Debug.Log("Loading Scene.");
        loadScene();
    }
}
