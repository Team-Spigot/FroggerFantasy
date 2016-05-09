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
            stats.str = 100;
            stats.vit = Random.Range(1, 5);
            stats.agl = 5;
            stats.aim = Random.Range(4, 5);
            stats.lck = Random.Range(1, 5);
            stats.ang = Random.Range(1, 5);
            stats.fai = Random.Range(1, 5);
            stats.skl = Random.Range(1, 5);

            stats.MaxHP = 10;
            stats.MaxMP = stats.MP = Random.Range(1, 5);

            stats.exp = 0;

            Debug.Log("Warrior\nagl: " + stats.agl);
            attackCalled = false;
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
            PlayerPrefs.SetFloat("warHP", stats.MaxHP);

            PlayerPrefs.SetFloat("warMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("warMP", stats.MP);
        }
    }
}
