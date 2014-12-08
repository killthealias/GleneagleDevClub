using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBarLength;
	private static int healthbarwidth = 90;
	public Transform target;
	private GUIStyle currentStyle = null;
	// Use this for initialization
	void Start () {
		healthBarLength = healthbarwidth;
	}
	
	// Update is called once per frame
	void Update () {
		adjustCurrentHealth (0);
	}
	
	void OnGUI(){
		InitStyles();
		Camera cam = Camera.main;
		Vector3 targetPos = cam.WorldToScreenPoint(target.position);
		if (healthBarLength >= 9) {
			GUI.Box (new Rect ((targetPos.x - healthBarLength / 2) - 4, Screen.height - targetPos.y - 35, healthBarLength, 5), "", currentStyle);
		}
	}
	private void InitStyles()
	{
		currentStyle = new GUIStyle( GUI.skin.box );
		if(curHealth > 50){
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
		}else{
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 1f, 0f, 0f, 0.5f ) );
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
	
	public void adjustCurrentHealth(int adj){
		curHealth += adj;
		if(curHealth < 0){
			curHealth = 0;
		}
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}
		if(maxHealth < 1){
			maxHealth = 1;
		}
		healthBarLength = healthbarwidth * (curHealth / (float)maxHealth);
	}
}
