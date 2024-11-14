using UnityEngine;
using TMPro;

public class HighestScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText; // Reference to TMP_Text component

    private void Start()
    {
        // Get the highest score from PlayerPrefs and display it
        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        scoreText.text = "Highest Score: " + highestScore.ToString("N0"); // Formatting with thousands separators
    }
}
