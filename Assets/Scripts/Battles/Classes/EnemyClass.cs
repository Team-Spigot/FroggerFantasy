using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class EnemyClass : MonoBehaviour
    {
        public StatStruct stats;
        GameObject manager;
        BattleManager bmStuff;

        public int enemyNumber = 1;

        public void Start()
        {
            stats.str = 5;
            stats.vit = 0;
            stats.agl = 90;
            stats.aim = 200;
            stats.lck = 0;
            stats.ang = 0;
            stats.fai = 0;
            stats.skl = 0;

            stats.MaxHP = stats.HP = 100;
            stats.MaxMP = stats.MP = 100;

            stats.exp = 0;
            Debug.Log("Enemy\nagl: " + stats.agl);
            manager = GameObject.FindGameObjectWithTag("GameController");
            manager.GetComponent<BattleManager>().enmAgls = stats.agl;
        }

        void Update()
        {
            if (stats.HP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}