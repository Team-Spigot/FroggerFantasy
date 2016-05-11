using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class MonkClass : MonoBehaviour
    {

        public StatStruct stats;

        void Start()
        {
            stats.str = Random.Range(7, 10);
            stats.vit = Random.Range(7, 10);
            stats.agl = Random.Range(12, 15);
            stats.aim = Random.Range(10, 12);
            stats.lck = Random.Range(9, 11);
            stats.ang = Random.Range(3, 4);
            stats.fai = Random.Range(3, 4);
            stats.skl = Random.Range(4, 5);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("Monk\nagl: " + stats.agl);
            Debug.Log("Monk\nhp: " + stats.HP);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("monkStr", stats.str);
            PlayerPrefs.SetFloat("monkVit", stats.vit);
            PlayerPrefs.SetFloat("monkAgl", stats.agl);
            PlayerPrefs.SetFloat("monkAim", stats.aim);
            PlayerPrefs.SetFloat("monkLck", stats.lck);
            PlayerPrefs.SetFloat("monkAng", stats.ang);
            PlayerPrefs.SetFloat("monkFai", stats.fai);
            PlayerPrefs.SetFloat("monkSkl", stats.skl);

            PlayerPrefs.SetFloat("monkMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("monkHP", stats.HP);

            PlayerPrefs.SetFloat("monkMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("monkMP", stats.MP);
        }
    }
}
