using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class serializationTest : MonoBehaviour
{
    //�ǦC��
    //�i����Ƨ��ܼƭ�
    [SerializeField] 
    Item num;
    //�|���ä��|�ͦ�����
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
