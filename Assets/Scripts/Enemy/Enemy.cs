using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IKillable
{
    public int health = 100;
    public int damage = 20;

    private ObjectType objectType = ObjectType.Enemy;
    public void Kill() {
        Destroy(gameObject);
    }

    public void Damage(int damage, ObjectType source) {
        if (source == ObjectType.Enemy) {
            return;
        }

        health -= damage;

        if(health <= 0) {
            Kill();
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        var damageable = hitInfo.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(damage, objectType);
        }
    }
}
