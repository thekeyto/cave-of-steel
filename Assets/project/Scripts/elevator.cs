using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public float speed;
    public float up;
    public float down;
    public int forward;
    Rigidbody2D rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 temp = new Vector2(0, speed*forward);
        rigidbody.velocity = temp;
        if ((Mathf.Abs(transform.position.y-up)<=0.5&&forward==1)|| (Mathf.Abs(transform.position.y - down) <= 0.5&&forward==-1))
        {
            forward *= -1;
        }
    }
}
