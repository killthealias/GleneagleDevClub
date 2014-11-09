using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	//array of all backgrounds and foregrounds for parallaxing
	public Transform[] backgrounds;
	//proportion of the camera's movement for parallaxing
	public float[] parallaxScales;
	//how smoother the parallaxing is
	public float smoothing = 1f;

	//reference to transform of main camera
	private Transform cam;
	//contains x,y,z locations in a tuplet (prev. frame)
	private Vector3 previousCamPosition;

	//Called before Start() - init function
	void Awake(){
		// set up camera reference
		cam = Camera.main.transform;
	}

	void Start () {
		//assign previousCamPosition to current camera pos.
		previousCamPosition = cam.position;

		//sets length of parallaxScales array to length of backgrounds
		parallaxScales = new float[backgrounds.Length];

		//loop through # of backgrounds
		for (int i = 0; i < backgrounds.Length; i++) {
			//sets i pos of parallaxScales to i pos of backgrounds
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			//parallax is opposite of camera movement
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
			//current pos + parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			// parallax is only x - y and z stay the same
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			//fade to target location using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime); //time.deltaTime converts frames to seconds
		}

		// set previousCamPosition to camera's position
		previousCamPosition = cam.position;
	}
}
