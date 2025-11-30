using UnityEngine;
using UnityEngine.UI;

public class HighestScore: MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        highScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}
