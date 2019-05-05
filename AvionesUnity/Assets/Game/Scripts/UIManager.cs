using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text altura;
    public Text rrs;
    public Text ammo;
    public Text enemiesLeft;
    public Slider fuel;
    public Slider planeHP;
    private GameObject plane;
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("spitfire");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        fuel.value = plane.GetComponent<Plane>().fuel;
        planeHP.value = plane.GetComponent<Plane>().playerHP;
        altura.text = "Altura: " +Mathf.Round(plane.transform.position.y) + "m.";
        rrs.text = "RRS: " + Mathf.Round(plane.transform.eulerAngles.z) + "°";
        ammo.text = "Municion: ∞";
        enemiesLeft.text = "Enemies left: " + gameManager.GetComponent<GameManager>().enemiesLvl;
    }
}
