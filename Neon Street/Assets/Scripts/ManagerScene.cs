using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void ReloadScene()
    {
        int currentScenee = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenee);
    }
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadDeathScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadVictoryScene()
    {
        SceneManager.LoadScene(3);
    }
}
