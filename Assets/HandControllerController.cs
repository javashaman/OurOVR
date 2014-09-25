using UnityEngine;
using System.Collections;
using Leap;

public class HandControllerController : MonoBehaviour {
	Controller controller;
	
	void Start ()
	{
		controller = new Controller();
	}
	
	void Update ()
	{
		Frame frame = controller.Frame();
		if (frame.Hands.Count > 0) {
			Hand frontHand = frame.Hands.Frontmost;

			Debug.Log("HandPos Y: " + frontHand.PalmPosition.y);
			Debug.Log("HandPos X: " + frontHand.PalmPosition.x);



			//PointableList pointables = frontHand.Pointables;
			/*FingerList indexFingerList = frontHand.Fingers.FingerType(Finger.FingerType.TYPE_INDEX);
			Finger indexFinger = indexFingerList[0];
			if(indexFinger.IsValid && indexFinger.IsExtended){
				Debug.Log("Index Finger: " + indexFinger);
				Debug.Log("indexFinger_X: "+indexFinger.TipPosition.x);
				Debug.Log("indexFinger_Y: "+indexFinger.TipPosition.y);
			}*/
		}
		Debug.Log("vvv   vvv   vvv   vvv   vvv   vvv   vvv   vvv");

	}
}