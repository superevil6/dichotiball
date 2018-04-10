using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour {
public ScoreManager scoreManager;
public itemManager leftManager;
public itemManager rightManager;
public ItemListsHolder itemListsHolder;
public Level currentLevel;
public LevelData levelData;
	// Use this for initialization
	void Start () {
		string path = Application.streamingAssetsPath + "/LevelData.json";
		string jsonString = File.ReadAllText(path);
		levelData = JsonUtility.FromJson<LevelData>(jsonString);
		setLevel(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setLevel(int levelId){
		currentLevel.levelName = levelData.levels[levelId].levelName;
		currentLevel.leftId = levelData.levels[levelId].leftId;
		currentLevel.rightId = levelData.levels[levelId].rightId;
		leftManager.masterItemList = GetItemLists(currentLevel.leftId);
		rightManager.masterItemList = GetItemLists(currentLevel.rightId);
		currentLevel.timeLimit = levelData.levels[levelId].timeLimit;
		currentLevel.necessaryScore = levelData.levels[levelId].necessaryScore;
		currentLevel.randomOrder = levelData.levels[levelId].randomOrder;
		currentLevel.theme = levelData.levels[levelId].theme;


	}
	public itemLists GetItemLists(int id){
		return itemListsHolder.itemLists[id]; 
	} 
}
[System.Serializable]
public class Level{
	public int levelId;
	public string levelName; 
	public int theme;
	public int leftId;
	public int rightId;
	public float timeLimit;
    public int necessaryScore;
    public bool randomOrder = false;
}

[System.Serializable]
public class LevelData{
	public Level[] levels;
}