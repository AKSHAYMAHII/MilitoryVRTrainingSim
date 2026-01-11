using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector3 forward = Camera.main.transform.forward;
    Vector3 right = Camera.main.transform.right;

    forward.y = 0;
    right.y = 0;

    Vector3 move = forward.normalized * v + right.normalized * h;
    transform.position += move * speed * Time.deltaTime;
    }

}
