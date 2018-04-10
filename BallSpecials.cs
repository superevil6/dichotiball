using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpecials : MonoBehaviour {

public Ball ball;

	// Use this for initialization
	void Start () {
		if(ball.type == Ball.ballType.slimeBall){
            gameObject.AddComponent<SlimeBallGrowth>();
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
