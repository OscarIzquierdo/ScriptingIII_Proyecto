using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommunication : MonoBehaviour
{

    public GameObject optionsPanel;
    public GameObject pausePanel;
    bool isOptionsActive;
    bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        isOptionsActive = false;
        isGamePaused = false;

        if (pausePanel != null) pausePanel.SetActive(false);
        if(optionsPanel!=null)optionsPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Time.timeScale ==0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitPause();             
            }
        }

        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                pausePanel.SetActive(true);
                isGamePaused = true;
                Time.timeScale = 0f;
                print("Pause");
            }            
        }
    }

    public void ActivateOptions()
    {
        if (isOptionsActive == false)
        {
            optionsPanel.SetActive(true);
            isOptionsActive = true;
        }
    }

    public void DeactivateOptions()
    {
        if (isOptionsActive == true)
        {
            optionsPanel.SetActive(false);
            isOptionsActive = false;
        }
    }

    public void ChangeScene(string LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitPause()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        pausePanel.SetActive(false);
        isGamePaused = false;
        
        print("Unpause");
    }
}
