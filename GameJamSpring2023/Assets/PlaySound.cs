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
    }

}
