using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class NinjaClass : MonoBehaviour
    {

        public StatStruct stats;
        

        void Start()
        {
            stats.str = Random.Range(6, 9);
            stats.vit = Random.Range(7, 10);
            stats.agl = Random.Range(15, 20);
            stats.aim = Random.Range(8, 10);
            stats.lck = Random.Range(9, 11);
            stats.ang = Random.Range(3, 4);
            stats.fai = Random.Range(3, 4);
            stats.skl = Random.Range(2, 4);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            Debug.Log("Ninja\nagl: " + stats.agl);
            Debug.Log("Ninja\nhp: " + stats.HP);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("ninjStr", stats.str);
            PlayerPrefs.SetFloat("ninjVit", stats.vit);
            PlayerPrefs.SetFloat("ninjAgl", stats.agl);
            PlayerPrefs.SetFloat("ninjAim", stats.aim);
            PlayerPrefs.SetFloat("ninjLck", stats.lck);
            PlayerPrefs.SetFloat("ninjAng", stats.ang);
            PlayerPrefs.SetFloat("ninjFai", stats.fai);
            PlayerPrefs.SetFloat("ninjSkl", stats.skl);

            PlayerPrefs.SetFloat("ninjMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("ninjHP", stats.HP);

            PlayerPrefs.SetFloat("ninjMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("ninjMP", stats.MP);
        }
    }
}
