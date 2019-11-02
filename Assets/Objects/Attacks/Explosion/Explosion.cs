using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Attack
{
    void Start()
    {
        damageTrigger = GetComponent<CircleCollider2D>();
        nextAttacks = new List<GameObject>
        {
            (GameObject) Resources.Load(ResourcePaths.FarExplosion)
        };
    }
}
