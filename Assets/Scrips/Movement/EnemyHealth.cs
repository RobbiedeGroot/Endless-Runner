using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public static float healthEnemy;
    // Start is called before the first frame update
    void Start()
    {
        healthEnemy = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //als de enemyhealth kleiner is dan gaat ie dood
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth -= 50;
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
