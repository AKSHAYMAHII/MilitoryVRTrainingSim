using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1.5f;

    Rigidbody rb;
    Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector3 direction = player.position - rb.position;
        direction.y = 0f;              // NO vertical movement
        direction = direction.normalized;

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
