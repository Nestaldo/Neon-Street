using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public int lastScene;
    public void ReloadScene()
    {
        int currentScenee = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenee);
    }
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(0);
        ScoreManager.Instance.ResetScore();
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadDeathScene()
    {
        SceneManager.LoadScene(2);
        lastScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadVictoryScene()
    {
        SceneManager.LoadScene(3);
    }
}
