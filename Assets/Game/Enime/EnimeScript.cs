﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimeScript : MonoBehaviour
{

    public EnimePoints enimePoints;

    public Stats stats;

    public int Pos;


    public GameObject UI;
    public Vector3 height;
    public Transform HealthBar;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject GM = Instantiate(UI, transform.position + height, transform.rotation, transform);
        HealthBar = GM.transform.GetChild(0);

    }



    public void Attacked(float Damage)
    {
        stats.health -= Damage;

        float HealthScale = stats.health / stats.maxHealth;
        if(HealthScale < 0)
        {
            HealthScale = 0;
        }
        HealthBar.transform.localScale = new Vector3(HealthScale, 1, 1);
        if (stats.health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        EnimeHandeler.instance.ActiveSpaces[Pos] = null;
        EnimeHandeler.instance.eniemeStats.Remove(this); 
        Destroy(gameObject);

    }
}
