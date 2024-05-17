using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initplayer : MonoBehaviour
{
    public string startScene;
    void Start()
    {
        if (checkInit.debugScene == null)
        {
            SceneManager.LoadScene(startScene);
        }
        else {
            SceneManager.LoadScene(checkInit.debugScene);
            checkInit.debugScene = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
