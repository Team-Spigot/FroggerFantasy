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
            enemyNumber = Random.Range(1, 8);

            if (enemyNumber <= 4)
            {
                stats.str = Random.Range(6, 10);
                stats.vit = Random.Range(6, 10);
                stats.agl = Random.Range(11, 14);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.MaxHP = stats.HP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Nice_Car_Enemy");
            }
            if (enemyNumber <= 7 && enemyNumber > 4)
            {
                stats.str = Random.Range(7, 13);
                stats.vit = Random.Range(9, 13);
                stats.agl = Random.Range(8, 10);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.MaxHP = stats.HP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Standing_Car_Enemy");
            }
            if (enemyNumber == 8)
            {
                stats.str = Random.Range(10, 15);
                stats.vit = Random.Range(12, 20);
                stats.agl = Random.Range(1, 5);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.MaxHP = stats.HP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MaxMP = stats.MP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));
            }

            stats.exp = 0;
            Debug.Log("Enemy\nagl: " + stats.agl);
            FindObjectOfType<BattleManager>().enmAgls = stats.agl;
        }

        void Update()
        {
            if (stats.HP <= 0)
            {
                //gameObject.SetActive(false);
            }
        }
    }
}