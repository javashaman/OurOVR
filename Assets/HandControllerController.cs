using UnityEngine;
using System.Collections;
using Leap;

public class HandControllerController : MonoBehaviour {
	Controller controller;

	public float speed = 0.0001F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	
	void Start ()
	{
		controller = new Controller();
	}
	
	void Update ()
	{
		Frame frame = controller.Frame();
		if (frame.Hands.Count > 0) {
			Hand frontHand = frame.Hands.Frontmost;
			float handX = frontHand.PalmPosition.x;
			float handY = frontHand.PalmPosition.y;
			float handZ = frontHand.PalmPosition.z;

			Debug.Log("handX: "+ handX);
			Debug.Log("handY: "+ handY);
			Debug.Log("handZ: "+ handZ);

			//handZ 
			//handX left:200, right:-200 

			float moveX = 0;
			float moveZ = 0;

			if(handX>120){
				moveZ = 1;
			} else if(handX<90){
				moveZ = -1;
			}

			if(handY<-30){
				moveX = 1;
			} else if(handY>30){
				moveX = -1;
			}

			GameObject ovr = GameObject.Find("LeapOVRPlayerController");
			CharacterController characterController = ovr.GetComponent<CharacterController>();
			Debug.Log("characterController.isGrounded: " + characterController.isGrounded  );
			if (characterController.isGrounded) {
				moveDirection = new Vector3(moveX, 0, moveZ);
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;

				Debug.Log("moveZ: " + moveZ);
				Debug.Log("moveDirection: " + moveDirection);
				
			}
			//moveDirection.y -= gravity * Time.deltaTime;
			//characterController.Move(moveDirection * Time.deltaTime);


		}
		Debug.Log("vvv   vvv   vvv   vvv   vvv   vvv   vvv   vvv");

	}
}