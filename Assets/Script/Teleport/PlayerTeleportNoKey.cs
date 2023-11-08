using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportNoKey : MonoBehaviour
{
    private GameObject currentTeleporterX;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentTeleporterX != null)
            {
                transform.position = currentTeleporterX.GetComponent<Teleporter>().GetDestination().position;
               
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleporterX"))
        {
            currentTeleporterX = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleporterX"))
        {
            if (collision.gameObject == currentTeleporterX)
            {
                currentTeleporterX = null;
            }
        }
    }

  
}
