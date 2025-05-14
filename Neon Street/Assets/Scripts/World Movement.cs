using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [Header("World Movement Values")]
    [SerializeField] float currentSpeed = 0f;
    [SerializeField] float accelSpeed = 1f;
    [SerializeField] float maxSpeed = 5f;

    private void FixedUpdate()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += accelSpeed * Time.deltaTime;
            if(currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
}
