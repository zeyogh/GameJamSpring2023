using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject projectile;

    [SerializeField] GameObject player;

    private float x;

    private float y;

    private float pX;

    private float pY;

    private Vector2 target;

    private float speed;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        speed = 12f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        x = this.transform.position.x;
        y = this.transform.position.y;

        pX = player.getX();
        pY = player.getY();

        Vector2 difference = new Vector2(pX - x, pY - y);
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(x - pX) <= 100 || Mathf.Abs(y - pY) <= 100)
        {
            move(pX, pY);
            if (timer > 3.0f)
            {
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                shoot(direction, rotation);
                timer = 0;
            }

        }
    }

    void shoot(Vector2 direction, float rotation)
    {
        var bullet = Instantiate(projectile, this.transform.position, this.transform.rotation);
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet.bulletSpeed();
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
    }

    void move(float pX, float pY)
    {
        Vector2 vThis = new Vector2((float)x, (float)y);
        Vector2 vPlayer = new Vector2(pX, pY);

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(vThis, vPlayer, step);
    }
}
