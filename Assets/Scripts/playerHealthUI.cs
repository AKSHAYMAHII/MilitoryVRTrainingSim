using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth player;
    private TextMeshProUGUI txt;

    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (player != null)
        {
            txt.text = "Health: " + player.health;
        }
    }
}
