#pragma strict



function Start () {

}

public var moveSpeed : float = 10f;
public var turnSpeed : float = 50f;

function Update() {
    if(Input.GetKey(KeyCode.W))
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    
    if(Input.GetKey(KeyCode.S))
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    
    if(Input.GetKey(KeyCode.D))
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    
    if(Input.GetKey(KeyCode.A))
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    
    if(Input.GetKey(KeyCode.E))
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    
    if(Input.GetKey(KeyCode.Q))
        transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
}