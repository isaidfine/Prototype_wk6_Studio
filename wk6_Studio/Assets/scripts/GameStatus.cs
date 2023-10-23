using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public struct WorldSprite
    {
        public Sprite playerSprite;
        public Sprite platformSprite;
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

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
