using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;

    private List<GameObject> attacks;
    private GameObject currentAttack;

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
            currentAttack = attacks.First();
            Instantiate(currentAttack, attackPoint.position, attackPoint.rotation);
        }
    }
}
