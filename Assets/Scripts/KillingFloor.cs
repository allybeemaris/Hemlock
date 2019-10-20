using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingFloor : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        var killable = hitInfo.GetComponent<IKillable>();

        if (killable != null) {
            killable.Kill();
        }
    }
}
