using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int vidaMaxima = 100;
    public int vidaActual;
    UIAmmo uiText;
    Animator enemyAnim;

    public bool hidden;
    
    // Use this for initialization
    void Start()
    {
        vidaActual = vidaMaxima;
        uiText = FindObjectOfType<UIAmmo>();
        hidden = false;
    }

    public void QuitarVida(int daño)
    {
        vidaActual -= daño;

        float porcentajeVida = (float)vidaActual / vidaMaxima;
        print(porcentajeVida);
        if (vidaActual <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
    private void Update()
    {
        uiText.SetHPText(vidaActual);
    }

    public void SetHidden(bool estado)
    {
        hidden = estado;
    }

    public bool GetHidden()
    {
        return hidden;
    }
}