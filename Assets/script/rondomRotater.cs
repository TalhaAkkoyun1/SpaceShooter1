﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rondomRotater : MonoBehaviour
{
    Rigidbody rb;
    public float tumble;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }


}
