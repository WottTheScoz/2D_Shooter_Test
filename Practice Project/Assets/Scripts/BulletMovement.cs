using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 1f;

    Rigidbody bulletRB;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.AddForce(Vector3.right * bulletSpeed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) 
        {
            Destroy(gameObject);
        }
    }
}
