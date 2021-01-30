using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnerComponent : MonoBehaviour
{
    public Collider2D bounds; 
    public List<GameObject> npcToSpawn; 
    public int numberOfNpcToSpawn; 
    public bool isRandomNPC; 
    public int npcIDIfNotRandom; 

    void Start()
    {
        for (int i = 0; i < numberOfNpcToSpawn; i++)
        {
            GameObject temp; 

            if(isRandomNPC)
                temp = Instantiate(npcToSpawn[Random.Range(0, npcToSpawn.Count)], this.transform);
            else
                temp = Instantiate(npcToSpawn[npcIDIfNotRandom], this.transform);
            
            temp.transform.position = GetRandomPosInBounds();
            temp.transform.rotation = Quaternion.identity;
        }
    }

    void Update()
    {
        
    }

    private Vector2 GetRandomPosInBounds ()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        pos += new Vector2(Random.Range(-bounds.bounds.size.x, bounds.bounds.size.x), 0.0f);
        return pos;
    }
}
