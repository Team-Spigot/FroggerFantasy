using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class MonkClass : MonoBehaviour
    {

        public StatStruct stats;

        void Start()
        {
            stats.str = Random.Range(1, 5);
            stats.vit = Random.Range(1, 1);
            stats.agl = 1;
            stats.aim = Random.Range(4, 5);
            stats.lck = Random.Range(1, 5);
            stats.ang = Random.Range(1, 5);
            stats.fai = Random.Range(1, 5);
            stats.skl = Random.Range(1, 5);

            stats.MaxHP = stats.HP = Random.Range(1, 5);
            stats.MaxMP = stats.MP = Random.Range(1, 5);

            stats.exp = 0;

            Debug.Log("Monk\nagl: " + stats.agl);
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
