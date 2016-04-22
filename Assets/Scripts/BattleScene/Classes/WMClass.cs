using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class WMClass : MonoBehaviour
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
