using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWerapon : Weapon
{
    public override void ApplyEffect(Character target)
    {
        Debug.Log("Holy effect applied");
    }
}
