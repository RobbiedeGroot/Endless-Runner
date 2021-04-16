using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject PlatformDestructionPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        PlatformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //kijkt of de PlatformDestructionPoint kleiner is dan de positie van de script
        if (transform.position.x < PlatformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
