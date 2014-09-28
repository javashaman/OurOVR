using UnityEngine;
using System.Collections;
using Leap;

public class HandControllerController : MonoBehaviour {
	Controller controller;

	public float speed = 200.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	int framecount = 0;
	//debug
	bool console_br = false;

	void Start ()
	{
		controller = new Controller();
	}

	void Update ()
	{
		framecount++;

		Frame frame = controller.Frame();
		if (frame.Hands.Count > 0) {
			Hand frontHand = frame.Hands.Frontmost;
			float handX = frontHand.PalmPosition.x;
			float handY = frontHand.PalmPosition.y;
			Debug.Log("handX: "+ handX);
			Debug.Log("handY: "+ handY);

			// local
			float depth = handY;
			float horizon = handX;

			// ranges
			float MIN_HORIZON = 150;
			float MAX_HORIZON = -150;
			float MIN_DEPTH = 150;
			float MAX_DEPTH = 200;

			GameObject ovr = GameObject.Find("LeapOVRPlayerController");
			CharacterController characterController = ovr.GetComponent<CharacterController>();
			// character controller.transform.rotation.y
			Debug.Log("characterController.transform.rotation.y: " + characterController.transform.rotation.y);
			if (characterController.isGrounded) {
				Debug.Log("characterController.isGrounded");
				if (depth > MIN_DEPTH)
				{
					Debug.Log("depth > MIN_DEPTH");
					/*
					moveDirection = new Vector3(0,1,0);
					moveDirection = transform.TransformDirection(moveDirection);
					moveDirection *= speed;
					*/

					//Vector3 forward = transform.TransformDirection(Vector3.forward);
					Vector3 forward = new Vector3(0,0,1);
					//get camera's quaternion
					GameObject ovrcameracontroller = GameObject.Find("OVRCameraController");
					Debug.Log("ovrcameracontroller: "+ovrcameracontroller);
					Quaternion camRot = ovrcameracontroller.transform.rotation;
					Quaternion charRot = characterController.transform.rotation;

					Debug.Log("camRot.y: "+camRot.y);
					Debug.Log("charRot.y: "+charRot.y);

				      //characterController.SimpleMove(direction* 30f);
				      Debug.Log("Vector3.forward: "+Vector3.forward);
				      Debug.Log("forward: "+forward);
				}
				//Debug.Log("moveDirection: " + moveDirection);
			}
			//moveDirection.y -= gravity * Time.deltaTime;
			//characterController.Move(moveDirection * Time.deltaTime);


		}
		Debug.Log("vvv   vvv   vvv   vvv   vvv   vvv   vvv   vvv");

	}
}