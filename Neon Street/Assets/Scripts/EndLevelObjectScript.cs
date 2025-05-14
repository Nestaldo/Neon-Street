using UnityEngine;

public class EndLevelObjectScript : MonoBehaviour
{
    [SerializeField] ManagerScene managerScene;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            managerScene.LoadVictoryScene();
        }
    }
}
