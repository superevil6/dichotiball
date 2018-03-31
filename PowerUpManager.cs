using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
// public ScoreManager scoreManager;
public float powerUpTime;

	// Use this for initialization
	void Start () {
		// float powerupBoost = gameObject.GetComponent<Ball>().specialTimeBoost;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator DoubleScore(){
		StaticStats.scoreMultiplier = 2f;
		yield return new WaitForSeconds(powerUpTime * gameObject.GetComponent<Ball>().specialTimeBoost);
		StaticStats.scoreMultiplier = 1f;
	}
	public IEnumerator QuadScoreHalfSize(){
		StaticStats.scoreMultiplier = 4f;
		gameObject.transform.localScale = new Vector2((gameObject.transform.localScale.x / 2), (gameObject.transform.localScale.y / 2));
		yield return new WaitForSeconds(powerUpTime * gameObject.GetComponent<Ball>().specialTimeBoost);
		gameObject.transform.localScale = new Vector2((gameObject.transform.localScale.x * 2), (gameObject.transform.localScale.y * 2));
		StaticStats.scoreMultiplier = 1f;
	}
	public IEnumerator GiantBall(){
		gameObject.transform.localScale = new Vector2((gameObject.transform.localScale.x * 2), (gameObject.transform.localScale.y * 2));
		yield return new WaitForSeconds(powerUpTime);
		gameObject.transform.localScale = new Vector2((gameObject.transform.localScale.x / 2), (gameObject.transform.localScale.y / 2));
	}
	public IEnumerator SmoothTurning(){
		float tempTurning = gameObject.GetComponent<Ball>().turning;
		gameObject.GetComponent<Ball>().turning = 100;
		yield return new WaitForSeconds(powerUpTime * gameObject.GetComponent<Ball>().specialTimeBoost);
		gameObject.GetComponent<Ball>().turning = tempTurning;
	}
	public IEnumerator SpeedBall(){
		float tempSpeed = gameObject.GetComponent<Ball>().speed;
		gameObject.GetComponent<Ball>().speed = tempSpeed * 2;
		yield return new WaitForSeconds(powerUpTime * gameObject.GetComponent<Ball>().specialTimeBoost);
		gameObject.GetComponent<Ball>().speed = tempSpeed;
	}
}
