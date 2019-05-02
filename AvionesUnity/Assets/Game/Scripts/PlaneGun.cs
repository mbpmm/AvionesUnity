using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGun : MonoBehaviour
{
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.name == "EnemyContainer" || col.gameObject.name == "EnemyContainer (1)" || col.gameObject.name == "EnemyContainer (2)" || col.gameObject.name == "EnemyContainer (3)")
        {
            Debug.Log("colisiona");
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Debug.Log("fgfgd");
            Destroy(gameObject);
        }
        if (col.gameObject.name == "EnemyContainer"|| col.gameObject.name == "EnemyContainer (1)"|| col.gameObject.name == "EnemyContainer (2)"|| col.gameObject.name == "EnemyContainer (3)")
        {
            Debug.Log("colisiona");
            Destroy(gameObject);
        }
    }
}
