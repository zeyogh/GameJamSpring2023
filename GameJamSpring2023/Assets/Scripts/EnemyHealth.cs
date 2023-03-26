using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int health;
    private GameObject newParentObject;

    private void Start()
    {
        newParentObject = GameObject.FindWithTag("BulletHolder");
    }

    public void hit()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.transform.tag == "Projectile")
                {
                    child.gameObject.transform.parent = newParentObject.transform;
                }
            }
            Destroy(gameObject);
        }
    }
}
