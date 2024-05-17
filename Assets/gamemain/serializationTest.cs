using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class serializationTest : MonoBehaviour
{
    //序列化
    //可實體化改變數值
    [SerializeField] 
    Item num;
    //會隱藏不會生成實體
    //[NonSerialized]
    //public int num;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class Item {
    [SerializeField]
    string name;
    [SerializeField]
    int value;

}
