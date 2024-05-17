using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "myObjectDB", menuName = "mycreateObjectDB")]
public class MyObjectDataBase : ScriptableObject
{
    public List<MyObject>List;
    
}
