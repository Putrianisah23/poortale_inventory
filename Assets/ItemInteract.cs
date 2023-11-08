// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ItemInteract : MonoBehaviour
// {
// //    [SerializeField] private GameObject cherry;
// //    [[SerializeField] private ] player;
// //    [SerializeField] private Text itemText;
// //    private bool pickUpAllowed;
//     public PlayerController playerController;
//      public float interactionDistance = 2f;

// //    private void Start()
// //    {
// //     itemText.gameObject.SetActive(false);
// //    }
//     private void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Z));
//         {
//             RaycastHit hit;
//             if (Physics.Raycast(playerController.transform.position, playerController.transform.forward, out hit, interactionDistance))
//         }
//         if (hit.collider.CompareTag("Item"))
//          {
//                     CollectItem(hit.collider.gameObject);
//                 }
//         }
//     void CollectItem(GameObject item)
//     {
//          Destroy(item);
//     }
// }
