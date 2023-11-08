using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    private bool canInteract = false; // ngontrol interaksi biar false

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true; // bikin objek bisa di-interact
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false; // balikin canInteract-nya jadi false lagi saat keluar collider
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    private void Interact()
    {

        InventoryManager.Instance.AddItem(_itemType);     // masukin item ke inventory dan hapus objek yang diambil dari game
        Destroy(gameObject);
    }
}