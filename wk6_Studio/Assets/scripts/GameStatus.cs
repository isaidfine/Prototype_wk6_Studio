using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public struct WorldSprite
    {
        public Sprite playerSprite;
        public GameObject platformObject;
        public Sprite bgSprite;       
    }

public class GameStatus : MonoBehaviour
{
    enum WorldStatus
    {
        Gramma, Rabbit, Snake
    }
    [SerializeField] WorldStatus currentStatus = WorldStatus.Gramma;
    [SerializeField] WorldSprite GrammaSprites;
    [SerializeField] WorldSprite RabbitSprites;
    [SerializeField] WorldSprite SnakeSprites;    

    public float floatingTime;
    public bool isChanging;
    public float t = 0f;
    public GameObject currentPlayer;
    public GameObject formerPlayer;
    public GameObject currentBG;
    public GameObject formerBG;

    private Color startColor ;
    private Color endColor ;

    
    void Start()
    {
        startColor = new Color(1,1,1,0);
        endColor = new Color(1,1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(isChanging) ChangingStatus();
        
    }

    public void SwiftStatus()
    {
        isChanging = true;
        t=0;
        formerBG.SetActive(true);
        formerPlayer.SetActive(true);
        formerBG.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        formerPlayer.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        currentBG.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        currentPlayer.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        switch (currentStatus)
        {
            case WorldStatus.Gramma:
                currentBG.GetComponent<SpriteRenderer>().sprite = RabbitSprites.bgSprite;
                currentPlayer.GetComponent<SpriteRenderer>().sprite = RabbitSprites.playerSprite;
                formerBG.GetComponent<SpriteRenderer>().sprite = GrammaSprites.bgSprite;
                formerPlayer.GetComponent<SpriteRenderer>().sprite = GrammaSprites.playerSprite;
                currentStatus = WorldStatus.Rabbit;
                break;

            case WorldStatus.Rabbit:
                currentBG.GetComponent<SpriteRenderer>().sprite = SnakeSprites.bgSprite;
                currentPlayer.GetComponent<SpriteRenderer>().sprite = SnakeSprites.playerSprite;
                formerBG.GetComponent<SpriteRenderer>().sprite = RabbitSprites.bgSprite;
                formerPlayer.GetComponent<SpriteRenderer>().sprite = RabbitSprites.playerSprite;
                currentStatus = WorldStatus.Snake;
                break;

            case WorldStatus.Snake:
                currentBG.GetComponent<SpriteRenderer>().sprite = GrammaSprites.bgSprite;
                currentPlayer.GetComponent<SpriteRenderer>().sprite = GrammaSprites.playerSprite;
                formerBG.GetComponent<SpriteRenderer>().sprite = SnakeSprites.bgSprite;
                formerPlayer.GetComponent<SpriteRenderer>().sprite = SnakeSprites.playerSprite;
                currentStatus = WorldStatus.Gramma;
                break;
            
        }
    }

    void ChangingStatus()
    {
        t += Time.deltaTime;
        if(t<=floatingTime)
        {
            float lerpT = t/floatingTime;
            formerBG.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, 1-t);
            formerPlayer.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, 1-t);
            currentPlayer.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor,endColor,t);
            currentBG.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor,endColor,t);
        }
        else
        {
            isChanging = false;
            formerBG.SetActive(false);
            formerPlayer.SetActive(false);
        }
    }

}
