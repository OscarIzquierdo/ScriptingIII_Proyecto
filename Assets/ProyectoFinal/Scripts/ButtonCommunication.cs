using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommunication : MonoBehaviour
{

    public GameObject optionsPanel;
    bool isOptionsActive;

    // Start is called before the first frame update
    void Start()
    {
        isOptionsActive = false;
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
}
