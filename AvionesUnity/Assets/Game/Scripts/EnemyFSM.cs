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

    public float speed = 10;
    public float distanceToStop = 2;
    public float distanceToRestart = 10;

    public Transform target;

    private float t;

    private void Update()
    {
        t += Time.deltaTime;
        switch (state)
        {
            case EnemyState.Idle:
                if (t > 2)
                {
                    NextState();
                }
                break;
            case EnemyState.GoingToTarget:
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 50 * Time.deltaTime);
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
