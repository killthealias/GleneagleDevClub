using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;
	public float knockback;
	Animator anim;
	// Use this for initialization
	void Start () {
		knockback = 2;
		attackTimer = 0;
		//5 seconds
		coolDown = 5.0f;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0) {
			//decrease every frame
			attackTimer -= Time.deltaTime;
		}
		if (attackTimer < 0) {
			attackTimer = 0;
			anim.SetBool("Attacking", false);
		}
		if (attackTimer == 1) {

		}
		if(attackTimer == 0){
			Attack();
			attackTimer = coolDown;
		}

		
	}
	
	private void Attack(){
		float distance = Vector3.Distance (target.transform.position, transform.position);
		Vector2 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector2.Dot(dir, transform.right);
		if (distance < 2f) {
			PlayerHealth hp = (PlayerHealth)target.GetComponent ("PlayerHealth");
			hp.adjustCurrentHealth (-10);

			if(direction > 0){
				target.rigidbody2D.mass = 0.1f;
				target.rigidbody2D.AddForce(new Vector2(500, 10));
				StartCoroutine(Wait ());
			}else if(direction < 0){
				target.rigidbody2D.mass = 0.1f;
				target.rigidbody2D.AddForce(new Vector2(-500,10));
				StartCoroutine(Wait ());
			}

		}
	}
	IEnumerator Wait () 
	{
		yield return new WaitForSeconds(0.07f);
		target.rigidbody2D.mass = 1f;
	}
}
