using UnityEngine;
using System.Collections;
using Leap;

// Attach this script to a HandModel object.
public class LeapHandEventListener : MonoBehaviour {
	public Transform ovr;

	private Controller controller;
	private float speed = 3.11f;
	private float forwards_x = 0.66f;
	private float backwards_x = 0.6f;

	void Start ()
	{
		controller = new Controller();
	}

	void Update() {
		//X: -0.65:Left, -0.35:Right

		Frame frame = controller.Frame();
		Hand realWorldHand = frame.Hands.Frontmost;
		float realWorldHandPositionX = realWorldHand.PalmPosition.x;
		HandModel hand_model = GetComponent<HandModel>();
		CharacterController characterController = ovr.GetComponent<CharacterController> ();
		GameObject camCam = GameObject.Find("OVRCameraController/CameraLeft");

		// Examples of getting data.
		Vector3 palm_position = hand_model.GetPalmPosition();
		//Quaternion palm_rotation = hand_model.GetPalmRotation();
		//Vector3 index_tip = hand_model.fingers[1].GetTipPosition();


		Vector3 offset = palm_position - characterController.transform.position;

		Debug.Log("camCam.transform.rotation.y:"+ camCam.transform.rotation.y);

		if(realWorldHandPositionX < -150){
			offset = camCam.transform.right;
			Debug.Log("RIGHT: "+ offset);
		}
		else if(realWorldHandPositionX > 50) {
			offset = -camCam.transform.right;
			Debug.Log("LEFT: "+ offset);
		}

		if (characterController.isGrounded && offset.magnitude > forwards_x) {
			characterController.SimpleMove(offset.normalized * speed);
		}
		else if (characterController.isGrounded && offset.magnitude < backwards_x) {
			characterController.SimpleMove((-offset.normalized) * speed);
		}
	}
}