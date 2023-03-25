using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int speed;

    private void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    public int bulletSpeed()
    {
        return speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
