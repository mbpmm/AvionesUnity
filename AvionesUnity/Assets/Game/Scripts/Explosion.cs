using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
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
        else
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.useGravity = true;
            Explode();
        }
            
    }
}
