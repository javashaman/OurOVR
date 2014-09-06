#pragma strict

public var target : Transform;
public var criticalDistanceHide : Number = 20;

function Start () {

}

function Update () {
	UpdateViewRelativeToObserver();
}

function UpdateViewRelativeToObserver(){
	var relativePos	 = target.transform.position - transform.position;
	var relativePosZNormalized = Mathf.Abs(Mathf.Ceil(relativePos.z));
	var relativePosXNormalized = Mathf.Abs(Mathf.Ceil(relativePos.x));
	//declare newAlpha as decimal, else later is initialized as a float
	var newAlpha = 0.000001;
	var newLightOffset;
	
	//set response to z movement
	if(relativePosZNormalized>criticalDistanceHide) {
		newAlpha=0;
	}
	else if(relativePosZNormalized<criticalDistanceHide){
		//fade-in as camera approaches
		if(relativePosZNormalized>0){
			newAlpha = ((criticalDistanceHide-relativePosZNormalized) * 0.1);
		} else {
			newAlpha = 0;
		}
	}

	renderer.material.color.a = newAlpha;

	//set response to x movement
	if(relativePosXNormalized>criticalDistanceHide) {
		newLightOffset=0;
	}
	else if(relativePosXNormalized<criticalDistanceHide){
		//fade-in as camera approaches
		if(relativePosXNormalized>0){
			newLightOffset = ((criticalDistanceHide-relativePosXNormalized) * 0.1);
		} else {
			newLightOffset = 0;
		}
	}


	
}