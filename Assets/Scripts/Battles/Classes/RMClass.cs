using UnityEngine;
using System.Collections;


namespace TeamSpigot
{
    public class RMClass : MonoBehaviour
    {
        public StatStruct stats;
        public bool attackCalled = false;
        public GameObject battleManager;

        void Start()
        {
            stats.str = Random.Range(4, 7);
            stats.vit = Random.Range(6, 9);
            stats.agl = Random.Range(7, 10);
            stats.aim = Random.Range(5, 8);
            stats.lck = Random.Range(3, 5);
            stats.ang = Random.Range(5, 8);
            stats.fai = Random.Range(5, 8);
            stats.skl = Random.Range(2, 4);

            stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
            stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

            stats.exp = 0;

            Debug.Log("rm\nagl: " + stats.agl);
            attackCalled = false;
        }

        void Update()
        {
            PlayerPrefs.SetFloat("RMStr", stats.str);
            PlayerPrefs.SetFloat("RMVit", stats.vit);
            PlayerPrefs.SetFloat("RMAgl", stats.agl);
            PlayerPrefs.SetFloat("RMAim", stats.aim);
            PlayerPrefs.SetFloat("RMLck", stats.lck);
            PlayerPrefs.SetFloat("RMAng", stats.ang);
            PlayerPrefs.SetFloat("RMFai", stats.fai);
            PlayerPrefs.SetFloat("RMSkl", stats.skl);

            PlayerPrefs.SetFloat("RMMaxHP", stats.MaxHP);
            PlayerPrefs.SetFloat("RMHP", stats.HP);

            PlayerPrefs.SetFloat("RMMaxMP", stats.MaxMP);
            PlayerPrefs.SetFloat("RMMP", stats.MP);
        }
    }
}
