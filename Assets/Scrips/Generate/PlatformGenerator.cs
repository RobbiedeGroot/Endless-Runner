using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> PlatformList = new List<GameObject>();
    public Transform genertationPoint;
    public float distanceBetweenX;
    public float distanceBetweenY;
    private int sizeList;
    private float platformWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        sizeList = PlatformList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        //pakt random getal voor de distance y
        distanceBetweenY = Random.Range(-5, 5);
        //pakt random getal voor de distance x
        distanceBetweenX = Random.Range(3, 5);
        
        int prefabIndex = UnityEngine.Random.Range(0, sizeList);
        
        if(transform.position.x < genertationPoint.position.x)
        {
            platformWidth = PlatformList[prefabIndex].GetComponent<BoxCollider2D>().size.x;
            
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenX, transform.position.y + distanceBetweenY, transform.position.z);
            
            Instantiate (PlatformList[prefabIndex], transform.position, transform.rotation);
        }
    }
}
