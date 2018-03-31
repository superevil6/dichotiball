using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {
public SpriteRenderer spriteRenderer;
public Sprite sprite;
public AudioClip[] sounds;
public AudioSource audioSource;
public BoxCollider2D boxCollider;
public Type type;
public enum Type {
	DoubleScore,
	QuadScoreSmallBall,
	GiantBall,
	SpeedBall,
	TimeBoost,
	DecayStop,
	InvisBall,
	SmoothTurning,
	Skull,
	Key
};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			if(type == Type.DoubleScore){
				other.gameObject.GetComponent<PowerUpManager>().StartCoroutine("DoubleScore");
			}
			if(type == Type.QuadScoreSmallBall){
				other.gameObject.GetComponent<PowerUpManager>().StartCoroutine("QuadScoreHalfSize");
			}
			if(type == Type.GiantBall){
				other.gameObject.GetComponent<PowerUpManager>().StartCoroutine("GiantBall");
			}
			if(type == Type.SpeedBall){
				other.gameObject.GetComponent<PowerUpManager>().StartCoroutine("SpeedBall");
			}
			if(type == Type.SmoothTurning){
				other.gameObject.GetComponent<PowerUpManager>().StartCoroutine("SmoothTurning");
			}
			gameObject.SetActive(false);
		}
	}
}
