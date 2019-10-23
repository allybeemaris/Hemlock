using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable, IKillable
{
    public int maxHealth = 400;
    public int currentHealth = 400;
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

        currentHealth -= damage;

        if(currentHealth <= 0) {
            currentHealth = 0;
            Kill();
        }
    }
}
