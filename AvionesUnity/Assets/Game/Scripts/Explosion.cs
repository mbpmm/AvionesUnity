using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float planeHP;
    void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject,exp.main.duration);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="BulletEmitter"|| collision.gameObject.name == "Bullet(Clone)")
        {   
        }
        else if (collision.gameObject.name == "BulletEnemy(Clone)")
        {
            planeHP -= 10;
            Debug.Log(planeHP);
            if (planeHP <= 0)
            {
                Rigidbody rig = GetComponent<Rigidbody>();
                rig.useGravity = true;
                rig.isKinematic = false;
                Explode();
            }
        }
        else
        {
            planeHP = 0;
            if (planeHP <= 0)
            {
                Rigidbody rig = GetComponent<Rigidbody>();
                rig.useGravity = true;
                rig.isKinematic = false;
                Explode();
            }
        }
    }
}
