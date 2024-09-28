using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovement : MonoBehaviour
{
    public ChemicalManager cm;
    
    [SerializeField] float moveSpeed;  // Speed of the player movement
    public Rigidbody2D rb;        // Reference to the Rigidbody2D component

    Vector2 movement;  // Store the player's movement input

    // Update is called once per frame
    void Update()
    {
        // Get input from player for horizontal (left/right) and vertical (up/down) movement
        movement.x = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        movement.y = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow
        
	if (movement.x < 0)
	{
		this.transform.rotation = new Quaternion(0, -1, 0, 0);
	}
	else if(movement.x > 0)
	{
		this.transform.rotation = new Quaternion(0, 0, 0, 0);
	}
	
	if(Input.GetKeyDown(KeyCode.Mouse0))
	{
		Debug.Log("Attack");
	}
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        // Apply the movement to the player's Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
	if(other.gameObject.CompareTag("H"))
    	{
    		Debug.Log("H");
    		cm.chemicals.Add("H");
    		Destroy(other.gameObject);
    	}
    	else if(other.gameObject.CompareTag("Cl"))
    	{
    		Debug.Log("Cl");
    		cm.chemicals.Add("Cl");
    		Destroy(other.gameObject);
    	}
    	else if(other.gameObject.CompareTag("O"))
    	{
    		Debug.Log("O");
    		cm.chemicals.Add("O");
    		Destroy(other.gameObject);
    	}
    	else if(other.gameObject.CompareTag("Br"))
    	{
    		Debug.Log("Br");
    		cm.chemicals.Add("Br");
    		Destroy(other.gameObject);
    	}
    }
    
    
}
