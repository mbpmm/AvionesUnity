using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public float enemyHP;
    void Update()
    {
        enemyHP = GetComponent<EnemyFSM>().hp;
        if (enemyHP<=0)
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.useGravity = true;
            rig.isKinematic = false;
            Explode();
        }
    }
    void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
