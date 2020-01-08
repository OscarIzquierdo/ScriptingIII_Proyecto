using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int vidaMaxima = 100;
    public int vidaActual;
    UIAmmo uiText;

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

        if (vidaActual <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void Update()
    {
        uiText.SetHPText(vidaActual);
    }

}