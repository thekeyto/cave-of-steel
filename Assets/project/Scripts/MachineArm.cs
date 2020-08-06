using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineArm : MonoBehaviour
{
    public List<Item> chip = new List<Item>();
    public float speed = 30;
    public GameObject Box;
    public Sprite normalBox;
    public Sprite useBox;
    public GameObject Arm;
    float rotateTime = 3;
    bool isU=false;
    public int nowChip = 0;
    AudioSource audio;

    private void Start()
    {
        isU = false;
        audio = GetComponent<AudioSource>();
        Box.GetComponent<CapsuleCollider2D>().enabled = isU;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    IEnumerator waitForRotate()
    {
        yield return new WaitForSeconds(rotateTime);
    }
    Sprite NowBox(bool flag)
    {
        if (flag == true) return useBox;
        return normalBox;
    }
    private void Update()
    {
        if (chip.Count>1)
        {
            if (!audio.isPlaying) audio.Play();
            Arm.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            //if (Arm.transform.rotation.z > 360) Arm.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Arm.transform.rotation.z - 360);
            //else if (Arm.transform.rotation.z < 0) Arm.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Arm.transform.rotation.z + 360);
            if (chip[nowChip].property != 4)
            {
                float temp = Arm.transform.eulerAngles.z;
                if (Mathf.Abs(temp-chip[nowChip].rotation)<=10)
                {
                   // Debug.Log(temp);
                   // Debug.Log(chip[nowChip].rotation);
                    nowChip = nowChip + 1 == chip.Count ? 0 : nowChip + 1;
                    isU = !isU;
                    Box.GetComponent<SpriteRenderer>().sprite = NowBox(isU);
                    Box.GetComponent<CapsuleCollider2D>().enabled = isU;
                }
            }
            else
            {
                nowChip = nowChip + 1 == chip.Count ? 0 : nowChip + 1;
                isU = !isU;
                Box.GetComponent<SpriteRenderer>().sprite = NowBox(isU);
                Box.GetComponent<CapsuleCollider2D>().enabled = isU;
            }
        }
    }
}
