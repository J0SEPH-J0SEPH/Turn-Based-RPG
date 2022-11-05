using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [Header ("Constants")]
    public List<EnemyScript> EnemyStats = new List<EnemyScript>();
    public static EnemyHandler instance;
    public List<Transform> spawnPoints = new List<Transform>();
    public EnemyScript[] ActiveSpaces;
    [Header("modifiable")]
    public int maxenimeCount = 6;
    public List<EnemyPoints> enimeTypes = new List<EnemyPoints>();

    void Awake()
    {
        instance = this;
        SpawnEnimes();
    }

    void SpawnEnimes()
    {
        float AmountofEnemys = 0;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int canspawnEnemy = Random.Range(0,10);
            int EnimeType = Random.Range(0,enimeTypes.Count);
            if (AmountofEnemys < maxenimeCount)
            {
                if (canspawnEnemy > 5 || i == spawnPoints.Count - 1 && AmountofEnemys == 0)
                {
                    GameObject Enime =  Instantiate(enimeTypes[EnimeType].Model, spawnPoints[i].transform.position, transform.rotation, transform);
                    EnemyScript EM =  Enime.GetComponent<EnemyScript>();
                    EM.EnemyPoints = enimeTypes[EnimeType];
                    Stats em = enimeTypes[EnimeType].EnemyStats;
                    EM.stats = new Stats(em.speed,em.health,em.maxHealth,em.Defence,em.damage,em.critchance,em.luck,em.magic,em.speedBuff,em.DefenceBuff,em.damageBuff,em.critchanceBuff,em.magicBuff);
                    EnemyStats.Add(EM);
                    AmountofEnemys += 1;
                    ActiveSpaces[i] = EM;
                    EM.Pos = i;
                }
                else
                {
                    ActiveSpaces[i] = null;
                }
            }
            else
            {
                return;
            }
        }
    }

    void PickEnimeAttacks()
    {
        //incomplete
    }
}
