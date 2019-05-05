using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public float enemyHP;
    private bool discountOnce;
    private GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
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
            gameManager.GetComponent<GameManager>().enemiesDestroyed++;
            gameManager.GetComponent<GameManager>().enemiesLvl--;
            gameManager.GetComponent<GameManager>().points += 200 ;
            Debug.Log(gameManager.GetComponent<GameManager>().enemiesLvl);
            discountOnce = true;
        }
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
