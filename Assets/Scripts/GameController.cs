using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	RuntimePlatform platform = Application.platform;

	public GameObject ball;
	public float upSpeed, sideSpeed,torqueFactor;//, accelerationFactor;
	public int score, highscore;
	public Text scoreText, highscoreText;

	// Use this for initialization
	void Start ()
	{
		score = 0;
		highscore = PlayerPrefs.GetInt ("highscore", 0);
		highscoreText.text = highscore + "";

	}


	void Update ()
	{
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					checkTouch (Input.GetTouch (0).position);
				}
			}
		} else if (platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.OSXEditor) {
			if (Input.GetMouseButtonDown (0)) {
				checkTouch (Input.mousePosition);
			}
		}
	}
	
	void checkTouch (Vector3 pos)
	{
		Vector3 wp = Camera.main.ScreenToWorldPoint (pos);
		Vector2 touchPos = new Vector2 (wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint (touchPos);

		//print (hit.transform.position);

		if (hit && hit.transform.gameObject.name == ball.transform.name) {
			ball.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (
																	//0,
				 													touchPos.x * -sideSpeed,
																	//Input.acceleration.x,
																	Vector2.up.y * upSpeed));

			ball.GetComponent<Rigidbody2D> ().AddTorque(torqueFactor * Random.Range(-1,2));

			IncScore ();

			GetComponent<AudioSource>().Play();
		}

	}

	void IncScore ()
	{
		score++;
		scoreText.text = score + "";
		if (score > highscore) {
			highscore = score;
			highscoreText.text = highscore + "";
			PlayerPrefs.SetInt ("highscore", highscore);
		}
	}

	public void ResetScore ()
	{
		score = 0;
		scoreText.text = "0";
	}
}
