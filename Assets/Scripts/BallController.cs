using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public GameController gameController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.transform.name == "Ground") {
			gameController.ResetScore();//.SendMessage("resetScore");
			GetComponent<AudioSource>().Play();
		}
}
}
