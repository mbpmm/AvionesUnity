using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGun : MonoBehaviour
{
    private float t;
    private void Update()
    {
        t += Time.deltaTime;

        if (t > 3f)
        {
            Destroy(gameObject);
        }
    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "Terrain")
    //    {
    //        Debug.Log("fgfgd");
    //        Destroy(gameObject);
    //    }
    //    if (col.gameObject.name == "EnemyContainer"|| col.gameObject.name == "EnemyContainer (1)"|| col.gameObject.name == "EnemyContainer (2)"|| col.gameObject.name == "EnemyContainer (3)")
    //    {
    //        Debug.Log("colisiona");
    //        Destroy(gameObject);
    //    }
    //}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Terrain")
        {
            Debug.Log("colisiona con terreno");
            Destroy(gameObject);
        }
        if (col.gameObject.name == "EnemyContainer" || col.gameObject.name == "EnemyContainer (1)" || col.gameObject.name == "EnemyContainer (2)" || col.gameObject.name == "EnemyContainer (3)")
        {
            Debug.Log("colisiona");
            Destroy(gameObject);
        }
        if (col.gameObject.name=="spitfire")
        {
            Debug.Log("colisiona con el jugador");
            Destroy(gameObject);
        }
    }
}
