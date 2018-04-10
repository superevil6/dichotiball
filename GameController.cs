using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
public LevelManager levelManager;
public int necessaryScore;
// public float timer;
public bool gameover = false;
public GameObject gameoverPanel;
public Text timerText;
public Text scoreText;

	// Use this for initialization
	void Start () {
		setUpLevel();
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameover){
			StaticStats.time -= Time.deltaTime;
			timerText.GetComponent<Text>().text = "Time: " + Mathf.RoundToInt(StaticStats.time).ToString();
			scoreText.GetComponent<Text>().text = "Score: " + StaticStats.score.ToString();
		}
		if(StaticStats.time <= 0 && !gameover){
			gameover = true;
		}
		if(StaticStats.score >= necessaryScore && !gameover){
			gameover = true;

		}
		if(gameover){
			gameoverPanel.SetActive(true);
			stopLevel();
		}
	}

	public void setUpLevel(){
		StaticStats.time = levelManager.currentLevel.timeLimit;
		necessaryScore = levelManager.currentLevel.necessaryScore;
	}
	public void stopLevel(){
		levelManager.leftManager.StopAllCoroutines();
		levelManager.rightManager.StopAllCoroutines();
	}
}
