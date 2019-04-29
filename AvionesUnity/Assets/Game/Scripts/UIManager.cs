using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text altura;
    public Text rrs;
    public Text ammo;
    private GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("spitfire");
    }

    // Update is called once per frame
    void Update()
    {
        altura.text = "Altura: " +Mathf.Round(plane.transform.position.y) + "m.";
        rrs.text = "RRS: " + Mathf.Round(plane.transform.eulerAngles.z) + "°";
        ammo.text = "Municion: ∞";
    }
}
