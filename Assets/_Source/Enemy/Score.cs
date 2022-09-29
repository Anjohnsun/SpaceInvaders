using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Score 
{
    private static int scoreValue = 0;
    public static int ScoreValue { get; }
    public static ScoreView scoreView = GameObject.FindObjectOfType<ScoreView>();
    
    public static void IncreaseScore(int pointsToAdd)
    {
        scoreValue += pointsToAdd;
        scoreView.RefreshView(scoreValue);
    }

    
}
