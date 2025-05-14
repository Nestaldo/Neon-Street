using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChMovement : MonoBehaviour
{
    [Header("Jump Values")]
    [SerializeField] float jumpForce = 3f;

    [Header("Rotation Values")]
    [SerializeField] float rotationForce = 2f;

    private Rigidbody2D rb;
    bool isJumping = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !isJumping || Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        else if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
