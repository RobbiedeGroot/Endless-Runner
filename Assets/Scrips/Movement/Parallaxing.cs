using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    private Vector2 startPos;
    private Camera cam;
    private float lengthX;
    private float lengthY;
    private float height;
    
    [SerializeField]
    private float ParallaxingEffectX = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        startPos = transform.position;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //kijken naar het veschil tussen de camerapositie en onze startpositie
        Vector2 dist = cam.transform.position * ParallaxingEffectX;
        Vector2 temp = cam.transform.position * (1 - ParallaxingEffectX);
        
        
        if(temp.x > startPos.x + lengthX)
        {
            startPos.x += lengthX;
        }
        
        else if (temp.x < startPos.x - lengthX)
        {
            startPos.x -= lengthX;
        }
        
        if(temp.y > startPos.y + lengthY)
        {
            startPos.y += lengthY;
        }
        
        else if (temp.y < startPos.y - lengthY)
        {
            startPos.y -= lengthY;
        }
        
        transform.position = startPos + dist;
    }
}
