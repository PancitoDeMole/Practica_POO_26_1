using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    //umbral de inclinacion
    private float umbralCaida = 5f;
    public  bool EstaCaido()
    {
        //calcular el angulo entre la orientacion del pino y el eje vertical
        float angulo = Vector3.Angle(transform.up, Vector3.up);
        //Retornanr true si el angulo supera al umbral de caida
        return angulo > umbralCaida; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
