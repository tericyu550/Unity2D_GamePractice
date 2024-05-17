using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : MonoBehaviour
{
    //協程練習
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
        //yield return WaitUntil; yield return WaitWhile;記得查
        while (isWaiting) { 
        print("waiting");
        yield return null;  
        }      
        print("ok");
        //可以這樣用
        //  print("1");
        //yield return new WaitForSeconds(1);
        //  print("2");
        // yield return new WaitForSeconds(1);
        //  print("3");
    }
}
