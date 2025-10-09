using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBola : MonoBehaviour
{
    //public Transform CamaraPrincipal;

    //Fuerza con la que se lanza la bola
    public float fuerzadeLanzamiento = 1000f;
    //Velocidades y limites para el apuntador
    public float velocidadeApuntador = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    //Referencias internas
    private Rigidbody rb;
    private bool haSidoLanzada = false;

    //Referencia a camara y score
    public CameraFollow cameraFollow;
    public ScoreManager scoremanager;


    // Start is called before the first frame update
    void Start()
    {
        //Para obtener el Rigidbody del la bola
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!haSidoLanzada)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space)) //es para llamar a una tacla
            {
                LanzarBola();
            }
        }
    }

    void Apuntar() 
    {
        //Movimiento horizontal (-1 a 1)
        float inputHorizontal = Input.GetAxis("Horizontal");
        //Movimiento de bola lateral
        transform.Translate(Vector3.right * inputHorizontal * velocidadeApuntador * Time.deltaTime);
        //Limitar el movimiento dentro de los bordes
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }

    void LanzarBola()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzadeLanzamiento);

        //Iniciar seguimiento de la camara (si existe)
        if (cameraFollow != null) cameraFollow.iniciarSegimiento();
    }

    void OnCollisionEnter(Collision collision) //OnCollisionEnter: cuando entro en contacto con otro objeto
    {
        //colicion con un pino
        if (collision.gameObject.CompareTag("Pin"))
        {
            //Detener seguimiento de camara (si no es null)
            if (cameraFollow != null) cameraFollow.detenerSegimiento();

            //Calcular puntaje tras un pequeño retraso
            if (scoremanager != null) Invoke("CalcularPuntaje", 2f);
        }
    }

    void CalcularPuntaje()
    {
        //Llamar al scoremanager para actualizar puntos
        scoremanager.CalcularPuntaje();
    }

}//NO TE PASES DE AQUI, FINAL
