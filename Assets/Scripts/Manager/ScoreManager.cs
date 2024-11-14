using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameManager gameManager;

    int score = 0;
    public void Start(){
        score = 0;
        scoreText.text = score.ToString();
    }
    public void IncreaseScore(int scoreAmount){
        if(gameManager.GameOver) return;
        score += scoreAmount;
        scoreText.text = score.ToString();
    }
    public void SaveScore(){
        int highestScore = PlayerPrefs.GetInt("HighestScore",0); //default to 0 if no previous score is saved;

        if(score > highestScore){
            PlayerPrefs.SetInt("HighestScore", score);
            PlayerPrefs.Save();
        }
    }
    public int GetCurrentScore()
    {
        return score;
    }
}
