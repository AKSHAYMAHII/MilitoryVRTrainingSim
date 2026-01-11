using UnityEngine;

public class FriendlyShooter : MonoBehaviour
{
    public float range = 20f;
    public float fireRate = 1.5f;
    public Transform gunPoint;

    float nextFireTime;
    Transform currentEnemy;

    void Update()
    {
        FindEnemy();

        if (currentEnemy == null)
            return;

        // Rotate toward enemy
        Vector3 lookDir = currentEnemy.position - transform.position;
        lookDir.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookDir);

        // Shoot enemy
        if (Time.time >= nextFireTime)
        {
            ShootEnemy();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closest = Mathf.Infinity;
        currentEnemy = null;

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < closest && dist <= range)
            {
                closest = dist;
                currentEnemy = e.transform;
            }
        }
    }

    void ShootEnemy()
    {
        Ray ray = new Ray(gunPoint.position, gunPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
            }
        }
    }
}
