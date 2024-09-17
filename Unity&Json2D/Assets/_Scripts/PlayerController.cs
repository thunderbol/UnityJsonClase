using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [Header("Velocidad y salto")]
    public float velMovement = 5f; //Velocidad Movimiento
    public float fuerzaJump = 7f; //Fuerza de salto

    [Header("RigidBody y Aniamtor")]
    private Rigidbody2D rb; //RigidBody Físicas 2D
    private Animator animator; //Animator Animaciones del player

    [Header("Movimiento Player")]
    public float movimientoH; //Fuerza de movimiento en el eje X a tráves de un Imput

    [Header("Posicion del player")]
    public Transform playerTransform; //Posición, Escala y Rotación del Player

    public bool enElSuelo = false;//Detección del suelo.

    


    void Start()
    {
        //Inicializacion de Componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Debug de los componentes
        if (rb == null)
        {
            Debug.Log("No se encontró el componente RigidBody2d en el objeto " + gameObject.name);

        }
        if (animator == null)
        {
            Debug.Log("No se encontro el componente Animator en el objeto " + gameObject.name);
        }

    }


    void Update()
    {
        //Movimiento Horizontal del player
        movimientoH = Input.GetAxis("Horizontal");//Llamado de input
        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));


        //Flip
        if (movimientoH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); //Movimiento hacia la derecha
        }
        else if (movimientoH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //Movimiento hacia la izquierda
        }


        //Salto
        if (Input.GetButton("Jump") && enElSuelo)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);
            enElSuelo = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detectar el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
            Debug.Log("Estoy tocando el suelo");
        }
    }

     //Funcion Trigger para detectar enemigos
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Enemy"))
        {
            //El jugador a tocado el Enemigo, así que lo consideramos muerto
            Debug.Log("Soy el Enmigo");
            //gameObject.SetActive(false);
            //Destroy(gameObject);
            PlayerDeath();
        }

        Debug.Log("El trigger funciona");

	}

    public void PlayerDeath() 
    {
        //Realiza acciones con la muert del personaje 
        //Mostrar la animación de muerte del player
        //Corrutina para esperar un tiempo

        //Funcion de respawn
        RespawnCheckpoint();
    }


    //RespawnCheckPoint
    public void RespawnCheckpoint() 
    {
        if (CheckPoint.activeCheckpoint != null)
        {
            //Traigo los valores guardos del CheckPoint
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
			float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");

            //Entregarle al personaje la posición que teniamos guardada
            Vector3 respawnPosition = new Vector3(playerPosX, playerPosY, playerTransform.position.z);
            playerTransform.position = respawnPosition; //llevar al personaje a la posición guardada

		}

        //Restaurar Vida 
        //Reiniciar el juego 
        //Mostrar animaciones
    }

    


}
