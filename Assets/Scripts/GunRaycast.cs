using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    public float range = 50f;
    public ParticleSystem muzzleFlash;
    public AudioSource gunAudio;
    public float fireRate = 0.3f;
    float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        muzzleFlash.Play();
        gunAudio.Play();

        if (Physics.Raycast(ray, out hit, range))
{
    Debug.Log("Hit: " + hit.collider.name);

    EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
    if (enemy != null)
    {
        enemy.TakeDamage(1);
    }
}
    }
}
