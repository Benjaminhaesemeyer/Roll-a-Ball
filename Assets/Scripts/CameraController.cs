using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Variable to reference the player object.
	public GameObject player;

	//Variable to hold offset value.
	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position; 
	}
	
	// LateUpdate is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
