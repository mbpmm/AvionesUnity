using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public float enemyHP;

    void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            enemyHP -= 10;
            Debug.Log(enemyHP);
        }

        if (collision.gameObject.name == "EnemyBulletEmitter" || collision.gameObject.name == "BulletEnemy(Clone)"|| collision.gameObject.name == "enemy")
        {
        }
        else
        {
            enemyHP = 0;
            if (enemyHP <=0)
            {
                Rigidbody rig = GetComponent<Rigidbody>();
                rig.useGravity = true;
                rig.isKinematic = false;
                Explode();
            }
            
        }

    }
}
