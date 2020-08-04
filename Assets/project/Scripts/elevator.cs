using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public float speed;
    public float time;
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
        StartCoroutine(waitforElevator());
    }
    IEnumerator waitforElevator()
    {
        yield return new WaitForSeconds(time);
        forward *= -1;
    }
}
