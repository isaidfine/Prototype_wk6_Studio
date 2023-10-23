
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMoving : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    public float speed = 10f;
    // Start is called before the first frame update
    public bool isStarted = false;

    private float topScore = 0.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startText;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

    }

     void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {

            isStarted = true;
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;

        }

        if (isStarted == true)
        {

            if (moveInput < 0)
            {

                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;

            }
            else
            {

                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;

            }

            if (rb2d.velocity.y > 0 && transform.position.y > topScore)
            {

                topScore = transform.position.y;

            }

            scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        }

    }

    void FixedUpdate()
    {

        if (isStarted == true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        }

    }
}
