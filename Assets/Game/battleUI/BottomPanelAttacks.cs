using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPanelAttacks : MonoBehaviour
{
    public List<GameObject> bottomPanel = new List<GameObject>();
    public List<Panel> PanelScript = new List<Panel>();

    public int Attacks = 2;

    public BattleScript battleScript;

    public int PlayerGettingHit;



    public void CheckifReady()
    {
        if(Attacks <= 0)
        {
            battleScript.DonePickingAttacks();
        }

    }
}
