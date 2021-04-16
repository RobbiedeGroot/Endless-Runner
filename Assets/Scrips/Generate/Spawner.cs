using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // the location where the item or enemy spawns
    public GameObject spawnLocation;
    
    //coin
    public GameObject coin;
    // enemy
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;
    public GameObject enemy_4;
    //ammo
    public GameObject ammo;
    // timeslow juice
    public GameObject juice;
    
    // Start is called before the first frame update
    void Start()
    {
        // randomly pick what to spawn
        int num = Random.Range(1, 9);
        
        
        if (num == 1)
        {
            Instantiate(coin, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0f), Quaternion.identity );
        }
        
        if (num == 2)
        {
            Instantiate(enemy_1, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0f), Quaternion.identity);
        }
        
        if (num == 3 || num == 4)
        {
            Instantiate(ammo, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0f), Quaternion.identity);
        }
        
        if (num == 6)
        {
            Instantiate(enemy_2, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0f), Quaternion.identity);
        }
        if (num == 7)
        {
            Instantiate(enemy_3, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0f), Quaternion.identity);
        }
        if (num == 8)
        {
            Instantiate(enemy_4, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0f), Quaternion.identity);
        }
    }
}
