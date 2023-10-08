using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private DoubleJump doubleJump;
    public int score;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Duplicate GameManager created every time the scene is loaded
            Destroy(gameObject);
        }
        doubleJump = gameObject.GetComponent<DoubleJump>();
    }

    public bool GetDoubleJump()
    {
        return doubleJump.GetDoubleJump();
    }

    public void DoubleJumpChangeStatus()
    {
        doubleJump.DoubleJumpChangeStatus();
    }
}
