using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptableObjectTest : MonoBehaviour
{
    [SerializeField]
    MyObjectDataBase obj;
    // Start is called before the first frame update
    void Start()
    {     
        readData(0);
        readData(1);
    }
    void readData(int num) { 
    // print(obj.myObjectList[num].name+"/"+"atk:"+obj.myObjectList[num].attack);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
