using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed;
    Collider2D playerCollider;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), playerCollider, true);
    }

    public int bulletSpeed()
    {
        return speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("tag: " + collision.gameObject.tag);
        if ((collision.gameObject.tag == "Enemy"))
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyHealth>().hit();
            Debug.Log("kablooie");
        //    Destroy(collision.gameObject);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
