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
    //    //����Ҧ��ĤH
    //    GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
    //    float distance_min = 100;    //�D���P�Ǫ����̪�Z��
    //    float distance = 0;            //��e�Ǫ��P�D�����Z��
    //    int id = 0;                    //�P�D���̪񪺩Ǫ����s��
    //    //�M���Ҧ��ĤH,�p��Z���ä��       
    //    for (int i = 0; i < enemy.Length; i++)
    //    {
    //        if (enemy[i].activeSelf == true)
    //        {
    //            distance = Vector2.Distance(transform.position, enemy[i].transform.position);
    //            if (distance < distance_min)
    //            {
    //                //���@�ӧ��

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
