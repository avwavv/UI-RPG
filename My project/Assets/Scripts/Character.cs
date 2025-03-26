using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon weapon;
    public int armour;
    public int level;

    public Weapon Weapon
    {
        get { return weapon; }
    }

    public virtual int Attack() //virtual so we can edit this method
    {
        return weapon.GetDamage();
    }

    public void LevelUp(int healthRegen, int damageIncrease)
    {
        Weapon.IncreaseDamage(damageIncrease);
        health += healthRegen;
    }

    public void GetHit(int damage)
    {
        health -= damage - armour;
    }

    public void GetHit(Weapon weapon)
    {
        health -= weapon.GetDamage() - armour;
    }
}
