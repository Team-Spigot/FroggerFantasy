using UnityEngine;
using UnityEditor;
using System.Collections;

namespace TeamSpigot
{
    public class Member1 : MonoBehaviour
    {
        public StatStruct stats;

        public GameObject mem1;

        public bool attackCalled = false;
        public GameObject battleManager;

        public bool mem1Dead;

        // Use this for initialization
        void Start()
        {
            mem1.tag = PlayerPrefs.GetString("member1");

            if (mem1.tag == "WARRIOR")
            {
                stats.str = PlayerPrefs.GetFloat("warStr");
                stats.vit = PlayerPrefs.GetFloat("warVit");
                stats.agl = PlayerPrefs.GetFloat("warAgl");
                stats.aim = PlayerPrefs.GetFloat("warAim");
                stats.lck = PlayerPrefs.GetFloat("warLck");
                stats.ang = PlayerPrefs.GetFloat("warAng");
                stats.fai = PlayerPrefs.GetFloat("warFai");
                stats.skl = PlayerPrefs.GetFloat("warSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("warMaxHP");
                stats.HP = PlayerPrefs.GetFloat("warHP");
                stats.MaxMP = PlayerPrefs.GetFloat("warMaxMP");
                stats.MP = PlayerPrefs.GetFloat("warMP");

                mem1.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/ArmoredFighterBunny.png", typeof(Sprite));
            }
            if (mem1.tag == "NINJA")
            {
                stats.str = PlayerPrefs.GetFloat("ninjStr");
                stats.vit = PlayerPrefs.GetFloat("ninjVit");
                stats.agl = PlayerPrefs.GetFloat("ninjAgl");
                stats.aim = PlayerPrefs.GetFloat("ninjAim");
                stats.lck = PlayerPrefs.GetFloat("ninjLck");
                stats.ang = PlayerPrefs.GetFloat("ninjAng");
                stats.fai = PlayerPrefs.GetFloat("ninjFai");
                stats.skl = PlayerPrefs.GetFloat("ninjSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("ninjMaxHP");
                stats.HP = PlayerPrefs.GetFloat("ninjHP");
                stats.MaxMP = PlayerPrefs.GetFloat("ninjMaxMP");
                stats.MP = PlayerPrefs.GetFloat("ninjMP");

                mem1.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/NinjaBunny.png", typeof(Sprite));
            }
            if (mem1.tag == "MONK")
            {
                stats.str = PlayerPrefs.GetFloat("monkStr");
                stats.vit = PlayerPrefs.GetFloat("monkVit");
                stats.agl = PlayerPrefs.GetFloat("monkAgl");
                stats.aim = PlayerPrefs.GetFloat("monkAim");
                stats.lck = PlayerPrefs.GetFloat("monkLck");
                stats.ang = PlayerPrefs.GetFloat("monkAng");
                stats.fai = PlayerPrefs.GetFloat("monkFai");
                stats.skl = PlayerPrefs.GetFloat("monkSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("monkMaxHP");
                stats.HP = PlayerPrefs.GetFloat("monkHP");
                stats.MaxMP = PlayerPrefs.GetFloat("monkMaxMP");
                stats.MP = PlayerPrefs.GetFloat("monkMP");

                mem1.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/RedFighterBunny.png", typeof(Sprite));
            }
            if (mem1.tag == "SENTINEL")
            {
                stats.str = PlayerPrefs.GetFloat("sentStr");
                stats.vit = PlayerPrefs.GetFloat("sentVit");
                stats.agl = PlayerPrefs.GetFloat("sentAgl");
                stats.aim = PlayerPrefs.GetFloat("sentAim");
                stats.lck = PlayerPrefs.GetFloat("sentLck");
                stats.ang = PlayerPrefs.GetFloat("sentAng");
                stats.fai = PlayerPrefs.GetFloat("sentFai");
                stats.skl = PlayerPrefs.GetFloat("sentSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("sentMaxHP");
                stats.HP = PlayerPrefs.GetFloat("sentHP");
                stats.MaxMP = PlayerPrefs.GetFloat("sentMaxMP");
                stats.MP = PlayerPrefs.GetFloat("sentMP");

                mem1.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/SentinelBunny.png", typeof(Sprite));
            }
            Debug.Log("mem1." + mem1.tag + "\nagl: " + stats.agl);
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(mem1.tag);

            /*if (battleManager.GetComponent<BattleManager>().runEnemyAttack)
            {
                if (battleManager.GetComponent<BattleManager>().isCrit)
                {
                    stats.HP -= battleManager.GetComponent<BattleManager>().enemyStats.str * 5;
                    battleManager.GetComponent<BattleManager>().runEnemyAttack = false;
                    Debug.Log("mem1\nhp: " + stats.HP + "\n");
                }
                else if (!battleManager.GetComponent<BattleManager>().isCrit)
                {
                    stats.HP -= battleManager.GetComponent<BattleManager>().enemyStats.str;
                    battleManager.GetComponent<BattleManager>().runEnemyAttack = false;
                    Debug.Log("mem1\nhp: " + stats.HP + "\n");
                }
            }*/

            if (stats.HP <= 0)
            {
                mem1Dead = true;
            }
            else if (stats.HP > 0)
            {
                mem1Dead = false;
            }

            DeadCheck();
        }

        void DeadCheck()
        {
            if (mem1Dead)
            {
                gameObject.SetActive(false);
            }
        }
    }
}