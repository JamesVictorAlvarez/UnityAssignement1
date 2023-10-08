using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private ScoreManager scoreManager;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself. 
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    public int GetScore()
    {
        return scoreManager.GetScore();
    }

    public void IncreseScore()
    {
        scoreManager.IncreaseScore();
    }
}
