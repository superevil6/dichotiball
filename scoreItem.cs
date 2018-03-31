using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreItem : MonoBehaviour {
//Stat values
public int id;
public GameController gameController;
public float scoreValue;
private float backupScoreValue;
private float onePercentOfScore;
private float tenPercentOfScore;
public float expireTimer;

//Collision related assets
public BoxCollider2D boxCollider;

//Graphics and sounds
public SpriteRenderer spriteRenderer;
public Sprite mainSprite;
public Sprite marker;
public Animator animator;
public Color color;
public AudioClip[] sounds;
public AudioSource audioSource;
public Transform itemTransform;
private float pitch; //Effects the sound of the item when spawning;
private float stereoPan; //Effects the sounds of the item based on x coords.
private bool gettable = false; //while it's startUp marker is active, it's not gettable.


	// Use this for initialization
	void Start () {
		onePercentOfScore = (scoreValue/200); 
		tenPercentOfScore = onePercentOfScore * 40;
		audioSource = gameObject.GetComponent<AudioSource>();
		setAudio();
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		// backupScoreValue = scoreValue;
		itemTransform = gameObject.transform;
		itemTransform.localScale = new Vector3(1f, 1f, 1f);
		StartCoroutine(startUpMarker(1f));
	}
	 void OnEnable()
	{
		setAudio();
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gettable = false;
		// scoreValue = backupScoreValue;
		itemTransform.localScale = new Vector3(1f, 1f, 1f);
		StartCoroutine(startUpMarker(1f));
		// StartCoroutine(disappear(expireTimer));
	}
	
	// Update is called once per frame
	void Update () {
		if(scoreValue >= tenPercentOfScore){
		scoreValue -= onePercentOfScore;
		}
		if(itemTransform.localScale.x > 0.10f && gettable){
			itemTransform.localScale -= new Vector3(0.005f, 0.005f, 0);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			StaticStats.score += Mathf.RoundToInt(scoreValue);
			boxCollider.enabled = false;
			spriteRenderer.sprite = null;
			StartCoroutine(pickedUp());
		}
	}

	IEnumerator disappear(float time){
		audioSource.clip = sounds[1];
		audioSource.Play();
		gettable = true;
		gameObject.GetComponent<SpriteRenderer>().sprite = mainSprite;
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
		yield return new WaitForSeconds(time);
		gameObject.SetActive(false);
	}

	IEnumerator startUpMarker(float time){
		audioSource.clip = sounds[0];
		audioSource.Play();
		yield return new WaitForSeconds(time);
		StartCoroutine(disappear(expireTimer));
	}

	IEnumerator pickedUp(){
		audioSource.clip = sounds[2];
		audioSource.Play();
		//animation 
		//compare the animation and the audio and see which is longer.
		yield return new WaitForSeconds(sounds[2].length);
		gameObject.SetActive(false);
	}
	void setAudio(){
		pitch = ((gameObject.transform.localPosition.y + 7f) / 1.5f);
		stereoPan = gameObject.transform.localPosition.x;
		audioSource.pitch = (pitch / 4f) + (stereoPan / 40);
	}
}
