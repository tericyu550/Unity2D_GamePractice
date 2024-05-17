using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class checkInit : MonoBehaviour
{
    public static string debugScene;
    public static int startpointnumber;
    public GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.Find("player");
        if (!playerObject) {
            SceneManager.LoadScene("Init");
            debugScene = SceneManager.GetActiveScene().name;
        }
        if (startpointnumber != 0) {
            GameObject g= GameObject.Find(startpointnumber.ToString()) as GameObject;
            if (g != null) {
                playerObject.transform.position = g.transform.position;
            }
            startpointnumber = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
