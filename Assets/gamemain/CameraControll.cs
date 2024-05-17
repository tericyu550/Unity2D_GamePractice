using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Camera cameraP;
    private Transform playertransform;

    void Start()
    {

        cameraP = Camera.main;
        if (GameObject.Find("player") != null)
        {
            playertransform = GameObject.Find("player").transform;
        }

    }
    void Update()
    {
        cameraP.transform.position = new Vector3(
        playertransform.position.x,
        playertransform.position.y,
        cameraP.transform.position.z);
        //因為景深的關係攝影機和角色實際上是有距離的所以Z軸不用跟著角色
    }
}
