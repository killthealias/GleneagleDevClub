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
	if (Input.GetKey("up") && is_jumping == false) {
		transform.position.y += 2;
		is_jumping = true;
		is_jumping_reset = 0;
	}
	if (is_jumping == true) {
		if (is_jumping_reset == 35) {
			is_jumping = false;
		}
		else {
			is_jumping_reset += 1;
		}
	}
}
