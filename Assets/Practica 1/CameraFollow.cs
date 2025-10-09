using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Referencia al objeto bola
    public Transform objetivo;
    //Offset o separación entre la camara y el objetivo
    //                         position  x    y     z
    public Vector3 offset = new Vector3 (0f, 3f , -6f);
    //Variable para activar o desactivar el seguimiento 
    private bool seguir = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        //Solo seguir si esta activado y el objetivo esta correctamente referenciado 
        if (seguir && objetivo != null)
        {
            //posicionar camara con offset
            transform.position = objetivo.position + offset;
        }
    }

    //Metodo para iniciar el seguimiento 
    public void iniciarSegimiento()
    {
        seguir = true;
    }
    //Metodo para iniciar el seguimiento 
    public void detenerSegimiento()
    {
        seguir = false;
    }

}//NO TE PASES DE AQUI
