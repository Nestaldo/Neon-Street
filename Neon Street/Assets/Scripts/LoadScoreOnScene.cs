using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScoreOnScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int finalScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Final Score : " + finalScore.ToString();
        ScoreManager.Instance.StopScoring();
    }
}
