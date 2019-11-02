using UnityEngine;

public class KillFloor : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        var killable = hitInfo.GetComponent<IKillable>();

        if (killable != null) {
            killable.Kill();
        }
    }
}
