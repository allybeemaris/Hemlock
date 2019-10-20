using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IKillable
{
    public int health = 100;
    public int damage = 20;

    public void Kill() {
        Destroy(gameObject);
    }

    public void Damage(int damage) {
        health -= damage;

        if(health <= 0) {
            Kill();
        }
        Debug.Log("Enemy: " + health);
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        var damageable = hitInfo.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(damage);
        }
    }
}
