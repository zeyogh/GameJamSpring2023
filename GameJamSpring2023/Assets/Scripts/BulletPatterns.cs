using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatterns : MonoBehaviour
{
    [SerializeField] Projectile bullet;

    private float angle = 0f;

    public bool useSpiral;

    public bool useMultiBulletCircle;

    private void Start()
    {
        if (useSpiral)
        {
            InvokeRepeating("spiral", 0f, 0.2f);
        }
        if (useMultiBulletCircle)
        {
            InvokeRepeating("multiBulletCircle", 0f, 1f);
        }
    }

    public void spiral()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        Projectile b = Instantiate(bullet) as Projectile;
        b.transform.position = gameObject.transform.position;
        b.transform.rotation = gameObject.transform.rotation;
        b.setMoveDirection(bulDir);

        angle += 20f;

    }

    public void multiBulletCircle()
    {

        for (int i = 0; i < 6; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            Projectile b = Instantiate(bullet) as Projectile;
            b.transform.position = gameObject.transform.position;
            b.transform.rotation = gameObject.transform.rotation;
            b.setMoveDirection(bulDir);

            angle += 60f;
        }
    }




}
