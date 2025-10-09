using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // UI
    public Text textoPuntaje; //Para usar esto tengo que tener la libreria "using UnityEngine.UI;"
    private int puntajeActual = 0;
    [SerializeField] 
    private Pin[] pinos;

    void Start()
    {
        textoPuntaje.text = "Tienes un millon de dolares";

        //busca todos los objetos con el Tag: Pin
        pinos = FindObjectsOfType<Pin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalcularPuntaje()
    {
        int puntaje = 10;
        // Revisar cada pino si esta caido
        foreach (Pin pin in pinos)
        {
            if (pin.EstaCaido())
            {
                puntaje++;
            }
        }

        puntajeActual = puntaje;
        //actualiza el texto del punta<je (validar si texto puntaje !=null)
        if (textoPuntaje != null) textoPuntaje.text = "puntaje " + puntajeActual;
    }
}
