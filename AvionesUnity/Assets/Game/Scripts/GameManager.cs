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
    public GameObject canvas;
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
        if (enemiesLvl==0&&level==1)
        {
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            if (levelTimer > 4f)
            {
                enemiesLvl = 6;
                level++;
                levelTimer = 0;
                SceneManager.LoadScene("GameScene 1");
                
            }
        }
        if (level==2)
        {
            cam.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            winText.gameObject.SetActive(false);
            loseText.gameObject.SetActive(false);
        }
        if (enemiesLvl == 0&&level==2)
        {
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            if (levelTimer > 4f)
            {
                enemiesLvl = 6;
                level++;
                levelTimer = 0;
                SceneManager.LoadScene("GameScene 2");
            }
        }
        if (level == 3)
        {
            cam.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            winText.gameObject.SetActive(false);
            loseText.gameObject.SetActive(false);
        }
        if (enemiesLvl == 0 && level == 3)
        {
            levelTimer += Time.deltaTime;
            panel.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            if (levelTimer > 4f)
            {
                level++;
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
                canvas.gameObject.SetActive(false);
                cam.gameObject.SetActive(false);
                panel.gameObject.SetActive(false);
                winText.gameObject.SetActive(false);
                loseText.gameObject.SetActive(false);
                SceneManager.LoadScene("FinalScene");
            }
            
        }
    }
}
