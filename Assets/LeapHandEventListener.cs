using UnityEngine;
using System.Collections;
using Leap;

// Attach this script to a HandModel object.
public class LeapHandEventListener : MonoBehaviour {
	public Transform ovr;
	private Controller controller;

	private float speed = 3.11f;
	private float forwards_x = 0.36f;
	private float backwards_x = 0.28f;

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

		// Examples of getting data.
		Vector3 palm_position = hand_model.GetPalmPosition();
		//Quaternion palm_rotation = hand_model.GetPalmRotation();
		//Vector3 index_tip = hand_model.fingers[1].GetTipPosition();


	    /*public Transform target;
	    void Update() {
	        Vector3 targetDir = target.position - transform.position;
	        Vector3 forward = transform.forward;
	        float angle = Vector3.Angle(targetDir, forward);
	        if (angle < 5.0F)
	            print("close");
	    }*/

		float angle = Vector3.Angle(palm_position, ovr.position);

		Debug.Log("angle: "+ angle);
		if (angle < 5.0F){
			Debug.Log("angle, angle < 5.0F: "+ angle);
		}

		Vector3 offset = palm_position - ovr.position;

		//Debug.Log("palm_position: "+ palm_position);
		//Debug.Log("characterController position: "+ ovr.position);
		//Debug.Log ("offset X: "+ offset.x );
		//Debug.Log ("offset X normalized: "+ offset.normalized.x );
		//Debug.Log ("offset Z normalized: "+ offset.normalized.z );
		//Debug.Log ("magnitude: "+ offset.magnitude );
		//Debug.Log("realWorldHandPalmPos X: "+ realWorldHand.PalmPosition.x);
		//Debug.Log("realWorldHandPalmPos Y: "+ realWorldHand.PalmPosition.y);
		//Debug.Log("realWorldHandPalmPos Z: "+ realWorldHand.PalmPosition.z);

		//RIGHT: -150 RW
		//LEFT:

		/*if(realWorldHandPositionX < -150){
			Debug.Log("RIGHT: "+ offset);
			offset.z = 0.0f;
		}
		else if(realWorldHandPositionX > 70) {
			Debug.Log("LEFT: "+ offset);
			offset.forwards_x = 0.0f;
		}*/



		if (characterController.isGrounded && offset.magnitude > forwards_x) {
			characterController.SimpleMove(offset.normalized * speed);
		}
		else if (characterController.isGrounded && offset.magnitude < backwards_x) {
			characterController.SimpleMove((-offset.normalized) * speed);
		}
	}
}