﻿using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IKillable, IHardThing
{
    public int health = 100;
    public int damage = 20;
    [Range(0, 1)] public float hardness = 1f;

    private ObjectType objectType = ObjectType.Enemy;

    //IKillable
    public void Kill() {
        Destroy(gameObject);
    }

    //IDamageable
    public void Damage(int damage, ObjectType source) {
        if (source == ObjectType.Enemy) {
            return;
        }

        health -= damage;

        if(health <= 0) {
            Kill();
        }
    }

    //IHardthing
    public float GetHardness()
    {
        return hardness;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        var damageable = hitInfo.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(damage, objectType);
        }
    }
}
