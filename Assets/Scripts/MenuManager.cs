using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnGameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnGameStop()
    {
        Application.Quit();
    }

    public void OnGameRestart()
    {
        GameManager.instance.score = 0;
        SceneManager.LoadScene(1);
    }
}
