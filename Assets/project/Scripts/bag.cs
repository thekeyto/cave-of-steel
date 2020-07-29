using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    public int totalChip;
    public bool activeSelf;
    public GameObject bagCan;
    public Canvas bagcanvas;
    // Start is called before the first frame update
    void Start()
    {
        activeSelf = false;
        totalChip = 0;
        bagcanvas = bagCan.GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SetActive();
    }
    // Update is called once per frame
    public void SetActive()
    { 
        if (activeSelf == false)
        {
            bagCan.SetActive(true);
            activeSelf = true;
        } 
        else
        {
            bagCan.SetActive(false);
            activeSelf = false;
        }
    }
}
