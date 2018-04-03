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
public float specialTimeBoost;


//Positioning and Movement
public bool leftBall;
private int leftId;
private int rightId;
private Vector3 startingPosition;
private Vector3 targetPosition;
private float startTime;
private float journeyLength;
private bool isMoving = false;
public Transform ballTransform;
public BoxCollider2D boxCollider;
public Quaternion rotate;
public Rigidbody2D rb;
public List<Touch> touches = new List<Touch>();

    void Start()
   {
       setUpCharacter(character);
   }
    // Update is called once per frame
    void Update () {

            if(Input.touchCount > 0){
                foreach(Touch touch in Input.touches){
                    if(touch.phase == TouchPhase.Began && touch.position.x > Screen.width /2){
                        leftId = touch.fingerId;
                    }
                    if(touch.phase == TouchPhase.Began && touch.position.x < Screen.width /2){
                        rightId = touch.fingerId;
                    }
                
                    if(touch.fingerId == leftId && touch.position.x > Screen.width /2 && !leftBall){
                        targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0);
                        float distance = Vector3.Distance(ballTransform.position, targetPosition);
                        if(distance > 90.002f){
                            ballTransform.rotation = Quaternion.Slerp(ballTransform.rotation, rotate, Time.deltaTime * turning);
                            rotate = Quaternion.LookRotation(Vector3.forward, (targetPosition - ballTransform.position));
                            ballTransform.position +=  ballTransform.up * Time.deltaTime * speed;
                        }
                    }
                    if(touch.fingerId == rightId && touch.position.x < Screen.width /2 && leftBall){
                        targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0);
                        float distance = Vector3.Distance(ballTransform.position, targetPosition);
                        if(distance > 90.002f){
                            ballTransform.rotation = Quaternion.Slerp(ballTransform.rotation, rotate, Time.deltaTime * turning);
                            rotate = Quaternion.LookRotation(Vector3.forward, (targetPosition - ballTransform.position));
                            ballTransform.position +=  ballTransform.up * Time.deltaTime * speed;
                        }
                    }
                
                }
            }            
        
    }
	void setUpCharacter (Character character){
        gameObject.GetComponent<SpriteRenderer>().sprite = character.sprite;
        ballTransform.localScale = new Vector3((1f * character.scale), (1f * character.scale), 1);
        speed = character.speed;
        turning = character.turning;
        specialTimeBoost = character.specialTimeBoost;
    }
    
}