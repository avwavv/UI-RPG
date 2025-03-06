using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Character character;

    private void Start()
    {
        Debug.Log("player name: " + player.CharName);
        player.Shout();
        enemy.Shout();
        character.Shout();
    }
}
