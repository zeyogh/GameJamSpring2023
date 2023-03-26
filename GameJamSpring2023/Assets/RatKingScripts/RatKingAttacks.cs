using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RatKingAttacks : MonoBehaviour
{
    [SerializeField] BulletPatterns bp;
    [SerializeField] GameObject laser;



    private int attackSignal;

    // Start is called before the first frame update
    void Start()
    {
        lasers();
    }




    public void lasers()
    {
        GameObject container = gameObject.transform.GetChild(0).gameObject;
        Transform[] firePoints = container.GetComponentsInChildren<Transform>();
        for (int i = 0; i < firePoints.Length; i++)
        {
            var laser = Instantiate(this.laser);
            laser.GetComponent<LaserBehavior>().setFirePoint(firePoints[i]);
        }
    }
}
