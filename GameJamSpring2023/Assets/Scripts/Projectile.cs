using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int speed;

    private Vector2 moveDirection;
    private bool activateMove = false;

    private GameObject player; //the enemy the projectile is coming from
    private Collider2D playerCollider;

    private void Start()
    {
        player = gameObject.transform.parent.gameObject;
        playerCollider = player.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), playerCollider, true);
    }

    private void Update()
    {
        if (activateMove)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    public void setMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
        activateMove = true;
    }

    public int bulletSpeed()
    {
        return speed;
    }

    public void setBulletSpeed(int speed)
    {
        this.speed = speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit detected");
        Destroy(gameObject);
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerController>().hit();
        }
    }
}
