using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //private GameObject pointsNum;

    void Start()
    {
        //pointsNum = GameObject.Find("GameManager");
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
        SceneManager.LoadScene("IntroScene");
    }

    public void Close()
    {
        Application.Quit();
    }
}