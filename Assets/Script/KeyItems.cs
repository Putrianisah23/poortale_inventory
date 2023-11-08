using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItems : MonoBehaviour 
{

    [SerializeField] private bool pickUpAllowed;
	
	public GameObject itembuah;
   

    // bikin objek bisa di-interact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = true;
        }        
    }
    
    // balikin pickupallowed-nya jadi false lagi saat keluar collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = false;
        }
    }

	// Update is called once per frame
	private void Update () 
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.Z))
            PickUp();

       
    }

    private void PickUp()
    {
        Destroy(gameObject);
        itembuah.SetActive(true);
    }

}
