using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public PlayerPoints playerInfo;

    public BottomPanelAttacks PanelSettings;


    public void Start()
    {
        playerInfo.AttackChoice = 0;
        playerInfo.EnimeToAttack = 0;
    }


    public void AttackChoice()
    {
        if (playerInfo.AttackChoice != 0)
        {
            playerInfo.AttackChoice = 0;
            PanelSettings.Attacks += 1;
        }
        else
        {
            playerInfo.AttackChoice = 1;
            PanelSettings.Attacks -= 1;
            PanelSettings.CheckifReady();
        }
    }


    public void DefenceChoice()
    {
        if (playerInfo.AttackChoice != 0)
        {
            playerInfo.AttackChoice = 0;
            PanelSettings.Attacks += 1;
        }
        else
        {
            playerInfo.AttackChoice = 2;
            PanelSettings.Attacks -= 1;
            PanelSettings.CheckifReady();
        }
    }



}
