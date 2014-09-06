#pragma strict

public var moveSpeed : float = 10f;

function Start () {
}

function Update () {
	if(Input.GetKey(KeyCode.UpArrow))
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	if(Input.GetKey(KeyCode.DownArrow))
		transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
	
	
	if(Input.GetKey(KeyCode.LeftArrow))
		transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);

	if(Input.GetKey(KeyCode.RightArrow))
		transform.Translate(-Vector3.left * moveSpeed * Time.deltaTime);	

}
