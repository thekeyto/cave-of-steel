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
    private void Start()
    {
        if (chip != null) chipHeld = true;
        nowSprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&Input.GetKeyDown(KeyCode.E))
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
            player.GetComponent<PlayerMove>().act(chip.property);
            nowSprite.sprite = chip.itemImage;
        }
    }

    private void Update()
    {
        nowSprite.sprite = chip.NotUseImage;
    }
}
