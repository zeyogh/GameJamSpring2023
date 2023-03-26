using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyPlayer;
    public GameObject player; //the enemy the script is assigned to
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    public float speed = 2.0f;

    public float bulletSpeed = 60.0f;

    public int health = 5;

    private Vector3 target;

    private float time;

    // Use this for initialization
    void Start()
    {
        time = 0;
        player = gameObject;
        enemyPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        target = enemyPlayer.transform.position;

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        time += Time.deltaTime;


        if (time > 2.0f)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            time = 0;
        }
    }



    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public void hit()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
