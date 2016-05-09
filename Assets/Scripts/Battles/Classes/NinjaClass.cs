using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class NinjaClass : MonoBehaviour
    {

        public StatStruct stats;

        public bool attackCalled = false;

        public GameObject battleManager;

        void Start()
        {
            stats.str = Random.Range(1, 5);
            stats.vit = Random.Range(1, 5);
            stats.agl = 100;
            stats.aim = Random.Range(4, 5);
            stats.lck = Random.Range(1, 5);
            stats.ang = Random.Range(1, 5);
            stats.fai = Random.Range(1, 5);
            stats.skl = Random.Range(1, 5);

            stats.MaxHP = stats.HP = Random.Range(5, 5);
            stats.MaxMP = stats.MP = Random.Range(1, 5);

            stats.exp = 0;

            Debug.Log("Ninja\nagl: " + stats.agl);
            attackCalled = false;
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
