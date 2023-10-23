using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceSpeed = 600f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bounce");
        //Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.0f)
        {
            Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up*bounceSpeed);
        }
    }
}
