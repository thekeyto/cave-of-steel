using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Inventory playerBag;
    public bool chipHeld = false;
    public chipPrefab ChipPrefab;
    public Item chip;
    public SpriteRenderer nowSprite;
    public Sprite noneChip;
    public GameObject player;
    bool ifChip;
    private void Start()
    {
        ifChip = false;
        if (chip != null) chipHeld = true;
        nowSprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("machineArm"))
            collision.GetComponent<MachineArm>().chip.Add(chip);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&Input.GetKeyDown(KeyCode.Q))
        {
            Chip();
        }
    }
    void Chip()
    {
        if (chipHeld==false&&playerBag.itemlist[3]!=null)
        {
            chipHeld = true;
            chip = playerBag.itemlist[3];
            playerBag.itemlist[3] = null;
            InventoryManager.RefreshItem();
        }
        else
        if (chipHeld==true)
        {
            Vector2 temp = transform.position;
            temp.y += 9.0f;
            Instantiate(ChipPrefab.itemlist[chip.property],temp,transform.rotation);
            chipHeld = false;
            nowSprite.sprite = noneChip;
            chip = null;
        }
    }

    public void whenOnChick()
    {
        Debug.Log(1);
        if (chipHeld)
        {
            ifChip = !ifChip;
            player.GetComponent<PlayerMove>().act(chip.property,ifChip);
            if (ifChip==true)
            nowSprite.sprite = chip.itemImage;
            else nowSprite.sprite = chip.NotUseImage;
        }
    }
    private void Update()
    {
        if (chipHeld==true)
        if (ifChip == true) nowSprite.sprite = chip.itemImage;
        else nowSprite.sprite = chip.NotUseImage;
    }
}
