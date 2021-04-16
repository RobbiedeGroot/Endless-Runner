using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int highScore;
    public static int highScoreStatic;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
        highScoreText.GetComponent<Text>();
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (highScore < Pickup.ScoreAmmount)
        {
            highScore = Pickup.ScoreAmmount;
            Debug.Log(highScore.ToString());
            highScoreText.text = "Highscore: " + highScore.ToString();
            highScoreStatic += Pickup.ScoreAmmount;
            Debug.Log("fnesihndfsnfis");
            SaveScore();
        }
    }
    
    public void SaveScore()
    {
        SaveSystem.SaveHighscore(this);
    }
    
    public void LoadScore()
    {
        ScoreData data = SaveSystem.LoadHighscore();
        
        highScore = data.highScoreData;
    }
}
