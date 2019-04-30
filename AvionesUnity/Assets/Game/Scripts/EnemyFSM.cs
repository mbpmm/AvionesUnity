using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        GoingToTarget,
        GoAway,
        Last,
    }

    [SerializeField] private EnemyState state;

    public float speed = 20;
    public float distanceToStop = 7;
    public float distanceToRestart = 40;
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
        t += Time.deltaTime;
        switch (state)
        {
            case EnemyState.Idle:
                transform.Translate(transform.forward*speed/2*Time.deltaTime);
                if (t > 2)
                {
                    NextState();
                }
                break;
            case EnemyState.GoingToTarget:
                Vector3 dir = target.position - transform.position;
                transform.LookAt(target);
                transform.Translate(transform.forward.normalized* speed * Time.deltaTime);
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
                    NextState();
                break;
            case EnemyState.GoAway:
                Vector3 dir02 = transform.position - target.position;
                transform.Translate(dir02.normalized * speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, target.position) > distanceToRestart)
                    NextState();
                break;
        }
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
