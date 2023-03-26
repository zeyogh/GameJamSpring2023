using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTip : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        other.GetComponent<EnemyHealth>().hit();
        Debug.Log(other.GetComponent<EnemyHealth>().getHealth());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        other.GetComponent<EnemyHealth>().hit();
        Debug.Log(other.GetComponent<EnemyHealth>().getHealth());
    }
}
