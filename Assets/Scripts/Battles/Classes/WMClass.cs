using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class WMClass : MonoBehaviour
    {
        public StatStruct stats;

        void Start()
        {
            stats.str = Random.Range(4, 6);
            stats.vit = Random.Range(8, 12);
            stats.agl = Random.Range(3, 6);
            stats.aim = Random.Range(5, 10);
            stats.lck = Random.Range(5, 7);
            stats.ang = Random.Range(1, 3);
            stats.fai = Random.Range(9, 14);
            stats.skl = Random.Range(2, 4);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("White\nagl: " + stats.agl);
        }

        void Update()
        {
            PlayerPrefs.SetFloat("WMStr", stats.str);
            PlayerPrefs.SetFloat("WMVit", stats.vit);
            PlayerPrefs.SetFloat("WMAgl", stats.agl);
            PlayerPrefs.SetFloat("WMAim", stats.aim);
            PlayerPrefs.SetFloat("WMLck", stats.lck);
            PlayerPrefs.SetFloat("WMAng", stats.ang);
            PlayerPrefs.SetFloat("wMFai", stats.fai);
            PlayerPrefs.SetFloat("WMSkl", stats.skl);

            PlayerPrefs.SetFloat("WMMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("WMHP", stats.HP);

            PlayerPrefs.SetFloat("WMMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("WMMP", stats.MP);
        }
    }
}
