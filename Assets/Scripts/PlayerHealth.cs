using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;   // STOP if already dead

        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Mission Failed - Captain Dead");
            Time.timeScale = 0f;
        }
    }
}
