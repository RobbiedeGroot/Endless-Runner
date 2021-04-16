using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUi : MonoBehaviour
{
    public Text AmmoAmount;
    // Update is called once per frame
    void Start()
    {
        AmmoAmount = gameObject.GetComponent<Text>();
    }
    
    void Update()
    {
        AmmoAmount.text = "Ammo: " + Pickup.AmmoAmount.ToString();
    }
}
