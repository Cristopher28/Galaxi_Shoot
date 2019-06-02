using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Laser : MonoBehaviour
{
    //Este script se se encargara  de darle moviemiento al lazer 
    //escribiremos una variable que tendra la velocidad  de el lazer 
    // velocidad = speed
    [SerializeField]
    private float Speed = 5;


    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        
        if(transform.position.y > 5.55f)
        {
            Destroy(this.gameObject);
        }
    }
}
