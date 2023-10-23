using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceSpeed = 600f;
    // Start is called before the first frame update
    private GameObject GS;
    void Start()
    {
        GS = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bounce");
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.0f)
        {
            //Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up*bounceSpeed);
            if(!GS.GetComponent<GameStatus>().isChanging) GS.GetComponent<GameStatus>().SwiftStatus();
        }
    }
}
