using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public struct WorldSprite
    {
        public Sprite playerSprite;
        public GameObject platformObjects;
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
    private float t = 0f;
    public GameObject currentPlayer;
    public GameObject formerPlayer;
    public GameObject currentBG;
    public GameObject formerBG;

    private Color startColor ;
    private Color endColor ;

    private GameObject currentPlatform;
    private GameObject formerPlatform;
    private List<GameObject> formerPlatformList = new List<GameObject>();
    private List<GameObject> currentPlatformList = new List<GameObject>() ;
    
    void Start()
    {
        currentPlatform = GrammaSprites.platformObjects;
        formerPlatform = SnakeSprites.platformObjects;
        Debug.Log(currentPlatform);
        // SetupChildren(currentPlatform.transform,currentPlatformList);
        // List<GameObject> currentPlatformList = new List<GameObject>();
        // List<GameObject> formerPlatformList = new List<GameObject>();
        currentPlatform.SetActive(true);
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
                currentPlatform =RabbitSprites.platformObjects;
                formerPlatform = GrammaSprites.platformObjects;
                // RabbitSprites.platformObjects.SetActive(true);
                // UpdateChildren(GrammaSprites.platformObjects.transform, formerPlatformList);
                // UpdateChildren(RabbitSprites.platformObjects.transform, currentPlatformList);
                break;

            case WorldStatus.Rabbit:
                currentBG.GetComponent<SpriteRenderer>().sprite = SnakeSprites.bgSprite;
                currentPlayer.GetComponent<SpriteRenderer>().sprite = SnakeSprites.playerSprite;
                formerBG.GetComponent<SpriteRenderer>().sprite = RabbitSprites.bgSprite;
                formerPlayer.GetComponent<SpriteRenderer>().sprite = RabbitSprites.playerSprite;
                currentStatus = WorldStatus.Snake;
                currentPlatform = SnakeSprites.platformObjects;
                formerPlatform = RabbitSprites.platformObjects;
                // SnakeSprites.platformObjects.SetActive(true);
                // UpdateChildren(SnakeSprites.platformObjects.transform, currentPlatformList);
                // UpdateChildren(RabbitSprites.platformObjects.transform, formerPlatformList);
                break;

            case WorldStatus.Snake:
                currentBG.GetComponent<SpriteRenderer>().sprite = GrammaSprites.bgSprite;
                currentPlayer.GetComponent<SpriteRenderer>().sprite = GrammaSprites.playerSprite;
                formerBG.GetComponent<SpriteRenderer>().sprite = SnakeSprites.bgSprite;
                formerPlayer.GetComponent<SpriteRenderer>().sprite = SnakeSprites.playerSprite;
                currentStatus = WorldStatus.Gramma;
                currentPlatform = GrammaSprites.platformObjects;
                formerPlatform = SnakeSprites.platformObjects;
                // GrammaSprites.platformObjects.SetActive(true);
                // UpdateChildren(GrammaSprites.platformObjects.transform, currentPlatformList);
                // UpdateChildren(SnakeSprites.platformObjects.transform, formerPlatformList);
                break;
            
        }
        currentPlatform.SetActive(true);

        UpdateChildren(currentPlatform.transform, currentPlatformList);
        UpdateChildren(formerPlatform.transform, formerPlatformList);
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
            foreach(GameObject platform in currentPlatformList)
            {
                platform.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor,t);
            }
            foreach(GameObject platform in formerPlatformList)
            {
                platform.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor,1-t);
            }


        }
        else
        {
            isChanging = false;
            // switch(currentStatus)
            // {
            //     case WorldStatus.Gramma:
            //     SnakeSprites.platformObjects.SetActive(false);
            //     break;
            //     case WorldStatus.Rabbit:
            //     GrammaSprites.platformObjects.SetActive(false);
            //     break;
            //     case WorldStatus.Snake:
            //     RabbitSprites.platformObjects.SetActive(false);
            //     break;
            // }
            formerPlatform.SetActive(false);
            formerBG.SetActive(false);
            formerPlayer.SetActive(false);
        }
    }

    void UpdateChildren(Transform parent, List<GameObject> directChildren)
    {
        directChildren.Clear();
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            directChildren.Add(child.gameObject);
        }
    }

    void SetupChildren(Transform parent, List<GameObject> directChildren)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            directChildren.Add(child.gameObject);
        }
    }

}
