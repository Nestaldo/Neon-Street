using UnityEngine;

public class DeathLimitScript : MonoBehaviour
{
    [SerializeField] ManagerScene managerScene;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            managerScene.LoadDeathScene();
            MusicManager.Instance.PlayDeathSFX();
        }
    }
}
