using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerFS : MonoBehaviour
{
    public Text points;
    public Text enemiesKilled;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + gameManager.GetComponent<GameManager>().points;
        enemiesKilled.text = "Enemies killed: " + gameManager.GetComponent<GameManager>().enemiesDestroyed;
    }
}
