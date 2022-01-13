using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool levelPassed;
    public bool cursorLocked = true;
    // Start is called before the first frame update
    void Start()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Main Menu") && SceneManager.GetActiveScene().buildIndex != SceneManager.GetSceneByName("Main Menu").buildIndex && !Application.isEditor)
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (levelPassed)
        {
            levelPassed = false;

            /*
            string path = "Assets/Scenes/Levels/";
            string nextSceneName = SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).Substring(path.Length).Replace(".unity", "");
            Debug.Log(nextSceneName);
            */
            // Check if scene is valid.
            string nextScenePath = SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
            bool isNextSceneValid = nextScenePath.Length > 0 ? true : false;
            if (isNextSceneValid)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
            else
            {
                SceneManager.LoadScene("Main Menu");
            }
            
        }
    }
    
}
