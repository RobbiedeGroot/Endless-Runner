using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("maximum speed the player can move")]
    public float plMaxSpeed = 4f;
    [Header("SpeedMultiplier")]
    public float plSpeedMultiplier = 2f;
    
    public LayerMask layerMask;
    
    // movement player
    private bool canDoubleJump = false;
    private Vector2 movement;
    private float moveHorizontal;
    private float moveVertical;
    private Animator animator;
    private Rigidbody2D plRigidBody;
    private bool isGrounded = true;
    private bool Jumped = false;
    private float VelocityY;
    
    // Start is called before the first frame update
    void Start()
    {
        // rigidbody connect  to variable
        plRigidBody = GetComponent<Rigidbody2D>();
        // animator connect
        animator = GetComponent<Animator>();
        
        VelocityY = plRigidBody.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        //1) Input uitlezen van onze computer/controller en wegschrijven naar moveHorizontal
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        
        //2) Horizontale beweging stoppen in een tijdelijke movement Vector
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //3) Movement vector op de speler toepassen met AddForce en de snelheid erbij optellen
        plRigidBody.AddForce(movement * plSpeedMultiplier);
        
        //4) Begrenzen van de horizontale/x snelheid van de speler
        if (plRigidBody.velocity.x > plMaxSpeed)
        {
        plRigidBody.velocity = new Vector2(plMaxSpeed,plRigidBody.velocity.y);
        }
        if (plRigidBody.velocity.x < -plMaxSpeed)
        {
        plRigidBody.velocity = new Vector2(-plMaxSpeed, plRigidBody.velocity.y);
        }
        
        if (movement == new Vector2(0, 0) && plRigidBody.velocity.y == 0)
        {
            plRigidBody.velocity = Vector2.zero;
        }   
        
        
        
        // tekenen
        Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.blue);
        
        
        //linecast schieten
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + Vector3.down, layerMask);
        
        //5) Springen waar we rekening houden met of we op de grond staan
        
        if(Input.GetButtonDown("Jump"))
        {
            if (canDoubleJump == true && Jumped == true) 
            {
                plRigidBody.AddForce(new Vector2(0,300));
                canDoubleJump = false;
                Jumped = true;
            }
            
            if (isGrounded == true && Jumped == false)
            {
                plRigidBody.AddForce(new Vector2(0,400));
                Jumped = true;
                canDoubleJump = true;
            }
            
        }
        
        //animaties below
        if (plRigidBody.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("MovingHorizon", true);
        }
        
        if (plRigidBody.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("MovingHorizon", true);
        }
        
        if (moveHorizontal == 0)
        {
            animator.SetBool("MovingHorizon", false);
        }
        
        if (plRigidBody.velocity.y > 0 && isGrounded == false)
        {
            animator.SetBool("MovingHorizon", false);
            animator.SetBool("Jump_Up", true);
        }
        
        if(plRigidBody.velocity.y < 0 && Jumped == true)
        {
            plRigidBody.AddForce(new Vector2(0, -2));
        }
        
        if (isGrounded == false && plRigidBody.velocity.y < 0 && VelocityY > plRigidBody.velocity.y)
        {
            animator.SetBool("Jump_Up", false);
            animator.SetBool("Jump_Down", true);
        }
        
        if (plRigidBody.velocity.y == 0)
        {
            animator.SetBool("Jump_Up", false);
            animator.SetBool("Jump_Down", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Jumped = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Jumped = true;
        }
    }
}