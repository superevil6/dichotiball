using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
public int basePointInterval;
private int pointInterval;
public PowerUpItem[] powerUps;
public List<GameObject> powerupPool = new List<GameObject>();
public GameObject prefab;
public int powerupPoolCount;
public GameObject canvas;

	// Use this for initialization
	void Start () {
		pointInterval = basePointInterval;
		setupPool();
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticStats.score >= pointInterval){
			spawnPowerup();
			pointInterval += basePointInterval;
		}
	}

	public void setupPool(){
		for(int i = 0; i < powerupPoolCount; i++){
			GameObject gameObject = Instantiate(prefab);
			gameObject.transform.SetParent(canvas.transform);
			powerupPool.Add(gameObject);
			gameObject.SetActive(false);
		}
	}
	public void spawnPowerup(){
		int powerUpIndex = Random.Range(0, powerUps.Length);
		foreach(GameObject powerup in powerupPool){
			if(!powerup.activeInHierarchy){
				rollPowerupType(powerup);
				powerup.transform.localPosition = returnPosition();
				powerup.SetActive(true); 
				break;
			}
		}

	}
	public Vector3 returnPosition(){
		float xPos = Random.Range(0, Screen.width/4);
		float yPos = Random.Range(0, Screen.height/4);
		return new Vector3(xPos, yPos, 0); 
	}
	public GameObject rollPowerupType(GameObject powerup){
		int powerupTypeIndex = Random.Range(0, powerUps.Length);
		powerup.GetComponent<PowerUpItem>().spriteRenderer.sprite = powerUps[powerupTypeIndex].GetComponent<SpriteRenderer>().sprite;
		powerup.GetComponent<PowerUpItem>().type = powerUps[powerupTypeIndex].type;
		// powerup.GetComponent<AudioSource>().clip = powerUps[powerupTypeIndex].audioSource.clip;
		return powerup;
	}
}
