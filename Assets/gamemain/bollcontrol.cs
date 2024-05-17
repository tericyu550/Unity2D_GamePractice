using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bollcontrol : MonoBehaviour
{
    public float timer=0;
    public int a = 0;
    public bool direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = playcontrol.bollsr;
      //  this.GetComponent<Rigidbody2D>().AddForce(new Vector2(25, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
       {
         this.gameObject.transform.position += new Vector3(-1f * Time.deltaTime * 60, 0, 0);
        }
       else 
     {
            this.gameObject.transform.position += new Vector3(1f * Time.deltaTime * 60, 0, 0);
       }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
