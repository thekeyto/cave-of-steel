using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    public Transform ReBirth;
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&Input.GetKeyDown(KeyCode.I))
        {
            if (!audio.isPlaying) audio.Play();
            ReBirth.position = transform.position;
        }
    }
}
