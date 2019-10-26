using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Attack
{
    // Start is called before the first frame update
    void Start()
    {
        damageTrigger = GetComponent<CircleCollider2D>();
        nextAttacks = new List<GameObject>
        {
            (GameObject) Resources.Load(ResourcePaths.FarExplosion)
        };
    }
}
