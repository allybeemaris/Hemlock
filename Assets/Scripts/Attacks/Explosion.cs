using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;
    public float damageAtTime;
    public float liveTime;

    private CircleCollider2D damageTrigger;
    private float timeAlive = 0;
    private bool appliedDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        damageTrigger = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.fixedDeltaTime;

        if (timeAlive >= liveTime)
        {
            Destroy(gameObject);
        }

        if (timeAlive >= damageAtTime
            && appliedDamage == false)
        {
            appliedDamage = true;

            var objects = Physics2D.OverlapCircleAll(damageTrigger.transform.position, damageTrigger.radius);
            foreach(var obj in objects)
            {
                var damageable = obj.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    damageable.Damage(damage, ObjectType.Player);
                }
            }
        }

    }
}
