using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon weapon;

    public Weapon Weapon
    {
        get { return weapon; }
    }

    public virtual int Attack() //virtual so we can edit this method
    {
        return weapon.GetDamage();
    }

    public void GetHit(int damage)
    {
        Debug.Log(name+ " starting health: " + health);
        health -= damage;
        Debug.Log(name+ " health after attack: " + health);
    }

    public void GetHit(Weapon weapon)
    {
        Debug.Log(name+ " starting health: " + health);
        health -= weapon.GetDamage();
        Debug.Log(name + " health after get hit by " + weapon.name + ": " + health);
    }
}
