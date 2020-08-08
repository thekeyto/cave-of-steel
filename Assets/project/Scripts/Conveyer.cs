using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour
{
    public float force;
    public int forward;
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(new Vector2(force, 0) * forward);
    }
}
