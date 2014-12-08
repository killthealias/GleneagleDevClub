using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		//2 seconds
		coolDown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0) {
			//decrease every frame
			attackTimer -= Time.deltaTime;
		}
		if (attackTimer < 0) {
			attackTimer = 0;
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			if(attackTimer == 0){
				Attack();
				attackTimer = coolDown;
			}
		}
		
	}

	private void Attack(){
		float distance = Vector3.Distance(target.transform.position, transform.position);
		Vector2 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector2.Dot(dir, transform.right);
		if (distance < 1.8f) {
			if((direction > 0 && transform.lossyScale.x > 0) || (direction < 0 && transform.lossyScale.x < 0)){
				BossHealth hp = (BossHealth)target.GetComponent ("BossHealth");
				hp.adjustCurrentHealth (-10);
				if(direction > 0){
					target.rigidbody2D.isKinematic = false;
					target.rigidbody2D.AddForce(new Vector2(5000, 100));
					StartCoroutine(Wait());
				}else if(direction < 0){
					target.rigidbody2D.isKinematic = false;
					target.rigidbody2D.AddForce(new Vector2(-5000,100));
					StartCoroutine(Wait());
				}
			}

		}
	}
	IEnumerator Wait () 
	{
		yield return new WaitForSeconds(0.07f);
		target.rigidbody2D.isKinematic = true;
	}
}