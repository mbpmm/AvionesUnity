using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGun : MonoBehaviour
{
    public float t;
    private void Update()
    {
        t += Time.deltaTime;

        if (t > 3f)
        {
            Destroy(gameObject);
            t = 0;
        }
    }
}
