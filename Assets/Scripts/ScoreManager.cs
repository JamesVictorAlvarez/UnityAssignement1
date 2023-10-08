using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    public void IncreaseScore()
    {
        score += 50;
    }
    public int GetScore()
    {
        return score;
    }
}
