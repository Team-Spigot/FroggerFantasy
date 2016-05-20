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
            enemyNumber = Random.Range(1, 16);

            if (enemyNumber <= 5)
            {
                stats.str = Random.Range(6, 9);
                stats.vit = Random.Range(6, 10);
                stats.agl = Random.Range(11, 14);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.HP = stats.MaxHP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MP = stats.MaxMP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Nice_Car_Enemy");
            }
            if (enemyNumber <= 9 && enemyNumber > 5)
            {
                stats.str = Random.Range(8, 10);
                stats.vit = Random.Range(9, 13);
                stats.agl = Random.Range(8, 10);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.HP = stats.MaxHP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MP = stats.MaxMP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Standing_Car_Enemy");
            }
            if (enemyNumber <= 12 && enemyNumber > 9)
            {
                stats.str = Random.Range(9, 13);
                stats.vit = Random.Range(5, 8);
                stats.agl = Random.Range(5, 7);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.HP = stats.MaxHP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MP = stats.MaxMP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Aligator");
            }
            if (enemyNumber <= 16 && enemyNumber > 12)
            {
                stats.str = Random.Range(4, 7);
                stats.vit = Random.Range(15, 19);
                stats.agl = Random.Range(2, 5);
                stats.aim = Random.Range(5, 10);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.HP = stats.MaxHP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MP = stats.MaxMP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Turtle");
            }


            if (enemyNumber <= 29 && enemyNumber > 16)
            {
                stats.str = Random.Range(15, 20);
                stats.vit = Random.Range(30, 35);
                stats.agl = Random.Range(1, 5);
                stats.aim = Random.Range(5, 8);
                stats.lck = Random.Range(2, 4);
                stats.ang = Random.Range(3, 4);
                stats.fai = Random.Range(3, 4);
                stats.skl = Random.Range(2, 4);

                stats.HP = stats.MaxHP = (int)Random.Range(100 + (2.5f * (stats.skl * stats.vit)), 150 + (2 * (stats.skl * stats.vit)));
                stats.MP = stats.MaxMP = (int)Random.Range(5 * (stats.ang * stats.fai * stats.skl), 6.5f * (stats.ang * stats.fai * stats.skl));

                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Steam_Roller");
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