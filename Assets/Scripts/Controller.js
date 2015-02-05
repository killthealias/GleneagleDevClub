#pragma strict
var is_jumping : boolean;
var is_jumping_reset : int;
function Start () {
	is_jumping = false;
}

function FixedUpdate () {
	if (Input.GetKey("left")) {
		transform.position.x -= 0.1;
	}
	if (Input.GetKey("right")) {
		transform.position.x += 0.1;
	}
}
