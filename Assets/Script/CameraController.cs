using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private Transform player;

    private void Update()
    {
    //   player = GameObject.FindGameObjectWithTag("thePlayer").transform;
      transform.position = new Vector3(player.position.x, player.position.y+3, transform.position.z);
    }
}