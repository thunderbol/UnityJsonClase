using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableItem : MonoBehaviour
{
    [Header("Item Banano")]
    public int value = 1; //Valor del objeto que será recolectado

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) //Asegurar que el Personaje tenga el TAG player
		{
			Debug.Log("Soy el player y estoy en el trigger del BANANO");
			//Sonid de recolección
			//Animación de recolección
			GameManager.instance.CollectableItem(value);
			Destroy(gameObject);

			Debug.Log("El Banano fue destruido");

		}
	}
}
