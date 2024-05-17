using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tpcontrol : MonoBehaviour
{
    public string tpname;
    public int pointName;
    void Start()
    {
        this.transform.tag = "teleportal";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeScene() {
        SceneManager.LoadScene(tpname);
        checkInit.startpointnumber = pointName;
    }
}
