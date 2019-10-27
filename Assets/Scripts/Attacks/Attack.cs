using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float damageAtTime;
    public float liveTime;
    public List<GameObject> nextAttacks;

    protected Collider2D damageTrigger;
    protected float timeAlive = 0;
    protected bool appliedDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        damageTrigger = GetComponent<Collider2D>();
        nextAttacks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.fixedDeltaTime;

        if (timeAlive >= damageAtTime
            && appliedDamage == false)
        {
            appliedDamage = true;

            var contactFilter = new ContactFilter2D();
            var objects = new Collider2D[50];

            Physics2D.OverlapCollider(damageTrigger, contactFilter, objects);

            foreach(var obj in objects)
            {
                if (obj == null) {
                    break;
                }

                var damageable = obj.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    damageable.Damage(damage, ObjectType.Player);
                }
            }
        }

        if (timeAlive >= liveTime)
        {
            Destroy(gameObject);
        }
    }
}
