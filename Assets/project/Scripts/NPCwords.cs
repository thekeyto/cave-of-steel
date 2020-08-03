using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCwords : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas conversation;
    public Text text;

    private void OnTriggerStay2D(Collider2D collision)
    {
        conversation.gameObject.SetActive(true);
    }
    private void Update()
    {
        conversation.gameObject.SetActive(false);
    }
}
