using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class SentinelClass : MonoBehaviour
    {
        public StatStruct stats;

        public bool attackCalled = false;
        public GameObject battleManager;

        void Start()
        {
            stats.str = Random.Range(9, 11);
            stats.vit = Random.Range(20, 25);
            stats.agl = Random.Range(6, 9);
            stats.aim = Random.Range(8, 10);
            stats.lck = Random.Range(9, 11);
            stats.ang = Random.Range(3, 4);
            stats.fai = Random.Range(3, 4);
            stats.skl = Random.Range(2, 4);

            stats.HP = stats.MaxHP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MP = stats.MaxMP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("Sentinel\nagl: " + stats.agl);
            attackCalled = false;
        }

        void Update()
        {
            PlayerPrefs.SetFloat("sentStr", stats.str);
            PlayerPrefs.SetFloat("sentVit", stats.vit);
            PlayerPrefs.SetFloat("sentAgl", stats.agl);
            PlayerPrefs.SetFloat("sentAim", stats.aim);
            PlayerPrefs.SetFloat("sentLck", stats.lck);
            PlayerPrefs.SetFloat("sentAng", stats.ang);
            PlayerPrefs.SetFloat("sentFai", stats.fai);
            PlayerPrefs.SetFloat("sentSkl", stats.skl);

            PlayerPrefs.SetFloat("sentMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("sentHP", stats.HP);

            PlayerPrefs.SetFloat("sentMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("sentMP", stats.MP);
        }
    }
}
