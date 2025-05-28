using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Transform player;
    public TextMeshProUGUI scoreText;
    public float distanceMultiplier = 1f;
    public float timeMultiplier = 5f;

    private float startX;
    private float currentScore = 0f;
    private float timeAlive = 0f;
    private bool isScoring = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (player != null)
            startX = player.position.x;
    }
    void Update()
    {
        if (!isScoring || player == null) return;

        timeAlive += Time.deltaTime;

        float distance = player.position.x - startX;
        currentScore = (distance * distanceMultiplier) + (timeAlive * timeMultiplier);

        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(currentScore).ToString();
    }
    public void StopScoring()
    {
        isScoring = false;
    }
    public int GetScore()
    {
        return Mathf.FloorToInt(currentScore);
    }
    public void ResetScore()
    {
        currentScore = 0f;
        timeAlive = 0f;
        isScoring = true;

        if (player != null)
            startX = player.position.x;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "1_Lobby_Scene")
        {
            ResetScore();
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
