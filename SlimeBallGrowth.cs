using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBallGrowth : MonoBehaviour {
	public Ball ball;
	// Use this for initialization
	void Start () {
		ball = gameObject.GetComponentInParent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ball.type == Ball.ballType.slimeBall){
            ball.transform.localScale += new Vector3((Time.time / 3000f), (Time.time / 3000f), 0);
        }
	}
}
