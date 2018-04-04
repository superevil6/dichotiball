using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
public LevelData levelData;
public Button buttonPrefab;
public List<Button> levelButtons = new List<Button>();
public GameObject levelPanel;

	// Use this for initialization
	void Start () {
		string path = Application.streamingAssetsPath + "/LevelData.json";
		print(path);
		string jsonString = File.ReadAllText(path);
		levelData = JsonUtility.FromJson<LevelData>(jsonString);
		generateLevelButtons();
		showButtons(levelButtons);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void generateLevelButtons(){
		foreach(Level level in levelData.levels){
			Button button = (Button)Instantiate(buttonPrefab);
			button.GetComponentInChildren<Text>().text = level.levelName;
			button.GetComponentInChildren<ButtonInfo>().levelId = level.levelId;
			levelButtons.Add(button);
		}
	}

	public void showButtons(List<Button> buttons){
		foreach(Button button in buttons){
			button.transform.SetParent(levelPanel.transform, false);
		}
	}


}
