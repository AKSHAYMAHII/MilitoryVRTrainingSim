using UnityEngine;

public class FriendlyFollow : MonoBehaviour
{
    public float speed = 1.2f;
    public float followDistance = 1.5f;

    Transform player;
    Rigidbody rb;

    void Start()
    {
        player = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > followDistance)
        {
            Vector3 move = rb.position + direction.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(move);
        }
    }
}
