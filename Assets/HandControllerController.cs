		using UnityEngine;
using System.Collections;
using Leap;

public class HandControllerController : MonoBehaviour {
	Controller controller;

	public float speed = 0.000000001F;
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

			//handX near:70/0, far:250/1
			//handY left:200, right:-200 

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


			CharacterController characterController = GetComponent<CharacterController>();
			Debug.Log("characterController.isGrounded: " + characterController.isGrounded);
			if (characterController.isGrounded) {
				moveDirection = new Vector3(moveX, 0, moveZ);
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;

				Debug.Log("moveZ: " + moveZ);
				Debug.Log("moveDirection: " + moveDirection);
				
			}
			//moveDirection.y -= gravity * Time.deltaTime;
			characterController.Move(moveDirection * Time.deltaTime);


		}
		Debug.Log("vvv   vvv   vvv   vvv   vvv   vvv   vvv   vvv");

	}
}