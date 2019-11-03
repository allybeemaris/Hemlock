using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float damageAtTime;
    public Collider2D damageTrigger;
    public float liveTime;
    public List<GameObject> nextAttacks;
    public Rigidbody2D attacker;
    public float attackForce;

    protected float timeAlive = 0;
    protected bool appliedDamage = false;

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.fixedDeltaTime;

        var attackerDirection = gameObject.transform.forward.z;

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

                var hardthing = obj.GetComponent<IHardThing>();

                if (hardthing != null)
                {
                    var hardness = hardthing.GetHardness();
                    attacker.AddForce(new Vector2(attackForce * hardness * -attackerDirection, 0f));
                }

                var pushable = obj.GetComponent<IPushable>();

                if (pushable != null)
                {
                    pushable.Push(attackerDirection, attackForce);
                }
            }
        }

        if (timeAlive >= liveTime)
        {
            Destroy(gameObject);
        }
    }
}
