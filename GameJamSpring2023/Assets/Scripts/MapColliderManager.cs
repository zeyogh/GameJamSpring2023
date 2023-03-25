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
            collision.transform.position = new Vector3(1, y, 0);
        }else if(x > 200){
            collision.transform.position = new Vector3(199, y, 0);
        }

        if(y < 0){
            collision.transform.position = new Vector3(x, 1, 0);
        }else if(y > 200){
            collision.transform.position = new Vector3(x, 199, 0);
        }

    }

}
