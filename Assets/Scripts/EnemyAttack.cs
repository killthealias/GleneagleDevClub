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
		}
		if(attackTimer == 0){
			Attack();
			StartCoroutine(Wait (0.6f));
			attackTimer = coolDown;
		}

		
	}
	
	private void Attack(){
		float distance = Vector3.Distance (target.transform.position, transform.position);
		Vector2 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector2.Dot(dir, transform.right);
		if (distance < 2f) {
			anim.SetBool("Attacking", true);
			PlayerHealth hp = (PlayerHealth)target.GetComponent ("PlayerHealth");
			hp.adjustCurrentHealth (-10);
			target.GetComponent<Animator>().SetFloat("Health", hp.curHealth);
			if(hp.curHealth <= 0){
				target.rigidbody2D.isKinematic = true;
				Vector3 temp = new Vector3(0,-7.5f,0);
				target.transform.position = temp;
				StartCoroutine(StopGame ());
			}else{
			target.GetComponent<Animator>().SetBool("Hurt", true);
			StartCoroutine(WaitAnim (0.5f));
			}
			if(target.transform.position.x > transform.position.x){
				//on left, so push right
				target.rigidbody2D.AddForce(new Vector2(5000, 100));
			}else if(target.transform.position.x < transform.position.x){
				//on right, so push left
				target.rigidbody2D.AddForce(new Vector2(-5000,100));
			}

		}
	}
	IEnumerator Wait (float time) 
	{
		yield return new WaitForSeconds(time);
		anim.SetBool("Attacking", false);
	}
	IEnumerator WaitAnim (float time) 
	{
		yield return new WaitForSeconds(time);
		target.GetComponent<Animator>().SetBool("Hurt", false);
	}
	IEnumerator StopGame () 
	{
		yield return new WaitForSeconds(2.4f);
		Time.timeScale = 0;
	}
}
