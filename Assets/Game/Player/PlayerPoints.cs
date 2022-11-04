using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerProfile")]
public class PlayerPoints : ScriptableObject
{
    [Header("Player Statistics")]

    public bool ActivePlayer = false;

    public Stats PlayerStats;

  

    [Header("Attacks")]

    public int AttackChoice;
    public int EnimeToAttack = 0;

    [Header("Graphics")]

    public GameObject Modle;

    public Vector3 transformPosition;

    public PlayerAnimator playerAnimator;
}
