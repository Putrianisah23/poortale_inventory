using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportKey : MonoBehaviour
{
    private GameObject currentTeleporter;

    [SerializeField] InventoryManager.AllItems _RequiredItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (HasRequiredItem(_RequiredItem))
            {
                if (currentTeleporter != null)
                {
                    transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                }
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains
            (itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

