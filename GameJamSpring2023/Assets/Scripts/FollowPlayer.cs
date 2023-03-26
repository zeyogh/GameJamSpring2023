using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float pX = player.position.x;
        float pY = player.position.y;
        float difX = Mathf.Abs(pX - gameObject.transform.position.x);
        float difY = Mathf.Abs(pX - gameObject.transform.position.y);
        float distance = Mathf.Sqrt((difX * difX) + (difY * difY));

        if (distance < 10)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
