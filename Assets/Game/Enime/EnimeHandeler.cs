using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimeHandeler : MonoBehaviour
{

    [Header ("Constants")]

    public List<EnimeScript> eniemeStats = new List<EnimeScript>();

    public static EnimeHandeler instance;

    public List<Transform> spawnPoints = new List<Transform>();

    public EnimeScript[] ActiveSpaces;

    [Header("modifiable")]

    public int maxenimeCount = 6;

    public List<EnimePoints> enimeTypes = new List<EnimePoints>();

  

    void Awake()
    {
        instance = this;

        SpawnEnimes();
    }

    void SpawnEnimes()
    {

        float AmountofEnimes = 0;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int canspawnEnime = Random.Range(0, 10);

            int EnimeType = Random.Range(0, enimeTypes.Count);
            if (AmountofEnimes < maxenimeCount)
            {
                if (canspawnEnime > 5 || i == spawnPoints.Count - 1 && AmountofEnimes == 0)
                {
 
                    GameObject Enime =  Instantiate(enimeTypes[EnimeType].Modle, spawnPoints[i].transform.position, transform.rotation, transform);

                    EnimeScript EM =  Enime.GetComponent<EnimeScript>();

                    EM.enimePoints = enimeTypes[EnimeType];

                    Stats em = enimeTypes[EnimeType].EnemyStats;

                    EM.stats = new Stats(em.speed,em.health,em.maxHealth,em.Defence,em.damage,em.critchance,em.luck,em.magic,em.speedBuff,em.DefenceBuff,em.damageBuff,em.critchanceBuff,em.magicBuff);

                    eniemeStats.Add(EM);

                    AmountofEnimes += 1;

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


    }
}
