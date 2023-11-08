using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class playerFire : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointAir;
    public float fireRate = 2f;
    private float fireTime;
    public int fireAmmo = 5;
    private bool onGround;
    private playerGround ground;
    public GameObject bulletPrefab;

    private void Awake()
    {
        ground = GetComponent<playerGround>();
        fireTime = fireRate;
    }

    private void Update()
    {
        onGround = ground.GetOnGround();
        
        if(fireTime == 0)
        {
            fireTime = fireRate;
        }
    }

    public void AddAmmo()
    {
        fireAmmo++;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if(context.started && fireTime > 0f)
        {
            if(fireAmmo > 0)
            {
                if(onGround)
                {
                    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    fireTime -= Time.deltaTime;
                    fireAmmo --;
                }
                else
                {
                    Instantiate(bulletPrefab, firePointAir.position, firePointAir.rotation);
                    fireTime -= Time.deltaTime;
                    fireAmmo --;
                }
            }
        }
    }
}
