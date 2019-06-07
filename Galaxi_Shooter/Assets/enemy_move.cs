using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 6.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

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
