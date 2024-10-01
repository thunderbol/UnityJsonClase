using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;

public class ControllerDataGame : MonoBehaviour
{
    //Referencia de nuestro player 
    public GameObject player;

    //String para guardas y leer 
    public string saveFile;

    //crearemos un objeto del tipo de los datos del jugador 
    public DataGame dataGame = new DataGame();


    //Crearemos un metodo Awake para que se ejecute antes de iniciar el juego

    private void Awake()
    {
        //Haremos que nuestro arhivo de guarde en la ubicación donde está nuestro proyecto
        saveFile = Application.dataPath + "/datosJuego.json";
        //Este archivo json lo creamos para guardar nuestras variables 


        //Buscamos el player en nuestra escena. 
        player = GameObject.FindGameObjectWithTag("Player");


        LoadData();

    }


    //Crearemos don funciones para procesos de Carga y Guardado

    private void LoadData() {

        //Debemos preguntar si el archivo que vamos a cargar éxiste
        if (File.Exists(saveFile))
        {
            //Si el archivo éxiste, ponemos el contenideo en una variable 
            string dataContent = File.ReadAllText(saveFile);
            //Obtenemos los datos del archivo JSON y así lo convertimos
            //en un archo enteible por unity 
            dataGame = JsonUtility.FromJson<DataGame>(dataContent);

            Debug.Log("Position Player: " + dataGame.position);
            //Revisamos que posición tien el jugador al momento de cargar
        }
        else
        {
            Debug.Log("El archivo no existe");
        }

        //Haremos que nuestro player cambie su posición por la que tiene el archivo
        player.transform.position = dataGame.position;
     

    }


    private void SaveData() {
        //Llamar la posición del jugador al momento de guardar 
        DataGame newData = new DataGame()
        {
            //Agarrar los datos nuevos
            position = player.transform.position
        };

        //Los volvemos a formato json
        string stringJson = JsonUtility.ToJson(newData);

        //Escribir los datos 
        File.WriteAllText(saveFile, stringJson);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData(); 
        }
    }



}
