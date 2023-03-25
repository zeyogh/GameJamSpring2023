using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Player player;

    private float x;

    private float y;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        speed = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;

        float pX = player.GetX();
        float pY = player.GetY();

        if (Mathf.Abs(x - pX) <= 100 || Mathf.Abs(y - pY) <= 100)
        {
            move(pX, pY);
        }
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
