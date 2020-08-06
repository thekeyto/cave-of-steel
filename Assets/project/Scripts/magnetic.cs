using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetic : MonoBehaviour
{
    public float magneticforce=30;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce((transform.position - collision.transform.position)/Vector2.Distance(transform.position, collision.transform.position) * magneticforce);           
        }
    }
}
