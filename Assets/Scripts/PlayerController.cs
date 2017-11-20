using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

																			//** THIS IS MY FIRST UNITY GAME **//
										//*** I'VE ADDED EXCESSIVE CODE COMMENTS TO HELP ME RETAIN KNOWLEDGE OF THE CONCEPTS COVERED IN THIS MINI PROJECT ***//

public class PlayerController : MonoBehaviour {
	
	//By creating public variables, I'm able to make changes to these properties in the unity inspector later.
	public float speed;
	public Text countText;
	public Text winText;
	public Text timeText;

	//Creating private variables can only be accessed in this script.
	private Rigidbody rb;
	private float timerInSecond;
	private int count;
	private float gameTimer; 
	private bool updateTimer; 

	//Function that runs when the game starts.
	void Start () 
	{
	//Finding and returning a reference to the attatched Rigidbody component.
		rb = GetComponent<Rigidbody>();

	//Assinging default values to the variables below.
		count = 0;
		gameTimer = 0.0f;
		timerInSecond = 0;
		updateTimer = true;
		timeText.text = "";
		SetCountText ();
		winText.text = "";
		timeText.text = "Time: " + timerInSecond.ToString ();
	}

	//Function runs at every frame after the game starts.
	void FixedUpdate ()
	{
	//Creating float values to grab input from our player through the keyboard.
		float moveHorizontal = Input.GetAxis ("Horizontal"); // Left and right keys.
		float moveVertical = Input.GetAxis ("Vertical"); // Forward and backward keys.

	//Creating a new Vector3 variable.
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

	//Accessing the rigidbody and applying vector3 value.
		rb.AddForce (movement * speed);

	//Updating the levelTimer every frame.
		if (updateTimer) {
			timeText.text = "Time: " + timerInSecond.ToString ();
			gameTimer += Time.deltaTime*1;
			timerInSecond = Mathf.Round (gameTimer);
		}
	}

	//Function runs everytime we touch a trigger collider.
	void OnTriggerEnter(Collider other) 
	{
	//If the gameObject tag matches the string value "Pick Up" we will deactivate the gameObject.
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);

	//Updating the count variable everytime we collide with a cube.
			count = count + 1;
			SetCountText ();
		}
	}

	//Function to call everytime we need to updated the count.
	void SetCountText () 
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Won!";
			gameEnded ();
		}
	}

	//Function to stop the gameTimer when the game ends
	void gameEnded ()
	{
		updateTimer = false;
		timeText.text = "Time: " + timerInSecond.ToString ();
	}
} //End of PlayerController
