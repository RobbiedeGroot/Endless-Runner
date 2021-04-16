using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;
    
    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChaned;
    }
    
    private void HealthSystem_OnHealthChaned(object sender, System.EventArgs e)
    {
        //zorgt dat de redbar mee schaalt
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
}
