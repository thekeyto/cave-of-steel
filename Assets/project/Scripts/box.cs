using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Inventory playerBag;
    bool chipHeld = false;
    public chipPrefab ChipPrefab;
    public Item chip;
    public SpriteRenderer nowSprite;
    public GameObject player;
    bool ifChip;
    private void Start()
    {
        ifChip = false;
        if (chip != null) chipHeld = true;
        nowSprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&Input.GetKeyDown(KeyCode.Q))
        {
            Chip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("machineArm"))
            collision.GetComponent<MachineArm>().chip.Add(chip);
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
            temp.y += 1.5f;
            Instantiate(ChipPrefab.itemlist[chip.property],transform.position,transform.rotation);
            chipHeld = false;
            chip = null;
        }
    }

    public void whenOnChick()
    {
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
