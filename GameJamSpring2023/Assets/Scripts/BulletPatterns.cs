using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatterns : MonoBehaviour
{
    [SerializeField] Projectile bullet;

    private float angle = 0f;

    public bool useSpiral;

    public bool useMultiBulletCircle;

    public bool useBoth;

    private float time;

    private bool spiralUsed;

    private bool spreadUsed;

    public bool UseSpiral { get => useSpiral; set => useSpiral = value; }
    public bool UseMultiBulletCircle { get => useMultiBulletCircle; set => useMultiBulletCircle = value; }

    private void Awake()
    {
        time = 0;

        if (useSpiral)
        {
            InvokeRepeating("spiral", 0f, 0.75f);
        }
        if (useMultiBulletCircle)
        {
            InvokeRepeating("multiBulletCircle", 0f, 3f);
        }
    }

    private void Update()
    {
        if (useBoth)
        {
            time += Time.deltaTime;
            if (time > 0f && time <= 10f)
            {
                if (!spreadUsed)
                {
                    InvokeRepeating("multiBulletCircle", 0f, .75f);
                    spreadUsed = true;
                }
            }
            else if (time > 10f && time <= 20f)
            {
                if (!spiralUsed)
                {
                    spreadUsed = false;
                    angle = 0;
                    CancelInvoke("multiBulletCircle");
                    InvokeRepeating("spiral", 0f, .75f);
                    spiralUsed = true;
                }
            }
            else
            {
                spiralUsed = false;
                CancelInvoke("spiral");
                time = 0;
            }
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
        b.transform.parent = gameObject.transform;

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
            b.transform.parent = gameObject.transform;

            angle += 60f;
        }
    }

}
