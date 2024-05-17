using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstercontrol : MonoBehaviour
{
    int hp = 0;
    public int max_hp = 0;
    public GameObject hp_bar;
    public enum Status {idle,walk};
    public enum Battle { follow, attack, dodge };
    public Battle BatChoose;
    public Status status;
    
    public GameObject SpearAttack;
    public enum checkface { Lelf,Right};
    public checkface face;
    public float move;
    public float speed;
    private float time1 = 5f;
    private bool LookForP;
    private float SwichCheck;
    private Transform mytransform;
    private Transform playertransform;
    private SpriteRenderer spr;
    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        max_hp = 10;
        hp = max_hp;
        status = Status.idle;
        spr = this.transform.GetComponent<SpriteRenderer>();
        //面對的方向
        if (spr.flipX )
        {
            face = checkface.Right;
        }
        else {
            face = checkface.Lelf;
        }
        mytransform = this.transform;
        if (GameObject.Find("player") != null)
        {
            playertransform = GameObject.Find("player").transform;
            LookForP = false;       
        }
        if (!LookForP && playertransform)
        {
            StartCoroutine(DoCheck());
        }
    }

   private void FixedUpdate()
    {

        float deltatime = Time.deltaTime;
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
        hp_bar.transform.localScale = new Vector3(((float)hp / (float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
        //怪物狀態
       
        switch (status) {
            case Status.idle:
                if (playertransform)
                {
                    if (time1 <= 0)
                    {
                        Domove();
                        time1 = 5;
                    }
                    time1 -= Time.deltaTime;
                }
                break;
            case Status.walk:
                switch (BatChoose)
                {
                    case Battle.follow:
                        followPlayer();
                        break;
                    case Battle.attack:
                        DoAttack();                      
                        break;
                    case Battle.dodge:
                        Dodging();
                        break;
                }
                
                if (playertransform)
                {
                    if (Mathf.Abs(mytransform.position.x - playertransform.position.x) >= 8f)
                    {
                        status = Status.idle;
                    }
                }
                break;
                
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "boll") {
            hp -= 1;
            Destroy(other.gameObject);
        }
    }
    void Domove()
    {
        move = Random.Range(-5, 5);
        if (move > 0)
            spr.flipX = true;
        else
            spr.flipX = false;
        rig.velocity = new Vector2(move, rig.velocity.y);
    }
    bool ProximityCheck()
    {
        if (Mathf.Abs(mytransform.position.x - playertransform.position.x) < 6f)
        {
            LookForP = true;
            return true;
        }
        return false;
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            if (ProximityCheck())
            {
                status = Status.walk;
                BatChoose = Battle.follow;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Waitmin()
    {
        for (; ; )
        {
            if (!ProximityCheck())
            {
                yield return new WaitForSeconds(4f);
                move = Random.Range(-5, 5);
                Debug.Log(move);
                if (move > 0)
                    spr.flipX = true;
                else
                    spr.flipX = false;
                rig.velocity = new Vector2(move, rig.velocity.y);
                
            }
            else
                break;
        }   
    }
    void followPlayer()
    {
        if (playertransform)
        {
            if (mytransform.position.x >= playertransform.position.x)
            {
                spr.flipX = false;
                face = checkface.Lelf;
            }
            else
            {
                spr.flipX = true;
                face = checkface.Right;
            }
            switch (face)
            {
                case checkface.Lelf:
                    if(Mathf.Abs(mytransform.position.x - playertransform.position.x) >= 4f)
                        mytransform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                    break;
                case checkface.Right:
                    if(Mathf.Abs(mytransform.position.x - playertransform.position.x) >= 4f)
                        mytransform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                    break;
            }
        }
        else
        {
            BatChoose = Battle.attack;
        }
    }
    void DoAttack()
    {
        StartCoroutine(Enemyfire());    
    }
    IEnumerator Enemyfire()
    {     
        for (int i=0;i<4;i++)
            yield return new WaitForSecondsRealtime(1f);
        Instantiate(SpearAttack, this.transform.position, Quaternion.identity);

    }

    void Dodging()
    { 
        
    }
}
