using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetic : MonoBehaviour
{
    public float magneticforce=3;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "box")
        {
            collision.GetComponent<Rigidbody2D>().AddForce((transform.position - collision.transform.position) * magneticforce);
            Debug.Log("magnetic");
        }
    }
}
