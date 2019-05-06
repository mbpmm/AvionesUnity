using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public float enemyHP;
    private bool discountOnce;
    private GameObject man;
    private GameManager gameManager;
    private void Start()
    {
        man = GameObject.Find("GameManager");
        gameManager = man.GetComponent<GameManager>();
        discountOnce = false;
    }
    void Update()
    {
        enemyHP = GetComponent<EnemyFSM>().hp;
        if (enemyHP <= 0)
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.useGravity = true;
            rig.isKinematic = false;
            Explode();
        }
        
    }
    void Explode()
    {
        if (!discountOnce)
        {
            gameManager.EnemyExplosion();
            discountOnce = true;
        }
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
