using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //CONTROLAR CIERTAS OPCIONES DEL JUEGO

    [Header("CONTADOR ITEM")]
    public static GameManager instance;//Singleton
    public TMP_Text itemCountText;

	public int itemCount = 0;//Contador




	void Awake()
	{
		instance = this;
	}

	public void CollectableItem(int value) 
	{
		itemCount += value;
		UpdateItemCount();
	}

	void UpdateItemCount()
	{
		itemCountText.text = " : " + itemCount.ToString();
	}

}
