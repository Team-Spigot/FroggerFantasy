using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class GamblerClass : MonoBehaviour
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