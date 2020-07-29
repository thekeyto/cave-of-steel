using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float normalspeed = 5;
    //public float rushspeed = 15;
    public float jumpSpeed = 30;
    public bool ifground = true;
    //public float gravity = 3.0f;
    public bool canleft = true;
    public bool canright = true;
    //public bool canrush = true;
    public bool canjump = true;
    //public bool flyrush = false;
    public bool cancrouch = false;
    public bool[] chip=new bool[10];

    CapsuleCollider2D collider;
    Animator animator;
    Rigidbody2D rigidbody;
    int isflip = 0;
    float rushCoolTime;//冲刺时间
    float coolrush = 1;//冲刺冷却
    bool rushflag = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnTheGround();
        //if (canrush==true) Rush();
        if (rushflag==false) Run();
        if (canjump==true&&rushflag==false) Jump();
        if (cancrouch) Crouch();
    }
    void Crouch()
    {
        animator.SetBool("crouch", true);
    }
    /*void Rush()
    {
        float rushdir=0;
        rushCoolTime += Time.deltaTime;
        coolrush += Time.deltaTime;
        rushCoolTime = rushCoolTime > 10 ? 10 : rushCoolTime;
        coolrush = coolrush > 10 ? 10 : coolrush;
        float v = Input.GetAxis("Horizontal");
        if (v>0) rushdir = 1;
        else if (v<0) rushdir = -1;
        if (coolrush>0.7f&&rushflag==false&&rushdir!=0&&((ifground==false&&flyrush==false)||(ifground==true)))
        {
            if (ifground == false) flyrush = true;
            rigidbody.gravityScale=0;
            rushflag = true;
            Vector2 playervel = new Vector2(rushspeed*rushdir, 0);
            rigidbody.velocity = playervel;
            Flip(rushdir);
            animator.SetBool("Run", true);
            rushCoolTime = 0;
            coolrush = 0;
        }
        if (rushCoolTime > 0.3f && rushflag == true)
        {
            rigidbody.gravityScale = gravity;
            rushflag =false;animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
        }
    }*/
    bool CheckOnTheGround()
    {
        ifground = collider.IsTouchingLayers(LayerMask.GetMask("ground"));
        //if (ifground == true) flyrush = false;
        return ifground;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&ifground==true)
        {
            Vector2 jumpvel = new Vector2(rigidbody.velocity.x, jumpSpeed);
            rigidbody.velocity = Vector2.up * jumpvel;
            animator.SetBool("Jump", true);
        }
        else animator.SetBool("Jump", false);
    }
    void Run()
    {
        float v = Input.GetAxis("Horizontal");
        if (v != 0)
        {
            if (v < 0 && canleft == false) return;
            if (v > 0 && canright == false) return;
            Vector2 playervel = new Vector2(v * normalspeed, rigidbody.velocity.y);
            rigidbody.velocity = playervel;
            Flip(v);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
        }
    }
    void Flip(float v)
    {
        Vector3 temp = transform.localScale;
        if ((v > 0.1f && isflip == 1) || (v < -0.1f && isflip == 0))
        {
            temp.x *= -1;
            isflip ^= 1;
        }
        transform.localScale = temp;
    }
}