using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private ScoreManager scoreManager;
    private DoubleJump doubleJump;

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
        doubleJump = gameObject.GetComponent<DoubleJump>();
    }

    public int GetScore()
    {
        return scoreManager.GetScore();
    }

    public bool GetDoubleJump()
    {
        return doubleJump.GetDoubleJump();
    }

    public void IncreseScore()
    {
        scoreManager.IncreaseScore();
    }

    public void DoubleJumpChangeStatus()
    {
        doubleJump.DoubleJumpChangeStatus();
    }
}
