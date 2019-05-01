using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        GoingToTarget,
        Last,
    }

    [SerializeField] private EnemyState state;

    public float speed;
    public float rotateSpeed;
    public float distanceToStop;
    public LayerMask rayCastLayer;
    public float rayDistance;
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletForce;
    public float bulletDelay;

    public Transform target;

    private float t;

    private void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                t += Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.identity, rotateSpeed * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
                if (t > 3)
                {
                    SetState(EnemyState.GoingToTarget);
                    t = 0;
                }
                break;
            case EnemyState.GoingToTarget:
                Quaternion q = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
                RaycastHit hit;
                Debug.DrawRay(transform.position, transform.forward * 80, Color.red);

                if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
                {
                    Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

                    string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

                    bulletDelay += Time.deltaTime;

                    if (layerHitted=="Plane")
                    {
                        if (bulletDelay>0.7f)
                        {
                            GameObject auxBullet;
                            auxBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
                            Rigidbody rig;
                            rig = auxBullet.GetComponent<Rigidbody>();
                            rig.AddForce(transform.forward * bulletForce);
                            bulletDelay = 0;
                        }
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
                }
                if (Vector3.Distance(transform.position, target.position) < distanceToStop)
                    SetState(EnemyState.Idle);
                break;
        }

        Debug.Log(Vector3.Distance(transform.position, target.position));
    }

    private void NextState()
    {
        t = 0;
        int intState = (int)state;
        intState++;
        intState = intState % ((int)EnemyState.Last);
        SetState((EnemyState)intState);
    }

    private void SetState(EnemyState es)
    {
        state = es;
    }
}
