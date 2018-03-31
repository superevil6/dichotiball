using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
public Character character;
//Sounds and Graphics
public SpriteRenderer sprite;
public Animator animator;
public AudioSource se;
public AudioClip[] sounds;

//Stats
public float speed; //Speed the ball travels
private float tempSpeed;
public float turning; //The ability to make sharp turns. Bigger balls usually have a wider radius 
public float scale; //The size of the ball


//Positioning and Movement
private Vector3 startingPosition;
private Vector3 targetPosition;
private float startTime;
private float journeyLength;
private bool isMoving = false;
public Transform ballTransform;
public BoxCollider2D boxCollider;
public Quaternion rotate;
public Rigidbody2D rb;

    void Start()
   {
       setUpCharacter(character);
   }
    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.Mouse0)){
                targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                float distance = Vector3.Distance(ballTransform.position, targetPosition);
                if(distance > 90.002f){
                    ballTransform.rotation = Quaternion.Slerp(ballTransform.rotation, rotate, Time.deltaTime * turning);
                    rotate = Quaternion.LookRotation(Vector3.forward, (targetPosition - ballTransform.position));
                    ballTransform.position +=  ballTransform.up * Time.deltaTime * speed;
                }
			}
    }
	void setUpCharacter (Character character){
        gameObject.GetComponent<SpriteRenderer>().sprite = character.sprite;
        ballTransform.localScale = new Vector3((1f * character.scale), (1f * character.scale), 1);
        speed = character.speed;
        turning = character.turning;
    }
    
}