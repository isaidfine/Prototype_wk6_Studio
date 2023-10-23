using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    
    public float spawnXMax = 4.0f;
    public float cameraYmax = 7.5f;
    public float spawnYMax = 12.0f;

    private List<GameObject> PlatformList = new List<GameObject>();
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Anchor");
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            PlatformList.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
         foreach(GameObject platform in PlatformList)
            {
                check(platform);
            }
        
    }

    void check(GameObject platform)
    {
        if(platform.transform.position.y- player.transform.position.y >= spawnYMax) 
        platform.transform.position= new Vector2(Random.Range(-spawnXMax,spawnXMax),platform.transform.position.y - spawnYMax*1.5f-cameraYmax*0.5f + Random.Range(-0.5f*(spawnYMax-cameraYmax),0));
        else if(platform.transform.position.y- player.transform.position.y <= -spawnYMax)
        platform.transform.position= new Vector2(Random.Range(-spawnXMax,spawnXMax),platform.transform.position.y + spawnYMax*1.5f+cameraYmax*0.5f + Random.Range(0,0.5f*(spawnYMax-cameraYmax)));
       if (platform.transform.position.x >= (player.transform.position.x+spawnXMax+2.0f) || platform.transform.position.x <= (player.transform.position.x - spawnXMax-2.0f) )
         platform.transform.position = new Vector2 (Random.Range(player.transform.position.x - spawnXMax,player.transform.position.x+spawnXMax),platform.transform.position.y);

    }
}
