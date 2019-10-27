﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;

    private List<GameObject> attacks;
    private GameObject lastAttack;
    private GameObject nextAttack;
    private Attack lastAttackDetails;
    private float lastAttackTime;

    public void Start() {
        attacks = new List<GameObject>
        {
            (GameObject) Resources.Load(ResourcePaths.MeleeAttack1)
        };
    }

    public void Update()
    {
        lastAttackTime += Time.fixedDeltaTime;

        if (Input.GetButtonDown(Inputs.Attack))
        {
            if (lastAttack == null)
            {
                nextAttack = attacks.FirstOrDefault();
            }
            else
            {
                nextAttack = lastAttackDetails.nextAttacks.FirstOrDefault();
            }
        }

        if (nextAttack != null)
        {
            if (lastAttack == null
                || lastAttackTime >= lastAttackDetails.liveTime * .5f)
            {
                var instancePosition = new Vector3(attackPoint.position.x, attackPoint.position.y, nextAttack.transform.position.z);

                lastAttack = Instantiate(nextAttack, instancePosition, attackPoint.rotation);
                lastAttackDetails = lastAttack.GetComponent<Attack>();
                lastAttackTime = 0;
                nextAttack = null;
            }
        }
    }
}
