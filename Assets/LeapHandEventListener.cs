﻿using UnityEngine;
using System.Collections;
using Leap;

// Attach this script to a HandModel object.
public class LeapHandEventListener : MonoBehaviour {
	public Transform ovr;

	public float speed = 2.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		HandModel hand_model = GetComponent<HandModel>();
		CharacterController characterController = ovr.GetComponent<CharacterController> ();

		// Examples of getting data.
		Vector3 palm_position = hand_model.GetPalmPosition();
		//Quaternion palm_rotation = hand_model.GetPalmRotation();
		//Vector3 index_tip = hand_model.fingers[1].GetTipPosition();

		Debug.Log ("characterController: "+ characterController);
		Debug.Log ("palm_position.xex : " + palm_position.x);
		Debug.Log ("palm_position.y: " + palm_position.y);
		Debug.Log ("palm_position.z: " + palm_position.z);

		//float moveX = 0;
		//float moveZ = 0;
		
		/*if(handX>120){
			moveZ = 1;
		} else if(handX<90){
			moveZ = -1;
		}
		
		if(handY<-30){
			moveX = 1;
		} else if(handY>30){
			moveX = -1;
		}*/

		Debug.Log ("characterController.isGrounded: "+ characterController.isGrounded);
		if (characterController.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			Debug.Log("moveDirection: " + moveDirection);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			Debug.Log("moveDirection: " + moveDirection);
			
		}
		//moveDirection.y -= gravity * Time.deltaTime;
		Debug.Log("Time.deltaTime: " + Time.deltaTime);
		Debug.Log("moveDirection * Time.deltaTime: " + moveDirection * Time.deltaTime);
		//characterController.Move(moveDirection * Time.deltaTime);	

	}
}