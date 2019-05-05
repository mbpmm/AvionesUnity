using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float planeHP;

    private GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void Update()
    {
        planeHP = GetComponent<Plane>().playerHP;
        if (planeHP <= 0)
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
        gameManager.GetComponent<GameManager>().playerDead = true;
    }
}
