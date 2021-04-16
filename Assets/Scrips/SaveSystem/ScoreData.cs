using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int highScoreData;
    public ScoreData (HighScore highScore)
    {
        highScoreData = HighScore.highScoreStatic;
    }
}

