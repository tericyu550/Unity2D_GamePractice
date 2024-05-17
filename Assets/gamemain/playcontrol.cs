using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class playcontrol : MonoBehaviour
{
    public float movechage = 50f;
    Rigidbody2D rigid2D;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speed_x_constraint;
    public int hp = 0;
    public int max_hp = 0;
    public int nowx, nowy, nowz;
    public GameObject bollattack;
    public Image hp_bar;
    public Animator aniplay;
    public SpriteRenderer playersr;
    public static bool bollsr;
    public int jumpcheck = 0;
    private Vector2 moveVelocity;

    private Transform EnemyTrans;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
        hp = max_hp = 20;
        StartCoroutine(GetE());
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (GUI.Button(new Rect(125, 0, 100, 50), "Confine Cursor"))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        float deltatime = Time.deltaTime;
        bool iswalking = false;
        StartCoroutine(Task());
        //move
        //if (Input.GetKeyDown(KeyCode.LeftShift)) {
        //    rigid2D.simulated = false;
        //    if (bollsr)
        //        transform.Translate(-5, 0, 0);
        //    else
        //        transform.Translate(5, 0, 0);
        //}
        //else
        //    rigid2D.simulated = true;

        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //moveVelocity = moveInput.normalized * speed;

        if (Input.GetKeyDown(KeyCode.Space) && jumpcheck < 2)
        {
            rigid2D.AddForce(new Vector2(0, 200), ForceMode2D.Impulse);//加速度推動
            jumpcheck += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (playersr.flipX == true) {
                bollsr = false;
                playersr.flipX = false;
            }
            iswalking = true;
            rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);

            //this.gameObject.transform.position += new Vector3(movechage * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (playersr.flipX == false)
            {
                bollsr = true;
                playersr.flipX = true;
            }
            iswalking = true;
            rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
            //rigid2D.AddForce(new Vector2(-100, 0), ForceMode2D.Force);
            // this.gameObject.transform.position -= new Vector3(movechage * Time.deltaTime, 0, 0);
        }

        if (iswalking)
        {
            if (aniplay.GetInteger("startw") == 0)
                aniplay.SetInteger("startw", 1);
        }
        else
        {
            if (aniplay.GetInteger("startw") == 1)
                aniplay.SetInteger("startw", 0);
        }
        //attack
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bollattack, this.transform.position, Quaternion.identity);
        }
        // if (rigid2D.velocity.x > speed_x_constraint) {
        //    rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
        //  }
        //  if (rigid2D.velocity.x < -speed_x_constraint)
        //  {
        //      rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
        //  }
        hp_bar.transform.localScale = new Vector3(((float)hp / (float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "monster") {
            hp -= 1;
            rigid2D.AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
        }
        if (coll.gameObject.tag == "Scenesobject") {
            jumpcheck = 0;
        }

    }
    public void GetEnemy()
    {
        StartCoroutine(GetE());      
        //float x;
        //if (playersr.flipX == false)
        //    x = 0;
        //else
        //    x = 180;
        //RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(Mathf.Cos(x), 0), 5, 1 << 6);
        //if (hit)
        //    EnemyTrans = hit.collider.gameObject.transform;
    }
    IEnumerator GetE()
    {
            for(; ; ) { 
            float x;
            if (playersr.flipX == false)
                x = 0;
            else
                x = 180;
            yield return new WaitForSeconds(1);
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(Mathf.Cos(x), 0), 5, 1 << 6);
            if (hit)
                EnemyTrans = hit.collider.gameObject.transform;
           // print(EnemyTrans.position);
            }      
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "teleportal")
        {
            coll.gameObject.transform.GetComponent<tpcontrol>().changeScene();
        }
    }

   IEnumerator Task() {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigid2D.simulated = false;
            if (bollsr) { 
                rigid2D.velocity = new Vector2(-speed_x_constraint*10f, rigid2D.velocity.y);
                yield return new WaitForSeconds(0.1f);
                if (rigid2D.velocity.x < -speed_x_constraint)        
                     rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
          
            }
            //transform.Translate(-300f*Time.deltaTime, 0, 0);
            else
                transform.Translate(300f * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.5f);
        }
        else
            rigid2D.simulated = true;
        
    }

    //private void FixedUpdate()
    //{
    //    rigid2D.MovePosition(rigid2D.position + moveVelocity * Time.fixedDeltaTime);
    //}
}
