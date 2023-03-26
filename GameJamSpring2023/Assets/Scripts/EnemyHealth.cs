using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int health;

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
