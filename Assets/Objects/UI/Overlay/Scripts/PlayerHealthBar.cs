using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public Player player;
    public RectTransform healthBar;

    private float originalLength;

    public void Start()
    {
        originalLength = healthBar.sizeDelta.x;
    }

    void Update()
    {
        var updatedLength = originalLength * ((float)player.currentHealth / (float)player.maxHealth);
        healthBar.sizeDelta = new Vector2(updatedLength, healthBar.sizeDelta.y);
    }
}
