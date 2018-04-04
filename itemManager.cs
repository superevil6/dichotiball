using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
The item manager stores patterns that gems/items spawn in, and handles activating them.
Since there are a lot of items, object pooling will be used. 
*/
public class itemManager : MonoBehaviour {
//item pooling
public List<GameObject> scoreItems = new List<GameObject>();
public LevelManager levelManager;
public itemLists masterItemList;
public itemList currentList;
public int scoreItemPoolCount;
public GameObject prefab;
private int randomListIndex;
public bool leftManager;

	// Use this for initialization
	void Start () {
		initializeScoreItems(scoreItemPoolCount);
		resetListStatus(masterItemList);
		// StartCoroutine(findListToRun(masterItemList));
		if(levelManager.currentLevel.randomOrder){
			StartCoroutine(runRandomList(masterItemList));
		}
		else{
			StartCoroutine(findListToRun(masterItemList));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initializeScoreItems(int amount){
		for(int i = 0; i < amount; i++){
			GameObject scoreItem = (GameObject)Instantiate(prefab);
			scoreItem.SetActive(false);
			scoreItems.Add(scoreItem);
		}
	}

	public IEnumerator runRandomList(itemLists masterItemList){
		while(StaticStats.score <= levelManager.currentLevel.necessaryScore){
			randomListIndex = Random.Range(0, masterItemList.masterItemList.Length);
			runList(masterItemList.masterItemList[randomListIndex]);
			yield return new WaitForSeconds(masterItemList.masterItemList[randomListIndex].coolDownTime);
		}
	}
	public IEnumerator findListToRun(itemLists masterItemList){
		foreach(itemList list in masterItemList.masterItemList){
				runList(list);
				yield return new WaitForSeconds(list.coolDownTime);
		}
	}

	public void runList(itemList currentList){
		foreach(item item in currentList.items){
			StartCoroutine(startUpTime(item.spawnAfterSeconds, item, currentList.xOffset, currentList.yOffset, currentList.leftSide, currentList.randomizeOffset));
			// returnedObject.SetActive(true);
			print("returning object");
		}
		currentList.alreadyDone = true;

	}
	public void activateGameObject(item item, float xOffset, float yOffset, bool left, bool randomizeOffset){
		GameObject itemPrefab = (GameObject)item.scoreItem;
		for(int i = 0; i < scoreItems.Count; i++){
			if(!scoreItems[i].activeInHierarchy){
				GameObject theItem = scoreItems[i];
				SpriteRenderer sprite = theItem.GetComponent<SpriteRenderer>();
				scoreItem scoreItem = theItem.GetComponent<scoreItem>();
				sprite.color = new Color(item.color.r, item.color.g, item.color.b, item.color.a);
				// sprite.sprite = theItem.GetComponent<scoreItem>().marker;
				sprite.sprite = itemPrefab.GetComponent<scoreItem>().marker;
				scoreItem.mainSprite = itemPrefab.GetComponent<scoreItem>().mainSprite;
				scoreItem.scoreValue = itemPrefab.GetComponent<scoreItem>().scoreValue; 
				scoreItem.expireTimer = itemPrefab.GetComponent<scoreItem>().expireTimer;	
				scoreItem.sounds = itemPrefab.GetComponent<scoreItem>().sounds;
				if(!randomizeOffset){
					if(leftManager){
						theItem.GetComponent<Transform>().localPosition = new Vector3((-item.xCoord + xOffset), (item.yCoord + yOffset), 0);
					}
					else{
						theItem.GetComponent<Transform>().localPosition = new Vector3((item.xCoord + xOffset), (item.yCoord + yOffset), 0);
					}
				}
				else{
					float randomizedOffset = Random.Range(-5, 5);
					if(leftManager){
						theItem.GetComponent<Transform>().localPosition = new Vector3((-item.xCoord + randomizedOffset), (item.yCoord + randomizedOffset), 0);
					}
					else{
						theItem.GetComponent<Transform>().localPosition = new Vector3((item.xCoord + randomizedOffset), (item.yCoord + randomizedOffset), 0);
					}
				}
				theItem.SetActive(true);
				break;
			}

		}
	}

	public void resetListStatus(itemLists masterItemList){
		foreach(itemList list in masterItemList.masterItemList){
			list.alreadyDone = false;
		}
	}

	 IEnumerator startUpTime(float time, item item, float xOffset, float yOffset, bool left, bool randomizeOffset){
		yield return new WaitForSeconds(time);
		activateGameObject(item, xOffset, yOffset, left, randomizeOffset);
	 }

}