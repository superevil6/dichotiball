using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "character", order = 3)]
public class Character : ScriptableObject {
public float speed;
public float scale;
public Sprite sprite;
public AudioClip[] sounds;
public AnimationClip[] animations;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
