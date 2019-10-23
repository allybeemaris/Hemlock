using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthText : MonoBehaviour
{
    public Player player;
    public Text text;

    void Update()
    {
        text.text = $"{player.currentHealth}/{player.maxHealth}";
    }
}
