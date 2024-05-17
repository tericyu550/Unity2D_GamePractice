using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData",menuName ="NewItem")]
public class MyObject : ScriptableObject
{
    public string ItemName;
    //public int attack;
    public int amount;
    public string Introduce;
    public Sprite sp;
}
