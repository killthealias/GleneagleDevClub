using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	int moveSpeed=1;
	int maxDistance=2;
	private Transform myTransform;
	Animator anim;
	void Awake() {
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target.position.x <= myTransform.position.x) //players spot in world space as opposed to enemy "self" spot 
		{ 
			myTransform.rotation = new Quaternion(0,180,0,0);// flips enemy around to face the player on x axis only 
		} else if (target.position.x >= myTransform.position.x)//players spot in world space as opposed to enemy "self" spot 
		{ 
			myTransform.rotation = new Quaternion(0,0,0,0);
		}
		if(Vector3.Distance(target.position, myTransform.position) > maxDistance) {
			if (target.position.x < myTransform.position.x){
					myTransform.position += myTransform.right * moveSpeed * Time.deltaTime; // player is left of enemy, move left
					anim.SetFloat("Speed", moveSpeed);
			}
			else if (target.position.x > myTransform.position.x){
					myTransform.position += myTransform.right * moveSpeed * Time.deltaTime; // player is right of enemy, move right
					anim.SetFloat("Speed", moveSpeed);
			}
		}else{
			anim.SetFloat ("Speed", 0);
		}
}
}
