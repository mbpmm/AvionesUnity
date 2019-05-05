using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float enemiesDestroyed;
    public float points;
    public Text winText;
    public Text loseText;
    //arreglar referencias con find
    public GameObject panel;
    public GameObject cam;
    public float levelTimer;
    public float enemiesLvl;
    public bool playerDead;
    public int level;
    private static GameManager instance;
    
    public static GameManager Get()
    {
        return instance;
    }

    private void Awake()
    {
        panel.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        enemiesDestroyed = 0;
        enemiesLvl = 4;
        points = 0;
        level = 1;


        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (enemiesLvl==0)
        {
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            if (levelTimer > 4f)
            {
                enemiesLvl = 6;
                level++;
                SceneManager.LoadScene("GameScene 1");
            }
        }
        if (enemiesLvl == 0&&level==2)
        {
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            if (levelTimer > 4f)
            {
                enemiesLvl = 4;
                level++;
                SceneManager.LoadScene("GameScene 2");
            }
        }
        if (enemiesLvl == 0 && level == 3)
        {
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            if (levelTimer > 4f)
            {
                SceneManager.LoadScene("FinalScene");
            }
        }
        if (playerDead)
        {
            cam.gameObject.SetActive(true);
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
            if (levelTimer>4f)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Destroy(gameObject);
                SceneManager.LoadScene("IntroScene");
            }
            
        }
    }
}
