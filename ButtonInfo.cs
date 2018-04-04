using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonInfo : MonoBehaviour {
	public int levelId;

	public void setLevel(int levelId){
		StaticStats.levelId = levelId;
	}
		public void setActiveScene(int levelId){
		SceneManager.LoadScene(1);
	}
}
