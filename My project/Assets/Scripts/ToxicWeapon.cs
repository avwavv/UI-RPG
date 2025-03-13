using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicWeapon : Weapon
{
    [SerializeField] private int toxicity;
    
    public override void ApplyEffect(Character target)
    {
        target.GetHit(toxicity);
        Debug.Log(target.name+ " poisoned for: " + toxicity );
    }
}
