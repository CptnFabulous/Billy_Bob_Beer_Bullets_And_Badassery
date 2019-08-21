using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Damage(int damageAmount)
    {
        base.Damage(damageAmount);
        // play animations and stuff
    }

    public override void Heal(int healAmount)
    {
        base.Heal(healAmount);
        // play animations and stuff
    }

    public override void Die()
    {
        // play death animations, drop items, add to score etc.. Remove the base.Die() part if you want a persistent corpse.
        base.Die();
    }
}
