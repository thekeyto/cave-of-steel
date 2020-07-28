using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    public bool activeSelf;
    public GameObject bagCanvas;
    // Start is called before the first frame update
    void Start()
    {
        activeSelf = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SetActive();
    }
    // Update is called once per frame
    public void SetActive()
    { 
        if (activeSelf == false)
        {
            bagCanvas.SetActive(true);
            activeSelf = true;
        } 
        else
        {
            bagCanvas.SetActive(false);
            activeSelf = false;
        }
    }
}
