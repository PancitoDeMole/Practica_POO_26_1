using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBola : MonoBehaviour
{
    public Rigidbody rb;
    public float fuerza = 3000f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //es para llamar a una tacla
        {
            rb.AddForce(Vector3.forward * fuerza); //es para agregar una fuerza hacia "delante/formard"
            //Debug.Log("Salto"); // sirve para imprimir un mensaje
        }
    }
}
