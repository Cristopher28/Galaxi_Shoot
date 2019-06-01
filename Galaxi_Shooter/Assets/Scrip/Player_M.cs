﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_M : MonoBehaviour
{
    //variables a utilizar para el movimiento del player 
    //nececitaremos una variable para la  velocidad de movimiento
    //necesitaremos un control para el movimiento del personaje 

     public float Speed = 5;


    
    void Start()
    {
        transform.position = new Vector3(0, -3.65f, 0);
    }

    
    void Update()
    {
        //estas  son las variables para  los  botones de movimiento de nuestro player 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //aqui asemos el codigo dee traslado de nuestro player 
        transform.Translate(Vector3.right * horizontal * Speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * Speed * Time.deltaTime);
        //pondremos los limites en la pantalla para que nuestrom player no salga de pantalla 
        //pseudo codigo
        //si player es < -9.73 
        //traladarse a + 9.73
        //ocuparemos la condicion if 
        if(transform.position.x < -9.73)
        {
            transform.position = new Vector3(9.73f,transform.position.y,0);
        }else if(transform.position.x > 9.73)
        {
            transform.position = new Vector3(-9.73f, transform.position.y, 0);
        }

        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }else if(transform.position.y < -4.35)
        {
            transform.position = new Vector3(transform.position.x, -4.35f, 0);
        }




    }
}