using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 7f;
    Rigidbody rb;
    bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Vector3 velocity = rb.linearVelocity;
        velocity.x = H * speed;
        velocity.y = V * speed;
        rb.linearVelocity = velocity;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpforce, rb.linearVelocity.z);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void LateUpdate()
    {
        //หลังจากได้ Sprite 2D
        //transform.forward = Camera.main.transform.forward;
    }

    
}
