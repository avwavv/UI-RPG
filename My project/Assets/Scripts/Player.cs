using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
   [SerializeField] private string charName;
   public int exp;

   public string CharName
   {
      //Can only read this variable
      get { return charName; }
   }

  
}
