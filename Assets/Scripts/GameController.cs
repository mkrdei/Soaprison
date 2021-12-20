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
        if (Input.GetButtonDown("Main Menu") && SceneManager.GetActiveScene().buildIndex != SceneManager.GetSceneByName("Main Menu").buildIndex)
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
            SceneManager.LoadScene("Levels");
        }
    }
    
}
