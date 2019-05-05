using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMenu()
    {
        Destroy(gameManager.gameObject);
        SceneManager.LoadScene("IntroScene");
    }

    public void Close()
    {
        Application.Quit();
    }
}