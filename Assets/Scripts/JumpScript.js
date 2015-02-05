#pragma strict
var is_jumping : boolean;
var is_jumping_reset : int;

function FixedUpdate () {
	if (Input.GetKey("up") && is_jumping == false) {
		animation.Play();
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