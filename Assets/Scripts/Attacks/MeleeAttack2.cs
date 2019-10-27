using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack2 : Attack
{
    void Start()
    {
        damageTrigger = GetComponent<CapsuleCollider2D>();
        nextAttacks = new List<GameObject>
        {
            (GameObject) Resources.Load(ResourcePaths.MeleeAttack1)
        };
    }
}
