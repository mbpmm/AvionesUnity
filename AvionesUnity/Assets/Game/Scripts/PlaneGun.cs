﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGun : MonoBehaviour
{
    

    void OnTriggerEnter(Collider col)
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Debug.Log("fgfgd");
            Destroy(gameObject);
        }
        
    }
}
