using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float range = 30f;
    public float fireRate = 1.5f;
    public AudioSource enemyAudio;

    float nextFireTime;
    Transform player;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        // Face the captain
        transform.LookAt(new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z
        ));

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (enemyAudio != null)
            enemyAudio.Play();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("MainCamera"))
            {
                PlayerHealth player = hit.collider.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(1);
                }
            }
        }
    }
}
