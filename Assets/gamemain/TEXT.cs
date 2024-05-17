using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEXT : MonoBehaviour
{
    public Text textLine;
    public Image img;
    private Transform transform;
    public TextAsset textFile;
    public int a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform = this.transform;
    }
   
    //public Transform OnGetEnemy()
    //{
    //    //獲取所有敵人
    //    GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
    //    float distance_min = 100;    //主角與怪物的最近距離
    //    float distance = 0;            //當前怪物與主角的距離
    //    int id = 0;                    //與主角最近的怪物的編號
    //    //遍歷所有敵人,計算距離並比較       
    //    for (int i = 0; i < enemy.Length; i++)
    //    {
    //        if (enemy[i].activeSelf == true)
    //        {
    //            distance = Vector2.Distance(transform.position, enemy[i].transform.position);
    //            if (distance < distance_min)
    //            {
    //                //找到一個更近的

    //                distance_min = distance;
    //                distance--;
    //                id = i;
    //                Debug.Log(distance);

    //            }
    //        }
    //    }     
    //    Tatepon = enemy[id];
    //    return enemy[id].transform;
    //}
}
