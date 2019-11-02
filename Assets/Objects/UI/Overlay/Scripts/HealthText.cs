using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Player player;
    public Text text;

    void Start()
    {

    }

    void Update()
    {
        text.text = $"{player.currentHealth}/{player.maxHealth}";
    }
}
