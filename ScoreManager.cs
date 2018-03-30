using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
public Text scoreText;
public Text timer;
public GameController gameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + StaticStats.score.ToString();
		timer.text = "Time: " + StaticStats.time.ToString();
	}
}
