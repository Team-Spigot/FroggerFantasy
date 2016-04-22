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
            stats.str = Random.Range(1, 2);
            stats.vit = Random.Range(1, 5);
            stats.agl = 2;
            stats.aim = Random.Range(4, 5);
            stats.lck = Random.Range(1, 5);
            stats.ang = Random.Range(1, 5);
            stats.fai = Random.Range(1, 5);
            stats.skl = Random.Range(1, 5);

            stats.MaxHP = stats.HP = Random.Range(1, 5);
            stats.MaxMP = stats.MP = Random.Range(1, 5);

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
