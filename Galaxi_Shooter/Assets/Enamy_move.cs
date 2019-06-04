using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy_move : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 5.56f, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5.63f)
        {
            transform.position = new Vector3(Random.Range(-8f,8.4f), 5.56f, 0);
        }
       
    }
}
