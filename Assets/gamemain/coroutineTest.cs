using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : MonoBehaviour
{
    //��{�m��
    bool isWaiting;
    void Start()
    {
        isWaiting = true;
        StartCoroutine(Task());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            isWaiting = false;
        }
    }
    
    IEnumerator Task() 
    {
        //yield return WaitUntil; yield return WaitWhile;�O�o�d
        while (isWaiting) { 
        print("waiting");
        yield return null;  
        }      
        print("ok");
        //�i�H�o�˥�
        //  print("1");
        //yield return new WaitForSeconds(1);
        //  print("2");
        // yield return new WaitForSeconds(1);
        //  print("3");
    }
}
