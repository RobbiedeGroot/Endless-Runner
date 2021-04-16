using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Ammo amount")]
    public float Ammo;
    public static int AmmoAmount;

    [Header("Juice amount")]
    public float Juice;
    
    [Header("Coin Amount")]
    public float Coin;
    public static int ScoreAmmount;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //pickups
        if (other.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("test_Ammo");
            Destroy(other.gameObject);
            Ammo += 10;
            AmmoAmount += 10;
        }
        
        if (other.gameObject.CompareTag("Juice"))
        {
            Debug.Log("test_Juice");
            Destroy(other.gameObject);
            Juice += 1;
        }
        
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("test_Coin");
            Destroy(other.gameObject);
            Coin += 500;
            ScoreAmmount += 500;
        }
    }
}
