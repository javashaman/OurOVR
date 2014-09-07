#pragma strict

// JavaScript
function Start () {

    for (var y = 0; y < 10; y++) {
        for (var x = 0; x < 10; x++) {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent(Rigidbody);
            cube.transform.position = Vector3 (x*10, y*10, -5);
        }
    }
}

/// This script moves the character controller forward 
/// and sideways based on the arrow keys.
/// It also jumps when pressing space.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.	
public var speed : float =  .5;
public var jumpSpeed : float = 8.0;
public var gravity : float = 20.0;
private var moveDirection : Vector3 = Vector3.zero;
//private var rotationDirection : Vector3 = Vector3.zero;

public var step = 0;
function Update() {

	if (step%100 == 0)
	{
	        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent(Rigidbody);
            cube.transform.position = Vector3 (step, step, -5);
	}

            
	var controller : CharacterController = GetComponent(CharacterController);
	
	if (controller.isGrounded) {
		// We are grounded, so recalculate
		// move direction directly from axes
		moveDirection = Vector3(Input.GetAxis("Horizontal"), 0,
		                        Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		
		if (Input.GetButton ("Jump")) {
			moveDirection.y = jumpSpeed;
		}
	} else
	{
	
	}
	// Apply gravity
	moveDirection.y -= gravity * Time.deltaTime;
	
	// Move the controller
	controller.Move(moveDirection * Time.deltaTime);
}


