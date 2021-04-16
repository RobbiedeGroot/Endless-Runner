using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class MoveEnemy : MonoBehaviour
{
    [Header("Choose enemy speed")]
    public float enemySpeed = 3;
    private int enemyDirection = 1;

    private Rigidbody2D plRigidbody;

    // variabelen voor het springen van de enemy
    private bool isGrounded;
    private bool canJump;
    private float timer;

    // keuze van enemy movement
    public enum movementType { between_points, between_colliders, raycast_detection, basic_jump };

    [Header("choose enemy movement type")]
    public movementType enemyMove;


    [Header("define points for 'between_points' detection")]
    public float pltfrmLeft;
    public float pltfrmRight;

    [Header("tagname for triggers on platform")]
    public string tagName;

    [Header("jump variables")]
    public float jumpForce = 400;
    public float jumpCooldown;

    // Start is called before the first frame update
    void Start()
    {
        plRigidbody = gameObject.GetComponent<Rigidbody2D>();

        plRigidbody.velocity = new Vector2(enemySpeed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (enemyMove)
        {
            case movementType.between_points:
                // code voor between_points

                if (transform.position.x < pltfrmLeft || transform.position.x > pltfrmRight)
                {
                    TurnEnemy();
                }
                Move();
                break;

            case movementType.between_colliders:
                // code for between_colliders
                // code voor de triggers komt in de ontriggerenter2D functie.
                Move();
                break;

            case movementType.raycast_detection:
                // code for raycast_detection

                // raycast left from enemy
                RaycastHit2D raycastLeft = Physics2D.Raycast(new Vector2(transform.position.x - .7f, transform.position.y), transform.TransformDirection(Vector2.down), 2);
                Debug.DrawRay(new Vector2(transform.position.x - .7f, transform.position.y), transform.TransformDirection(Vector2.down) * 2, Color.black);
                
                // raycast right from enemy
                RaycastHit2D raycastRight = Physics2D.Raycast(new Vector2(transform.position.x + .7f, transform.position.y), transform.TransformDirection(Vector2.down), 2);
                Debug.DrawRay(new Vector2(transform.position.x + .7f, transform.position.y), transform.TransformDirection(Vector2.down) *2, Color.black);

                if (raycastLeft.collider == null  || raycastRight.collider == null)
                {
                    TurnEnemy();
                }
                Move();

                break;
            case movementType.basic_jump:
                // lets the enemy jump up and down

                // let timer count down
                timer -= Time.deltaTime;

                // check if timer hits 0
                if(timer<=0)
                {
                    canJump = true;
                    timer = jumpCooldown;
                }

                // only jump when enemy hits the ground
                if (isGrounded == true && canJump == true)
                {
                    plRigidbody.AddForce(new Vector2(0, jumpForce));
                    canJump = false;
                }

                break;
            default:
                // afvalbak

                break;
        } // end switch

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemyMove == movementType.between_colliders  && collision.CompareTag(tagName))
        {
            TurnEnemy();
        }
    }


    void Move()
    {
        // keep speed enemy constant
        Vector2 enemyKeepSpeed = plRigidbody.velocity;
        enemyKeepSpeed.x = enemySpeed * enemyDirection;
        plRigidbody.velocity = enemyKeepSpeed;
    }

    void TurnEnemy()
    {
        // turn enemy
        if(gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        // wanneer de enemy ook op en neer beweegt
        Vector2 enemyTurnSpeed = plRigidbody.velocity;
        enemyTurnSpeed.x *= -1;
        enemyDirection *= -1;
        plRigidbody.velocity = enemyTurnSpeed;

    }
}
