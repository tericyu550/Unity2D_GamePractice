using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public float BGspeed = 0.1f;
    public Renderer BG;
    void Start()
    {
        BG = GetComponent<Renderer>();
    }
    void Update()
    {
        BG.material.mainTextureOffset = new Vector2(Time.time * BGspeed, 0);
    }
}
