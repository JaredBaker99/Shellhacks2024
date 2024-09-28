using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	
	if(Input.GetKeyDown(KeyCode.Escape))
	{
		Debug.Log("Lose");
		SceneManager.LoadSceneAsync(3);
	}
	
	if(Input.GetKeyDown(KeyCode.E))
	{
		Debug.Log("Win");
		SceneManager.LoadSceneAsync(2);
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
    
    
}
