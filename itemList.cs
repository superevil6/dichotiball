using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemList", menuName = "ItemList", order = 1)]
public class itemList : ScriptableObject {

    public List<item> items = new List<item>();
    public bool leftSide; //Either adds or subtracts a set amount for the x axis so it's on the left/right side
    public bool randomizeOffset = false;
	public bool alreadyDone = false; //This is checked once it's done so it can start the next list or finish the level.
    public float coolDownTime = 1;
    public float xOffset = 0;
    public float yOffset = 0;

}
[System.Serializable]
public class item{
    //This is a colletion of which item id, which 
    public GameObject scoreItem;
    public float xCoord;
    public float yCoord;
	public float spawnAfterSeconds;
	public float duration;
    public Color color;

}
