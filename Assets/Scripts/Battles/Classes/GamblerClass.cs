using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class GamblerClass : MonoBehaviour
    {
        public StatStruct stats;

        void Start()
        {
            stats.str = Random.Range(5, 14);
            stats.vit = Random.Range(5, 11);
            stats.agl = Random.Range(3, 15);
            stats.aim = Random.Range(10, 15);
            stats.lck = Random.Range(10, 14);
            stats.ang = Random.Range(2, 4);
            stats.fai = Random.Range(2, 4);
            stats.skl = Random.Range(1, 6);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("Gambler\nagl: " + stats.agl);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("gambStr", stats.str);
            PlayerPrefs.SetFloat("gambVit", stats.vit);
            PlayerPrefs.SetFloat("gambAgl", stats.agl);
            PlayerPrefs.SetFloat("gambAim", stats.aim);
            PlayerPrefs.SetFloat("gambLck", stats.lck);
            PlayerPrefs.SetFloat("gambAng", stats.ang);
            PlayerPrefs.SetFloat("gambFai", stats.fai);
            PlayerPrefs.SetFloat("gambSkl", stats.skl);

            PlayerPrefs.SetFloat("gambMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("gambHP", stats.HP);

            PlayerPrefs.SetFloat("gambMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("gambMP", stats.MP);
        }
    }
}