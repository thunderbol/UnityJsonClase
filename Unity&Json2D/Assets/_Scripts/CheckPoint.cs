using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public bool Activated = false;

    public static CheckPoint activeCheckpoint; //Instancia


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !Activated) 
        { 
            Activated = true;
            //Aquí se puede realizar acciones de checkpoint, guadar la posición del jugador


            //Este script se activa a si mismo
            activeCheckpoint = this;

            //Guardar la posición del jugador con PlayerPrefs
            PlayerPrefs.SetFloat("PlayerPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", other.transform.position.y);

            //PlayerPres solo guarda numeros
            //PlayerPefs.SetInt("Score", 100)

            //Guardar los cambios en PlayerPrefs
            PlayerPrefs.Save();
            //Realizar acciones para activar el checkpoin


		}
    }
}
