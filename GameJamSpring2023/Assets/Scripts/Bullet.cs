using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed;

    public int bulletSpeed()
    {
        return speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) {
            Debug.Log("kablooie");
            Destroy(gameObject);
        }

    }
}
