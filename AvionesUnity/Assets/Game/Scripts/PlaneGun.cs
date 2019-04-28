using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGun : MonoBehaviour
{
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name=="Terrain")
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
    }
}
