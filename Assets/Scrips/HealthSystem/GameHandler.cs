using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Transform pfHealthBar;
        HealthSystem healthSystem = new HealthSystem(100);
    
    private void Start() {
        //maakt een healthbar
        HealthBar healthBar = pfHealthBar.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
        
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            healthSystem.Damage(50);
            Debug.Log(healthSystem.GetHealth());
        }
    }
}
