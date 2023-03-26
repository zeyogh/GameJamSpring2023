using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource a;
    [SerializeField] AudioSource b;
    [SerializeField] int timer;

    private System.Random rand;

    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > timer)
        {
            int r = rand.Next(1, 3);
            if (r == 1 || b == null)
            {
                a.Play();
            }
            else
            {
                b.Play();
            }
        }

    }
}
