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

        void Start()
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
            Debug.Log("Enemy\nhp: " + stats.HP);
            Debug.Log("Enemy\nagl: " + stats.agl);

        }

        void Update()
        {
            manager = GameObject.FindGameObjectWithTag("GameController");

            if (manager.GetComponent<BattleManager>().runAttack == true)
            {
                if (manager.GetComponent<BattleManager>().isCrit)
                {
                    stats.HP -= manager.GetComponent<BattleManager>().playerStats.str * 5;
                    manager.GetComponent<BattleManager>().runAttack = false;
                    Debug.Log("EnemyHealth\nhp: " + stats.HP);
                    Debug.Log("\n");
                    Debug.Log("\n");
                }
                else if (!manager.GetComponent<BattleManager>().isCrit)
                {
                    stats.HP -= manager.GetComponent<BattleManager>().playerStats.str;
                    manager.GetComponent<BattleManager>().runAttack = false;
                    Debug.Log("EnemyHealth\nhp: " + stats.HP);
                    Debug.Log("\n");
                    Debug.Log("\n");
                }
            }
        }
    }
}