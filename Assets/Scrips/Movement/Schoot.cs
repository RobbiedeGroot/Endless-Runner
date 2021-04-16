using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schoot : MonoBehaviour
{
    public GameObject SmallBullet;
    
    public GameObject BigBullet;
    private float AddForce;
    private float VelocityPlayer;
    private Vector2 VelocityBullet;
    private Rigidbody2D blRigidBody;
    private float timer;
    
    private Vector3 distanceFromPlayer;
    private GameObject SpawnBullet;
    
    [Header("SpeedCooldown Timer")]
    public float BulletDestroy;
    // Start is called before the first frame update
    void Start()
    {
        blRigidBody = GetComponent<Rigidbody2D>();
        distanceFromPlayer = new Vector3(1.5f, 0 ,0);
    }
    // Update is called once per frame
    
    void Update()
    {
        
        //maakt een lazer 
        if (Input.GetButtonDown("Fire1") && Pickup.AmmoAmount > 0)
        {   
            SpawnBullet = Instantiate(SmallBullet, this.transform.position + distanceFromPlayer, Quaternion.identity);            
            
            VelocityPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x;
            
            AddForce = VelocityPlayer + 3000;
            
            Debug.Log(AddForce);
            
            Vector2 VelocityBullet = new Vector2 (AddForce, 0);
            SpawnBullet.GetComponent<Rigidbody2D>().AddForce(VelocityBullet, 0);
            Pickup.AmmoAmount -= 1;
        }
        
    }
}
