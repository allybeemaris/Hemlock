using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarExplosion : Attack
{
    void Start()
    {
        damageTrigger = GetComponent<CircleCollider2D>();
        nextAttacks = new List<GameObject>
        {
        };
    }
}
