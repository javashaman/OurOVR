using UnityEngine;
using System.Collections;
using Leap;

// Attach this script to a HandModel object.
public class LeapHandEventListener : MonoBehaviour {
	public Transform ovr;

	private float speed = 3.11f;
	private float critical_pos_x = 0.03f;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		//X:Depth, range:0.25-0.65

		HandModel hand_model = GetComponent<HandModel>();
		CharacterController characterController = ovr.GetComponent<CharacterController> ();

		// Examples of getting data.
		Vector3 palm_position = hand_model.GetPalmPosition();
		//Quaternion palm_rotation = hand_model.GetPalmRotation();
		//Vector3 index_tip = hand_model.fingers[1].GetTipPosition();

		Vector3 offset = palm_position - ovr.position;
		offset.y = 0.0f;

		Debug.Log("palm_position: "+ palm_position);
		Debug.Log("characterController position: "+ ovr.position);
		Debug.Log ("offset: "+ offset );
		Debug.Log ("magnitude: "+ offset.magnitude );

		if (characterController.isGrounded && offset.magnitude > critical_pos_x) {
			Debug.Log("move that thang!");
			characterController.SimpleMove(offset.normalized * speed);
		}
	}
}