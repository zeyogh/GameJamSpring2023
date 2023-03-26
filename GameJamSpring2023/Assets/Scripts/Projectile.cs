using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int speed;

    private Vector2 moveDirection;
    private bool activateMove = false;

    private void Start()
    {
        
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        Destroy(gameObject);
    }
}
