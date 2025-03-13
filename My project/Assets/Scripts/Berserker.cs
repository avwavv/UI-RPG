using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class Berserker : Enemy
{
   [SerializeField] private int agroGain;
   
   public override int Attack()
   {
      aggression += agroGain;
      return Weapon.GetDamage()+ aggression / 10;
   }
   
}
