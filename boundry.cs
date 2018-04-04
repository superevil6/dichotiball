using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundry : MonoBehaviour {
public BoxCollider2D boxcollider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			print("Touching the boundry");
		}
	}
}
