using System.Collections;
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

    public void Start() {
        attacks = new List<GameObject>
        {
            (GameObject) Resources.Load(ResourcePaths.Explosion)
        };
    }

    public void Update()
    {
        if (Input.GetButtonDown(Inputs.Attack))
        {
            if (lastAttack == null)
            {
                nextAttack = attacks.FirstOrDefault();
                Debug.Log(nextAttack);
            }
            else
            {
                Debug.Log("Details: " + lastAttackDetails);
                Debug.Log("Next Attacks: " + lastAttackDetails.nextAttacks.Count);
                nextAttack = lastAttackDetails.nextAttacks.FirstOrDefault();
                Debug.Log(nextAttack);
            }
        }

        if (nextAttack != null)
        {
            if (lastAttack == null)
            {
                lastAttack = Instantiate(nextAttack, attackPoint.position, attackPoint.rotation);
                lastAttackDetails = lastAttack.GetComponent<Attack>();
                nextAttack = null;
            }
        }
    }
}
