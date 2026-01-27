using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 7f;
    Rigidbody rb;
    bool isGrounded;
    InteractableDrop currentInteract;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteract != null)
        {
            currentInteract.Interact();
        }
    }
    public void AddSpeed(float amouth)
    {
        speed += amouth;
        Debug.Log("Speed = " + speed);
    }
    void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Vector3 velocity = rb.linearVelocity;
        velocity.x = H * speed;
        velocity.z = V * speed;
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
    void OnTriggerEnter(Collider other)
    {
        InteractableDrop interact = other.GetComponent<InteractableDrop>();
        if (interact != null)
        {
            currentInteract = interact;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractableDrop>() != null)
        {
            currentInteract = null;
        }
    }

        void LateUpdate()
    {
        //หลังจากได้ Sprite 2D
        //transform.forward = Camera.main.transform.forward;
    }
    
    


}
