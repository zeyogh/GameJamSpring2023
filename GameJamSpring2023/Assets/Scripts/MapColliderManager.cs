using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColliderManager : MonoBehaviour
{
    

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Something Happened @" + collision.transform.position);
        float x = collision.transform.position.x;
        float y = collision.transform.position.y;
        if(x < 0){
            collision.transform.position = new Vector3((float).5, y, 0);
        }else if(x > 200){
            collision.transform.position = new Vector3((float)199.5, y, 0);
        }

        if(y < 0){
            collision.transform.position = new Vector3(x, (float).5, 0);
        }else if(y > 200){
            collision.transform.position = new Vector3(x, (float)199.5, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something Happened @" + collision.transform.position);
        float x = collision.transform.position.x;
        float y = collision.transform.position.y;
        if(x < 0){
            collision.transform.position = new Vector3((float).25, y, 0);
        }else if(x > 200){
            collision.transform.position = new Vector3((float)199.75, y, 0);
        }

        if(y < 0){
            collision.transform.position = new Vector3(x, (float).25, 0);
        }else if(y > 200){
            collision.transform.position = new Vector3(x, (float)199.75, 0);
        }

    }

}
