using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnDirectHit : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with: " + collision.transform.parent.gameObject.tag);
        if (collision.transform.parent.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
