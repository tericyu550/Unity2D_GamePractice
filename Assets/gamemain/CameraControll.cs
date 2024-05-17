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
        //�]�����`�����Y��v���M�����ڤW�O���Z�����ҥHZ�b���θ�ۨ���
    }
}
