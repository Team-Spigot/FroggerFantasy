﻿using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class UndeadClass : MonoBehaviour
    {
        public StatStruct stats;

        void Start()
        {
            stats.str = Random.Range(3, 7);
            stats.vit = Random.Range(3, 4);
            stats.agl = Random.Range(1, 4);
            stats.aim = Random.Range(5, 10);
            stats.lck = Random.Range(2, 4);
            stats.ang = Random.Range(3, 4);
            stats.fai = Random.Range(3, 4);
            stats.skl = Random.Range(4, 7);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 75 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("zambo\nagl: " + stats.agl);
            Debug.Log("zambo\nhp: " + stats.HP);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("UDStr", stats.str);
            PlayerPrefs.SetFloat("UDVit", stats.vit);
            PlayerPrefs.SetFloat("UDAgl", stats.agl);
            PlayerPrefs.SetFloat("UDAim", stats.aim);
            PlayerPrefs.SetFloat("UDLck", stats.lck);
            PlayerPrefs.SetFloat("UDAng", stats.ang);
            PlayerPrefs.SetFloat("UDFai", stats.fai);
            PlayerPrefs.SetFloat("UDSkl", stats.skl);

            PlayerPrefs.SetFloat("UDMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("UDHP", stats.HP);

            PlayerPrefs.SetFloat("UDMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("UDMP", stats.MP);
        }
    }
}
