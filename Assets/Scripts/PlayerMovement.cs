using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;

    private Rigidbody rb;
    private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;

    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = cam.forward;
        direction.y = 0f;
        direction.Normalize();

        Vector3 movement = direction * vertical * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void Rotate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Quaternion rotation = Quaternion.Euler(0f, horizontal * rotationSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * rotation);
    }
}