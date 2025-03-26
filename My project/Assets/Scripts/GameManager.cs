using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy[] enemy;

    private int currentEnemy;
    private bool gameIsActive;
    private bool shieldOn;
    private int shieldDurability = 0; 
    

    [SerializeField] private TMP_Text playerName, playerHealth,level, enemyName, enemyHealth;
    [SerializeField] private GameObject WinScreen, LooseScreen, ShieldIcon, ShieldButton;
    
    

    private void Start()
    {
        UpdateStats();
        gameIsActive = true;
        shieldOn = false;
        ShieldButton.SetActive(true);
        LooseScreen.SetActive(false);
        WinScreen.SetActive(false);
        currentEnemy = 0;
        playerName.text = player.CharName;
        enemyName.text = enemy[currentEnemy].name;
        level.text = "Level: " + player.level;
    }

    private void Update()
    {
        if (player.exp >= 10)
        {
            player.LevelUp(20,2);
            player.level += 1;
            player.exp -= 10;
            UpdateStats();
        }
        
        if (shieldDurability == 8)
        {
            player.armour = 0;
            ShieldIcon.SetActive(false);
            ShieldButton.SetActive(false);
        }
        
        if (shieldOn)
        {
            player.armour = 20;
            ShieldIcon.SetActive(true);
        }
        else
        {
            player.armour = 0;
            ShieldIcon.SetActive(false);
        }
        
        CheckEnemyStatus();

        if (player.health <= 0)
        {
            gameIsActive = false;
            LooseScreen.SetActive(true);
        }
    }

    private void CheckEnemyStatus()
    {
        if(enemy[currentEnemy].health <= 0 && gameIsActive)
        {
            if (currentEnemy < enemy.Length -1)
            {
                player.exp += enemy[currentEnemy].experienceToGet;
                currentEnemy += 1;
                enemyName.text = enemy[currentEnemy].name;
                UpdateStats();
            }
            else
            {
                gameIsActive = false;
                WinScreen.SetActive(true);
            }
        }
    }

    public void DoRound()
    {
        if (gameIsActive)
        {
            shieldDurability = Random.Range(0,10);
            enemy[currentEnemy].GetHit(player.Weapon);
            player.Weapon.ApplyEffect(enemy[currentEnemy]);
            player.GetHit(enemy[currentEnemy].Weapon);
            enemy[currentEnemy].Weapon.ApplyEffect(player);
            UpdateStats();
        }
    }

    public void Shield()
    {
        shieldOn = !shieldOn;
    }
    

    public void UpdateStats()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy[currentEnemy].health.ToString();
        level.text = "Level: " + player.level;
    }
}
