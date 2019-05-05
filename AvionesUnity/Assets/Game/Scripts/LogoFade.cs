using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoFade : MonoBehaviour
{
    public GameObject image;

    public float appear = 0;
    public float timer;
    public float disapear = 1;

    private RawImage logo;

    void Start()
    {
        logo = image.GetComponent<RawImage>();
        logo.color = new Vector4(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>2f&&timer<4f)
        {
            appear += Time.deltaTime * 0.5f;
            logo.color = new Vector4(1, 1, 1, appear);
        }

        if (timer>6f)
        {
            disapear -= Time.deltaTime * 0.3f;
            logo.color = new Vector4(1, 1, 1, disapear);
        }

        if (disapear<=0)
        {
            SceneManager.LoadScene("IntroScene");
        }
    }
}
