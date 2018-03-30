using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level", menuName = "level", order = 2)]
public class itemLists : ScriptableObject{
    public itemList[] masterItemList;
    public float timeLimit;
    public int necessaryScore;
    public bool randomOrder = false;

}
