using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themes : MonoBehaviour {
public Theme[] themes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class Theme{
public string themeName;
public Sprite[] scoreItemSprites;
public RuntimeAnimatorController[] scoreItemAnimations;
public Sprite backgroundImage;
public Sprite markerSprite;
public AudioClip bgm;
public AudioClip[] scoreItemMarker;
public AudioClip[] scoreItemAppear;
public AudioClip[] socreItemPickup;

}
