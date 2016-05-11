using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class WarriorClass : MonoBehaviour
    {
        public StatStruct stats;

        public bool attackCalled = false;
        public GameObject battleManager;

        void Start()
        {
            stats.str = Random.Range(10, 17);
            stats.vit = Random.Range(9, 12);
            stats.agl = Random.Range(8, 14);
            stats.aim = Random.Range(5, 10);
            stats.lck = Random.Range(2, 4);
            stats.ang = Random.Range(3, 4);
            stats.fai = Random.Range(3, 4);
            stats.skl = Random.Range(2, 4);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("Warrior\nagl: " + stats.agl);
            Debug.Log("Warrior\nhp: " + stats.HP);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("warStr", stats.str);
            PlayerPrefs.SetFloat("warVit", stats.vit);
            PlayerPrefs.SetFloat("warAgl", stats.agl);
            PlayerPrefs.SetFloat("warAim", stats.aim);
            PlayerPrefs.SetFloat("warLck", stats.lck);
            PlayerPrefs.SetFloat("warAng", stats.ang);
            PlayerPrefs.SetFloat("warFai", stats.fai);
            PlayerPrefs.SetFloat("warSkl", stats.skl);

            PlayerPrefs.SetFloat("warMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("warHP", stats.HP);

            PlayerPrefs.SetFloat("warMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("warMP", stats.MP);
        }
    }
}
