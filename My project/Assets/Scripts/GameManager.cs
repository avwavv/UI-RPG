using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
    

    private void Start()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        UpdateHealth();
    }

    public void DoRound()
    {
        /*int damage = player.Attack();*/
        enemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(enemy);
        /*int enemyDamage = enemy.Attack();*/
        player.GetHit(enemy.Weapon);
        enemy.Weapon.ApplyEffect(player);
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy.health.ToString();
    }
}
