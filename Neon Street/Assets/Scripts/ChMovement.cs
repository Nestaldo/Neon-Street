using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChMovement : MonoBehaviour
{
    [Header("Jump Values")]
    [SerializeField] float jumpForce = 3f;

    [Header("Rotation Values")]
    [SerializeField] float rotationForce = 2f;
    [SerializeField] float rotationForceInBack = 2f;

    private Rigidbody2D rb;
    private Quaternion originalRotation;
    bool isJumping = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !isJumping || Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
            if (touch.phase == TouchPhase.Began|| touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, rotationForceInBack * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping)
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
