using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class EnemyClass : MonoBehaviour
    {
        public StatStruct stats;
        GameObject manager;
        BattleManager bmStuff;

        public bool poisoned;
        public bool decay;
        public bool paralized;

        public int enemyNumber;

       public void Start()
        {
            enemyNumber = Random.Range(1, 3);

            if (enemyNumber == 1)
            {
                stats.str = Random.Range(5, 10);
                stats.vit = Random.Range(8, 12);
                stats.agl = 10;
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
                stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));
            }
            if (enemyNumber == 2)
            {
                stats.str = Random.Range(5, 10);
                stats.vit = Random.Range(8, 12);
                stats.agl = 10;
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
                stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));
            }
            if (enemyNumber == 3)
            {
                stats.str = Random.Range(5, 10);
                stats.vit = Random.Range(8, 12);
                stats.agl = 10;
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.MaxHP = stats.HP = (int)Random.Range(50 + (2.5f * (stats.skl * stats.vit)), 100 + (2 * (stats.skl * stats.vit)));
                stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));
            }

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