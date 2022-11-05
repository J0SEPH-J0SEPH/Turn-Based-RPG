using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public static BattleScript instance; 
    public PlayerHandler[] playerHandler;
    public List<PlayerPoints> playerList = new List<PlayerPoints>();
    public EnemyHandler enimeHandeler;
    public int PlayerNumber;
    [SerializeField] private List<Stats> AllStats = new List<Stats>();
    public BottomPanelAttacks Panels;
    public Transform EnimeSelecter;
    public List<PlayerAnimator> playerAnimator = new List<PlayerAnimator>();
    // Start is called before the first frame update
   
    void Start()
    {
        InstanciatePlayers();
        UpdateFighterBattleList();
    }

    void InstanciatePlayers()
    {
        playerAnimator.Clear();

        foreach (PlayerPoints Playerinfo in playerHandler[PlayerNumber].playerStats)
        {
            if (Playerinfo.ActivePlayer)
            {
                GameObject PlayerModle = Instantiate(Playerinfo.Modle, Playerinfo.transformPosition, transform.rotation);
                Playerinfo.playerAnimator = PlayerModle.GetComponent<PlayerAnimator>();
                playerList.Add(Playerinfo);
                Playerinfo.playerAnimator.battleScript = this;
                playerAnimator.Add(Playerinfo.playerAnimator);
                Playerinfo.playerAnimator.player = Playerinfo;
            }
        } 
    }

    void UpdateFighterBattleList()
    {
        AllStats = new List<Stats>();
        foreach (PlayerPoints Playerinfo in playerList)
        {
            AllStats.Add(Playerinfo.PlayerStats);
        }
        foreach (EnemyScript EnimeStats in enimeHandeler.EnemyStats)
        {
            AllStats.Add(EnimeStats.stats);
        }
        RankFromSlowestTofastest();
        pickAttacks();
    }

    #region PickAttacks

    float PanelsCount = 0;

    void pickAttacks()
    {
        Panels.Attacks = playerList.Count;
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].ActivePlayer)
            {
                playerList[i].AttackChoice = 0;
                Panels.bottomPanel[i].SetActive(true);

                PanelsCount += 1;
                Panels.PanelScript[i].playerInfo = playerList[i];
                Panels.PanelScript[i].playerInfo.AttackChoice = 0;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (enimeHandeler.ActiveSpaces[i] != null)
            {
                EnimeSelecter.transform.position = enimeHandeler.spawnPoints[i].position;

                return;
            }
        }
    }

    public void DonePickingAttacks()
    {
        PanelsCount = 0;

        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].ActivePlayer)
            {
                Panels.bottomPanel[i].SetActive(false);
                PanelsCount += 1;
            }
        }
        Turn = 0;
        DoAttacks();
    }

    #endregion

    public int Turn = 0;
    public void DoAttacks()
    {
        if (AllStats[Turn].Player == true)
        {
            int TurnAttacker = AllStats[Turn].PlayerController.EnimeToAttack;
            // if (EnimeList.enimePoint[AllStats[Turn].])
            if (enimeHandeler.ActiveSpaces[TurnAttacker] == null)
            {
                FindEnimeTohit();
                return;
            }
            switch (AllStats[Turn].PlayerController.AttackChoice)
            {
                case 5:
                    //Incomplete
                    break;
                case 4:  
                    break;
                case 3:  
                    NextTurn();
                    break;
                case 2: 
                    break;
                case 1:
                    //Attack
                    //enimeHandeler.ActiveSpaces[TurnAttacker].Attacked(AllStats[Turn].damage);
                    //AllStats[Turn].PlayerController.playerAnimator.Target = enimeHandeler.ActiveSpaces[TurnAttacker];
                    TellAnimatorthePAttacker(AllStats[Turn].PlayerController, TurnAttacker);
                    Debug.Log("Player hits");
                    //NextTurn();
                    break;
                default:
                    NextTurn();
                    break;
            }
        }
        else
        {
            Debug.Log("Enime hits");
            NextTurn();
        }
    }

    public void NextTurn()
    {
        Turn += 1;

        if (Turn < AllStats.Count)
        {
            DoAttacks();
        }
        else
        {
            UpdateFighterBattleList();
            Debug.Log("Done");
        }
    }

    void FindEnimeTohit()
    {
        for (int i = 0; i < 9; i++)
        {
            if (enimeHandeler.ActiveSpaces[i] != null)
            {
                AllStats[Turn].PlayerController.EnimeToAttack = i;
                DoAttacks();
                return;
            }
        }
    }

    void TellAnimatorthePAttacker(PlayerPoints Player, int attacker)
    {
        foreach(PlayerAnimator pa in playerAnimator) {
            if(pa.player == Player)
            {
                pa.Target = enimeHandeler.ActiveSpaces[attacker];
                pa.DoAttack();

                return;
            }
        }
    }
    #region RankPlayers

    // Update is called once per frame
    void RankFromSlowestTofastest()
    {
        AllStats.Sort(SortFunction);
    }

    private int SortFunction(Stats a, Stats b)
    {
        if (a.speed < b.speed)
        {
            return 1;
        }
        if (a.speed > b.speed)
        {
            return -1;
        }
        return 0;
    }
    #endregion
}
