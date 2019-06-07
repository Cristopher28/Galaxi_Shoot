using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-7f,7f), 6.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //aqui detenemos al enemigo de bajar y se coloca en pocicion que se le indica en la pantalla 

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= 3.17)
        {
            transform.position = new Vector3(transform.position.x, 3.17f, 0);

        }

        if (transform.position.y <= -6.5)
        {
            transform.position = new Vector3(Random.Range(-7,7), 6.5f, 0);
        }
        
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LASER")
        {
            Debug.Log("colision :");
            Destroy(this.gameObject);
        }
    }


}
