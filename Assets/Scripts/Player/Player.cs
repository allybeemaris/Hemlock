using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable, IKillable
{
    public int health = 400;
    public int damage = 20;

    private ObjectType objectType = ObjectType.Player;

    public void Kill() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Damage(int damage, ObjectType source) {
        if (source == ObjectType.Player) {
            return;
        }

        health -= damage;

        if(health <= 0) {
            Kill();
        }

        Debug.Log("Player: " + health);
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        var damageable = hitInfo.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(damage, objectType);
        }
    }
}
