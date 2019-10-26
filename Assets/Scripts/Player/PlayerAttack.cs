using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;

    private List<GameObject> attacks;
    private GameObject lastAttack;
    private Attack lastAttackDetails;
    private GameObject nextAttack;

    public void Start() {
        attacks = new List<GameObject>
        {
            (GameObject) Resources.Load(ResourcePaths.Explosion)
        };
    }

    public void Update()
    {
        if (Input.GetButton(Inputs.Attack))
        {
            if(lastAttack == null)
            {
                var attackToMake = attacks.First();

                lastAttack = Instantiate(attackToMake, attackPoint.position, attackPoint.rotation);
                lastAttackDetails = lastAttack.GetComponent<Attack>();
            }
        }
    }
}
