using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public BattleScript battleScript;

    public PlayerPoints player;
    public Animator anim;
    public EnimeScript Target;

  


    public void DoAttack()
    {
        anim.SetBool("Attack", true);
    }

    void HitEnime()
    {

        Target.Attacked(player.PlayerStats.damage);
    }

    void DoneAttack()
    {
        anim.SetBool("Attack", false);

        battleScript.NextTurn();

    }

}
