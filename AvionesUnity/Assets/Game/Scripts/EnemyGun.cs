﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.name == "spitfire")
        {
            Debug.Log("colisiona");
            Destroy(gameObject);

        }

    }
}
