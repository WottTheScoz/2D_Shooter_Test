using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletObj;

    PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.OnPlayerShoot += ShootBullet;
    }

    void ShootBullet(float IGNORE) 
    {
        Instantiate(bulletObj, gameObject.transform.position, Quaternion.identity);
    }
}
