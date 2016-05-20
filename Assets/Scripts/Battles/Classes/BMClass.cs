using UnityEngine;
using System.Collections;


namespace TeamSpigot
{
    public class BMClass : MonoBehaviour
    {
        public StatStruct stats;

        void Start()
        {
            stats.str = Random.Range(4, 6);
            stats.vit = Random.Range(8, 12);
            stats.agl = Random.Range(3, 6);
            stats.aim = Random.Range(5, 10);
            stats.lck = Random.Range(5, 7);
            stats.ang = Random.Range(7, 10);
            stats.fai = Random.Range(1, 3);
            stats.skl = Random.Range(2, 4);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("bm\nagl: " + stats.agl);
            Debug.Log("bm\nhp: " + stats.HP);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("BMStr", stats.str);
            PlayerPrefs.SetFloat("BMVit", stats.vit);
            PlayerPrefs.SetFloat("BMAgl", stats.agl);
            PlayerPrefs.SetFloat("BMAim", stats.aim);
            PlayerPrefs.SetFloat("BMLck", stats.lck);
            PlayerPrefs.SetFloat("BMAng", stats.ang);
            PlayerPrefs.SetFloat("BMFai", stats.fai);
            PlayerPrefs.SetFloat("BMSkl", stats.skl);

            PlayerPrefs.SetFloat("BMMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("BMHP", stats.HP);

            PlayerPrefs.SetFloat("BMMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("BMMP", stats.MP);
        }
    }
}
