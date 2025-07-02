using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public static ManagerScene Instance;
    public int lastScene;
    public int currentScene;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ReloadScene()
    {
        int currentScenee = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenee);
    }
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("1_Lobby_Scene");
        ScoreManager.Instance.ResetScore();
    }
    public void LoadFirtsLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadDeathScene()
    {
        SceneManager.LoadScene("3_Death_Scene");
        lastScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadVictoryScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene = " + currentScene);
        currentScene += 1;
        lastScene = currentScene;
        SceneManager.LoadScene("4_Win_Scene");
        MusicManager.Instance.currentSceneSaved = lastScene;
    }
    public void NextLvl()
    {
        currentScene = MusicManager.Instance.currentSceneSaved;
        if(currentScene == 1)
        {
            SceneManager.LoadScene("2_Level_1_Scene");
        }
        if(currentScene == 2)
        {
            SceneManager.LoadScene("2_Level_2_Scene"); 
        }
        if(currentScene == 3)
        {
            SceneManager.LoadScene("2_Level_3_Scene");  
        }
        if(currentScene == 4)
        {
            SceneManager.LoadScene("2_Level_4_Scene");  
        }
        if(currentScene == 5)
        {
            SceneManager.LoadScene("2_Level_5_Scene");   
        }
        else if(currentScene > 5)
        {
            SceneManager.LoadScene("1_Lobby_Scene");
        }
    }

    [SerializeField] GameObject pauseMenu;
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartLvl()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
