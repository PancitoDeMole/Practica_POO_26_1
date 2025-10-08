using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBola : MonoBehaviour
{
    public Transform CamaraPrincipal;

    public Rigidbody rb;
    //variable para apuntar
    public float velocidadDEApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    private float fuerza = 10000f;

    private bool hasidolanzada = false;
    
    void Start()
    {
        
    }

    void Update()
    {       //Todo lo que esta dentro del if es una "Expresión"
        if ( hasidolanzada==false)
        {
            Apuntar();

            if (Input.GetKeyDown(KeyCode.Space)) //es para llamar a una tacla
            {
                Lanzar();
            }
        }
    }

    void Lanzar()
    {
        hasidolanzada = true;
        rb.AddForce(Vector3.forward * fuerza); //es para agregar una fuerza hacia "delante/formard"
        //Debug.Log("Salto"); // sirve para imprimir un mensaje

        if(CamaraPrincipal != null)
        {
            CamaraPrincipal.SetParent(transform);
        }
    }

    void Apuntar()
    {
        //El input Horizontal tipo Axis: me permite registrar entredas con la tecla A y D / Flechas
        float inputHorizontal = Input.GetAxis("Horizontal");
        //me permite mover la bola hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDEApuntado * Time.deltaTime);
        //transform.position: me permite saber cual es la posicion actual de la bola en la escena
        Vector3 posicionActual = transform.position;

        //Mathf: estoy acotando que tanto puedop moverme de izquierda a la derecha
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho); 
        transform.position = posicionActual;
    }

}//NO TE PASES DE AQUI ESTUPIDO >:(
