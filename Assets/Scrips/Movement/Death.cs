using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //zorgt ervoor dat de speler "dood" gaat
        if (collision.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Pickup.AmmoAmount = 0;
            Pickup.ScoreAmmount = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
