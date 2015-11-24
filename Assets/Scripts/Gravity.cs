using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
	
	public float speed = 1000;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 gravity = new Vector2 (Input.GetAxis ("Horizontal"), 0 /*Input.GetAxis ("Vertical")*/) * Time.deltaTime * speed;
		gravity += new Vector2 (Input.acceleration.x, 0/*Input.acceleration.y*/) * Time.deltaTime * speed;
		Physics2D.gravity = gravity + new Vector2 (0, Physics2D.gravity.y);
//		print (gravity);
		
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}
}
