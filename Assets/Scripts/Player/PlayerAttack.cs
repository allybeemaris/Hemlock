using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attack;
    public Transform attackPoint;
    public float attackWaitTime;

    private float currentWaitTime;

    void Update()
    {
        currentWaitTime += Time.fixedDeltaTime;

        if (Input.GetButtonDown("Fire1")) {
            if (currentWaitTime > attackWaitTime) {
                Instantiate(attack, attackPoint.position, attackPoint.rotation);
                currentWaitTime -= attackWaitTime;
            }
        }
    }
}
