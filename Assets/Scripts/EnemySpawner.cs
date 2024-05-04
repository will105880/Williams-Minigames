using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class EnemySpawner : MonoBehaviour
{
    public GameObject m_Enemy;
    public GameObject Orgin;
    float yrand = 0f;
    float xrand = 0f;
    float count = 0;
    float x = 1;
    public bool dead = false;

    void Start()
    {
        InvokeRepeating("offset", 1f, 1f);  //1s delay, repeat every 1s
    }

    void offset()
    {
        if (count == 10f)
        {
            count = 0f;
            x += 1f;
        }
        for(int i = 0; i < x; i++)
        {
            if (!dead)
            repeat();
        }
        count += 1f;

    }


    void repeat()
    {
        xrand = UnityEngine.Random.Range(-1, 1);
        yrand = UnityEngine.Random.Range(-18, 18);
        Boolean x = true;
        if (xrand < 0f)
        {
            x = false;
        }
        if (x)
            xrand = 1f;
        else
            xrand = -1f;
        xrand *= 35f;
        var xy = new Vector2(xrand, yrand);
        GameObject m_Enemy2 = Instantiate(m_Enemy, xy, Quaternion.identity);
        m_Enemy2.name = m_Enemy.name;
    }
}
