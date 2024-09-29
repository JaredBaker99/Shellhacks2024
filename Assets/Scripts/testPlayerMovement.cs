using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testPlayerMovement : MonoBehaviour
{
    public ChemicalManager cm;
    
    [SerializeField] float movementSpeed;  // Speed of the player movement
    public Rigidbody2D rb;        // Reference to the Rigidbody2D component
    private Vector2 moveDirection;
    // Vector2 movement;  // Store the player's movement input

	[SerializeField] float health; 


	public GameObject swing;

	[SerializeField] float swingTime; 

	[SerializeField] float timeBetweenSwings; 
	SpriteRenderer swingSprite;
	Animator swingAnimator;

	BoxCollider2D swingCollider;

	Boolean canSwing;

	float remainingTime;

	float swingCooldown;

	void Start(){
		swingAnimator = swing.GetComponent<Animator>();
		swingCollider = swing.GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        // Get input from player for horizontal (left/right) and vertical (up/down) movement
        // movement.x = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        // movement.y = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow
        // if (movement.x < 0)
        // {
        //   this.transform.rotation = new Quaternion(0, -1, 0, 0);
        // }
        // else if(movement.x > 0)
        // {
        //   this.transform.rotation = new Quaternion(0, 0, 0, 0);
        // }

        if(Input.GetKeyDown(KeyCode.Mouse0) && canSwing)
        {
          remainingTime = swingTime;
          swingCooldown = timeBetweenSwings;
          swing.GetComponent<SpriteRenderer>().enabled = true;
          swingCollider.enabled = true;
          canSwing = false;
          //swingAnimator.enabled = true;
          Debug.Log("Attack");
        }
        if(remainingTime > 0.5f){
          remainingTime-= Time.deltaTime;
        }
        else if(remainingTime < 0.5){
          swing.GetComponent<SpriteRenderer>().enabled = false;
          swingCollider.enabled = false;
        }


        if(swingCooldown > 0.5f){
          swingCooldown-= Time.deltaTime;
        }
        else if(swingCooldown < 0.5f){
          canSwing = true;
        }

        if(health < 0){
          Debug.Log("health");
        }
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        // Apply the movement to the player's Rigidbody2D
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Move();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
	if(other.gameObject.CompareTag("H"))
    	{
    		cm.AddChemical("H");
    		Destroy(other.gameObject);
    	}
    	else if(other.gameObject.CompareTag("Cl"))
    	{
    		cm.AddChemical("Cl");
    		Destroy(other.gameObject);
    	}
    	else if(other.gameObject.CompareTag("O"))
    	{
    		cm.AddChemical("O");
    		Destroy(other.gameObject);
    	}
    	else if(other.gameObject.CompareTag("Br"))
    	{
    		cm.AddChemical("Br");
    		Destroy(other.gameObject);
    	}
    }
    
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move () 
    {
            rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
    
}
