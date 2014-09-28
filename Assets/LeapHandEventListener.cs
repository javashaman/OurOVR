using UnityEngine;
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

		float offset_x = Mathf.Abs ( ovr.position.x - palm_position.x);
		Debug.Log ("offset.x: "+ offset_x );

		float critical_pos_x = 0.03f;

		//X:Depth, range:0.25-0.65

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

		Debug.Log ("IsGrounded: "+ characterController.isGrounded);
		Debug.Log ("critical_pos_x:  " + critical_pos_x);
		Debug.Log ("offset_x:  " + offset_x);
		if (characterController.isGrounded && offset_x > critical_pos_x) {
			moveDirection = new Vector3(0, 0, 1);
			Debug.Log("Inside IF: moveDirection: " + moveDirection);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			Debug.Log("Before LEAVING IF: moveDirection*=speed: " + moveDirection);
		}
		//moveDirection.y -= gravity * Time.deltaTime;
		//Debug.Log("Time.deltaTime: " + Time.deltaTime);
		Debug.Log("moveDirection * Time.deltaTime: " + moveDirection * Time.deltaTime);
		characterController.Move(moveDirection * Time.deltaTime);	

	}
}