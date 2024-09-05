using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        movimientoH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoH * velMovement,rb.velocity.y);
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


}
