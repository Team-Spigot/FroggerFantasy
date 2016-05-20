using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace TeamSpigot
{
    public class BattleAbilities : MonoBehaviour
    {
        string memberTag;
        GameObject memberNumb;
        //StatStruct memberStats;
        bool showAbilties;
        public GameObject[] abilityButts;

        GameObject Member1;
        GameObject Member2;
        GameObject Member3;
        GameObject Member4;
        BattleManager manager;

        public Button AbilitiesButton;

        GameObject Enemy;

        bool Member1gone, Member2gone, Member3gone, Member4gone = false;

        private GameManager _gm;

        void Awake()
        {
            _gm = GameManager.instance;
        }

        void Start()
        {
            if (_gm.PlayerStatusStruct.DeadPlayers[0] == false)
            {
                Member1 = GameObject.Find("Member1");
                Member1gone = false;
            }
            else
            {
                Member1gone = true;
            }
            if (_gm.PlayerStatusStruct.DeadPlayers[1] == false)
            {
                Member2 = GameObject.Find("Member2");
                Member2gone = false;
            }
            else
            {
                Member2gone = true;
            }
            if (_gm.PlayerStatusStruct.DeadPlayers[2] == false)
            {
                Member3 = GameObject.Find("Member3");
                Member3gone = false;
            }
            else
            {
                Member3gone = true;
            }
            if (_gm.PlayerStatusStruct.DeadPlayers[3] == false)
            {
                Member4 = GameObject.Find("Member4");
                Member4gone = false;
            }
            else
            {
                Member4gone = true;
            }

            manager = GetComponent<BattleManager>();
        }
        
        void Update()
        {
            ShitSet();
            TagCheck();
        }

        void ShitSet()
        {
            Enemy = GetComponent<BattleManager>().enemies[0];
            memberTag = GetComponent<BattleManager>().currentPlayer.tag;
            memberNumb = GetComponent<BattleManager>().currentPlayer;
            //memberStats = GetComponent<BattleManager>().playerStats;
        }

        void TagCheck()
        {
            if (memberNumb == Member1)
            {
                if (memberNumb.GetComponent<Member1>().stats.MP <= 0)
                {
                    AbilitiesButton.interactable = false;
                }
                else
                {
                    AbilitiesButton.interactable = true;
                }
            }
            if (memberNumb == Member2)
            {
                if (memberNumb.GetComponent<Member2>().stats.MP <= 0)
                {
                    AbilitiesButton.interactable = false;
                }
                else
                {
                    AbilitiesButton.interactable = true;
                }
            }
            if (memberNumb == Member3)
            {
                if (memberNumb.GetComponent<Member3>().stats.MP <= 0)
                {
                    AbilitiesButton.interactable = false;
                }
                else
                {
                    AbilitiesButton.interactable = true;
                }
            }
            if (memberNumb == Member4)
            {
                if (memberNumb.GetComponent<Member4>().stats.MP <= 0)
                {
                    AbilitiesButton.interactable = false;
                }
                else
                {
                    GameObject.Find("Abilities").GetComponent<Button>().interactable = true;
                }
            }


            if (memberTag == "WARRIOR" && showAbilties)
            {
                abilityButts[0].SetActive(true);
            }
            if (memberTag == "NINJA" && showAbilties)
            {
                abilityButts[1].SetActive(true);
            }
            if (memberTag == "MONK" && showAbilties)
            {
                abilityButts[2].SetActive(true);
            }
            if (memberTag == "SENTINEL" && showAbilties)
            {
                abilityButts[3].SetActive(true);
            }
            if (memberTag == "GAMBLER" && showAbilties)
            {
                abilityButts[4].SetActive(true);
            }
            if (memberTag == "UNDEAD" && showAbilties)
            {
                abilityButts[5].SetActive(true);
            }
            if (memberTag == "WM" && showAbilties)
            {
                abilityButts[6].SetActive(true);
            }
            if (memberTag == "RM" && showAbilties)
            {
                abilityButts[7].SetActive(true);
            }
            if (memberTag == "BM" && showAbilties)
            {
                abilityButts[8].SetActive(true);
            }
        }

        public void ShowAbilities()
        {
            showAbilties = true;
        }

        public void MPHeal()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.MP += Random.Range(3, 9);
                }
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.MP += Random.Range(3, 9);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.MP += Random.Range(3, 9);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.MP += Random.Range(3, 9);
                }
            }
            if (!Member2gone && memberNumb == Member2)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.MP += Random.Range(3, 9);
                }
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.MP += Random.Range(3, 9);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.MP += Random.Range(3, 9);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.MP += Random.Range(3, 9);
                }
            }
            if (!Member3gone && memberNumb == Member3)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.MP += Random.Range(3, 9);
                }
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.MP += Random.Range(3, 9);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.MP += Random.Range(3, 9);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.MP += Random.Range(3, 9);
                }
            }
            if (!Member4gone && memberNumb == Member4)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.MP += Random.Range(3, 9);
                }
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.MP += Random.Range(3, 9);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.MP += Random.Range(3, 9);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.MP += Random.Range(3, 9);
                }
            }
        }

        #region Warrior
        public void Ravage()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.str / 2.5f, (int)Member1.GetComponent<Member1>().stats.str / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.str / 2.5f, (int)Member2.GetComponent<Member2>().stats.str / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.str / 2.5f, (int)Member3.GetComponent<Member3>().stats.str / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.str / 2.5f, (int)Member4.GetComponent<Member4>().stats.str / 1.5f);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[0].SetActive(false);
        }
        public void Slash()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl / 2), ((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 1.5f));

                Member1.GetComponent<Member1>().stats.MP -= 30;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl / 2), ((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 1.5f));

                Member2.GetComponent<Member2>().stats.MP -= 30;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl / 2), ((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 1.5f));

                Member3.GetComponent<Member3>().stats.MP -= 30;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl / 2), ((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 1.5f));

                Member4.GetComponent<Member4>().stats.MP -= 30;
            }

            showAbilties = false;
            abilityButts[0].SetActive(false);
        }
        public void WarCry()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.str += Member1.GetComponent<Member1>().stats.skl;
                    manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.str += Member1.GetComponent<Member1>().stats.skl;
                    manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.str += Member1.GetComponent<Member1>().stats.skl;
                    manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
                }

                    Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.str += Member2.GetComponent<Member2>().stats.skl;
                    manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.str += Member2.GetComponent<Member4>().stats.skl;
                    manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.str += Member2.GetComponent<Member2>().stats.skl;
                    manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
                }

                    Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.str += Member3.GetComponent<Member3>().stats.skl;
                    manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
                }
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.str += Member3.GetComponent<Member3>().stats.skl;
                    manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
                }
                if (!Member4gone)
                {
                    Member4.GetComponent<Member4>().stats.str += Member3.GetComponent<Member3>().stats.skl;
                    manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
                }

                    Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                if (!Member1gone)
                {
                    Member1.GetComponent<Member1>().stats.str += Member4.GetComponent<Member4>().stats.skl;
                    manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
                }
                if (!Member2gone)
                {
                    Member2.GetComponent<Member2>().stats.str += Member4.GetComponent<Member4>().stats.skl;
                    manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
                }
                if (!Member3gone)
                {
                    Member3.GetComponent<Member3>().stats.str += Member4.GetComponent<Member4>().stats.skl;
                    manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str);
                }


                    Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[0].SetActive(false);
        }
        public void BurstBlade()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.skl), ((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.skl * 3.5f));
                Member1.GetComponent<Member1>().stats.HP -= (int)Random.Range(10, 20);

                Member1.GetComponent<Member1>().stats.MP -= 100;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.skl), ((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.skl * 3.5f));
                Member2.GetComponent<Member2>().stats.HP -= (int)Random.Range(10, 20);

                Member2.GetComponent<Member2>().stats.MP -= 100;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.skl), ((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.skl * 3.5f));
                Member3.GetComponent<Member3>().stats.HP -= (int)Random.Range(10, 20);

                Member3.GetComponent<Member3>().stats.MP -= 100;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 2f) * (int)(Member4.GetComponent<Member4>().stats.skl), ((int)Member4.GetComponent<Member4>().stats.str * 2f) * (int)(Member4.GetComponent<Member4>().stats.skl * 3.5f));
                Member4.GetComponent<Member4>().stats.HP -= (int)Random.Range(10, 20);

                Member4.GetComponent<Member4>().stats.MP -= 100;
            }

            showAbilties = false;
            abilityButts[0].SetActive(false);
        }
        #endregion

        #region Ninja
        public void LightWeight()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                manager.GetComponent<BattleManager>().mem1Agl += Member1.GetComponent<Member1>().stats.skl;
                Member1.GetComponent<Member1>().stats.aim += Member1.GetComponent<Member1>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member1.GetComponent<Member1>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member1.GetComponent<Member1>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem1Agl);
                Debug.Log("memberStats.aim: " + Member1.GetComponent<Member1>().stats.aim);
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Agility Stat, got raised to " + Member1.GetComponent<Member1>().stats.agl + " and Aim Stat to " + Member1.GetComponent<Member1>().stats.aim);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                manager.GetComponent<BattleManager>().mem2Agl += Member2.GetComponent<Member2>().stats.skl;
                Member2.GetComponent<Member2>().stats.aim += Member2.GetComponent<Member2>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member2.GetComponent<Member2>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member2.GetComponent<Member2>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem2Agl);
                Debug.Log("memberStats.aim: " + Member2.GetComponent<Member2>().stats.aim);
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Agility Stat, got raised to " + Member2.GetComponent<Member2>().stats.agl + " and Aim Stat to " + Member2.GetComponent<Member2>().stats.aim);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                manager.GetComponent<BattleManager>().mem3Agl += Member3.GetComponent<Member3>().stats.skl;
                Member3.GetComponent<Member3>().stats.aim += Member3.GetComponent<Member3>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member3.GetComponent<Member3>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member3.GetComponent<Member3>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem3Agl);
                Debug.Log("memberStats.aim: " + Member3.GetComponent<Member3>().stats.aim);
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Agility Stat, got raised to " + Member3.GetComponent<Member3>().stats.agl + " and Aim Stat to " + Member3.GetComponent<Member3>().stats.aim);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                manager.GetComponent<BattleManager>().mem4Agl += Member4.GetComponent<Member4>().stats.skl;
                Member4.GetComponent<Member4>().stats.aim += Member4.GetComponent<Member4>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member4.GetComponent<Member4>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member4.GetComponent<Member4>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem4Agl);
                Debug.Log("memberStats.aim: " + Member4.GetComponent<Member4>().stats.aim);
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Agility Stat, got raised to " + Member4.GetComponent<Member4>().stats.agl + " and Aim Stat to " + Member4.GetComponent<Member4>().stats.aim);
            }
            showAbilties = false;
            abilityButts[1].SetActive(false);
        }
        public void Slice()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl / 2), ((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 1.5f));

                Member1.GetComponent<Member1>().stats.MP -= 30;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl / 2), ((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 1.5f));

                Member2.GetComponent<Member2>().stats.MP -= 30;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl / 2), ((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 1.5f));

                Member3.GetComponent<Member3>().stats.MP -= 30;
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl / 2), ((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 1.5f));

                Member4.GetComponent<Member4>().stats.MP -= 30;
            }

            showAbilties = false;
            abilityButts[1].SetActive(false);
        }
        public void PoisonBlade()
        {
            int roll;
            if (!Member1gone && memberNumb == Member1)
            {
                roll = Random.Range(0, (int)Random.Range(0, Member1.GetComponent<Member1>().stats.lck));

                if (roll >= 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 15;
                    Enemy.GetComponent<EnemyClass>().poisoned = true;
                }
                if (roll < 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 10;
                }
                Member1.GetComponent<Member1>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                roll = Random.Range(0, (int)Random.Range(0, Member2.GetComponent<Member2>().stats.lck));

                if (roll >= 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 15;
                    Enemy.GetComponent<EnemyClass>().poisoned = true;
                }
                if (roll < 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 10;
                }
                Member2.GetComponent<Member2>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                roll = Random.Range(0, (int)Random.Range(0, Member3.GetComponent<Member3>().stats.lck));

                if (roll < 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 15;
                    Enemy.GetComponent<EnemyClass>().poisoned = true;
                }
                if (roll < 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 10;
                }
                Member3.GetComponent<Member3>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);

            }
            if (!Member4gone && memberNumb == Member4)
            {
                roll = Random.Range(0, (int)Random.Range(0, Member4.GetComponent<Member4>().stats.lck));

                if (roll >= 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 15;
                    Enemy.GetComponent<EnemyClass>().poisoned = true;
                }
                if (roll >= 6)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= 10;
                }
                Member4.GetComponent<Member4>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);
            }


            showAbilties = false;
            abilityButts[1].SetActive(false);
        }
        public void Sharpen()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[1].SetActive(false);
        }
        #endregion

        #region Monk
        public void Meditate()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member1.GetComponent<Member1>().stats.str);
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member2.GetComponent<Member2>().stats.str);
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member3.GetComponent<Member3>().stats.str);
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member3>().stats.str);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member4.GetComponent<Member4>().stats.str);
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }
        public void FocusPunch()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.str / 2.5f, (int)Member1.GetComponent<Member1>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem1Agl += Member1.GetComponent<Member1>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member1.GetComponent<Member1>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem1Agl);
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Agility Stat, got raised to " + Member1.GetComponent<Member1>().stats.agl);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.str / 2.5f, (int)Member2.GetComponent<Member2>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem2Agl += Member2.GetComponent<Member2>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member2.GetComponent<Member2>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem2Agl);
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Agility Stat, got raised to " + Member2.GetComponent<Member2>().stats.agl);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.str / 2.5f, (int)Member3.GetComponent<Member3>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem3Agl += Member3.GetComponent<Member3>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member3.GetComponent<Member3>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem3Agl);
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Agility Stat, got raised to " + Member3.GetComponent<Member3>().stats.agl);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.str / 2.5f, (int)Member4.GetComponent<Member4>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem4Agl += Member4.GetComponent<Member4>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member4.GetComponent<Member4>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem4Agl);
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Agility Stat, got raised to " + Member4.GetComponent<Member4>().stats.agl);
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }
        public void Mend()
        {
            if (memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (2 * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (2 * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (2 * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (2 * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }
        public void BreakFist()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 1.5f), ((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 2.5f));
                Member1.GetComponent<Member1>().stats.HP -= (int)Random.Range(15, 20);
                Member1.GetComponent<Member1>().stats.str -= (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.str));

                Debug.Log("memberStats.str: " + Member1.GetComponent<Member1>().stats.str);
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got lowered to " + Member1.GetComponent<Member1>().stats.str);
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 1.5f), ((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 2.5f));
                Member2.GetComponent<Member2>().stats.HP -= (int)Random.Range(15, 20);
                Member2.GetComponent<Member2>().stats.str -= (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.str));

                Debug.Log("memberStats.str: " + Member2.GetComponent<Member2>().stats.str);
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got lowered to " + Member2.GetComponent<Member2>().stats.str);
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 1.5f), ((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 2.5f));
                Member3.GetComponent<Member3>().stats.HP -= (int)Random.Range(15, 20);
                Member3.GetComponent<Member3>().stats.str -= (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.str));

                Debug.Log("memberStats.str: " + Member3.GetComponent<Member3>().stats.str);
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got lowered to " + Member3.GetComponent<Member3>().stats.str);
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 1.5f), ((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 2.5f));
                Member4.GetComponent<Member4>().stats.HP -= (int)Random.Range(15, 20);
                Member4.GetComponent<Member4>().stats.str -= (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.str));

                Debug.Log("memberStats.str: " + Member4.GetComponent<Member4>().stats.str);
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got lowered to " + Member4.GetComponent<Member4>().stats.str);
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }
        #endregion

        #region Sentinel
        public void BuffUp()
        {
            if (memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;
                Member1.GetComponent<Member1>().stats.lck += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str + " and luck got raised to " + Member1.GetComponent<Member1>().stats.lck);
            }
            if (memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;
                Member2.GetComponent<Member2>().stats.lck += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str + " and luck got raised to " + Member2.GetComponent<Member2>().stats.lck);
            }
            if (memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;
                Member3.GetComponent<Member3>().stats.lck += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str + " and luck got raised to " + Member3.GetComponent<Member3>().stats.lck);
            }
            if (memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;
                Member4.GetComponent<Member4>().stats.lck += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str + " and luck got raised to " + Member4.GetComponent<Member4>().stats.lck);
            }

            showAbilties = false;
            abilityButts[3].SetActive(false);
        }
        public bool agro1;
        public bool agro2;
        public bool agro3;
        public bool agro4;
        public void Agro()
        {
            if (memberNumb == Member1)
            {
                agro1 = true;

                Member1.GetComponent<Member1>().stats.MP -= 20;
            }
            if (memberNumb == Member2)
            {
                agro2 = true;

                Member2.GetComponent<Member2>().stats.MP -= 20;
            }
            if (memberNumb == Member3)
            {
                agro3 = true;

                Member3.GetComponent<Member3>().stats.MP -= 20;
            }
            if (memberNumb == Member4)
            {
                agro4 = true;

                Member4.GetComponent<Member4>().stats.MP -= 20;
            }

            showAbilties = false;
            abilityButts[3].SetActive(false);
        }
        public void Sturdy()
        {

            if (memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.vit, (2 * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.vit);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.vit, (2 * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.vit);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.vit, (2 * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.vit);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.vit, (2 * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.vit);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[3].SetActive(false);
        }
        public void Smash()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 1.5f), ((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 2.5f));
                Member1.GetComponent<Member1>().stats.str -= (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.str));

                Member1.GetComponent<Member1>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member1.GetComponent<Member1>().stats.str);
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got lowered to " + Member1.GetComponent<Member1>().stats.str);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 1.5f), ((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 2.5f));
                Member2.GetComponent<Member2>().stats.str -= (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.str));

                Member2.GetComponent<Member2>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member2.GetComponent<Member2>().stats.str);
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got lowered to " + Member2.GetComponent<Member2>().stats.str);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 1.5f), ((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 2.5f));
                Member3.GetComponent<Member3>().stats.str -= (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.str));

                Member3.GetComponent<Member3>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member3.GetComponent<Member3>().stats.str);
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got lowered to " + Member3.GetComponent<Member3>().stats.str);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 1.5f), ((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 2.5f));
                Member4.GetComponent<Member4>().stats.str -= (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.str));

                Member4.GetComponent<Member4>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member4.GetComponent<Member4>().stats.str);
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got lowered to " + Member4.GetComponent<Member4>().stats.str);
            }
            showAbilties = false;
            abilityButts[3].SetActive(false);
        }
        #endregion

        #region Gambler
        int raise = 0;
        public void Draw()
        {
            int roll = Random.Range(1, 6);

            Debug.Log("roll: " + roll);

            #region rolls
            if (roll == 1 || roll == 2)
            {
                if (!Member1gone && memberNumb == Member1)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member1.GetComponent<Member1>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    manager.Announce(Member1.GetComponent<Member1>().tag + "'s Aim Stat, got raised to " + Member1.GetComponent<Member1>().stats.aim);
                }
                if (!Member2gone && memberNumb == Member2)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member2.GetComponent<Member2>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    manager.Announce(Member2.GetComponent<Member2>().tag + "'s Aim Stat, got raised to " + Member2.GetComponent<Member2>().stats.aim);
                }
                if (!Member3gone && memberNumb == Member3)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member3.GetComponent<Member3>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    manager.Announce(Member3.GetComponent<Member3>().tag + "'s Aim Stat, got raised to " + Member3.GetComponent<Member3>().stats.aim);
                }
                if (!Member4gone && memberNumb == Member4)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member4.GetComponent<Member4>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    manager.Announce(Member4.GetComponent<Member4>().tag + "'s Aim Stat, got raised to " + Member4.GetComponent<Member4>().stats.aim);
                }
            }
            if (roll == 3)
            {
                if (!Member1gone && memberNumb == Member1)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise) * 5;
                }
                if (!Member2gone && memberNumb == Member2)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl)) + raise) * 5;
                }
                if (!Member3gone && memberNumb == Member3)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl)) + raise) * 5;
                }
                if (!Member4gone && memberNumb == Member4)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl)) + raise) * 5;
                }
            }
            if (roll == 4)
            {
                if (!Member1gone && memberNumb == Member1)
                {
                    Member1.GetComponent<Member1>().stats.str += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
                }
                if (!Member2gone && memberNumb == Member2)
                {
                    Member2.GetComponent<Member2>().stats.str += (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl)) + raise;
                    manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
                }
                if (!Member3gone && memberNumb == Member3)
                {
                    Member3.GetComponent<Member3>().stats.str += (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl)) + raise;
                    manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str);
                }
                if (!Member4gone && memberNumb == Member4)
                {
                    Member4.GetComponent<Member4>().stats.str += (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl)) + raise;
                    manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
                }
            }
            if (roll == 5)
            {
                MassHeal();
            }
            if (roll == 6)
            {
                if (!Member1gone && memberNumb == Member1)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.lck), ((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.lck * 3.5f));
                    Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member1.GetComponent<Member1>().stats.lck);
                    Member1.GetComponent<Member1>().stats.lck += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    manager.Announce(Member1.GetComponent<Member1>().tag + "'s Luck Stat, got raised to " + Member1.GetComponent<Member1>().stats.lck);
                }
                if (!Member2gone && memberNumb == Member2)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.lck), ((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.lck * 3.5f));
                    Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member2.GetComponent<Member2>().stats.lck);
                    Member2.GetComponent<Member2>().stats.lck += (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl)) + raise;
                    manager.Announce(Member2.GetComponent<Member2>().tag + "'s Luck Stat, got raised to " + Member2.GetComponent<Member2>().stats.lck);
                }
                if (!Member3gone && memberNumb == Member3)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.lck), ((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.lck * 3.5f));
                    Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member3.GetComponent<Member3>().stats.lck);
                    Member3.GetComponent<Member3>().stats.lck += (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl)) + raise;
                    manager.Announce(Member3.GetComponent<Member3>().tag + "'s Luck Stat, got raised to " + Member3.GetComponent<Member3>().stats.lck);
                }
                if (!Member4gone && memberNumb == Member4)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 2f) * (int)(Member4.GetComponent<Member4>().stats.lck), ((int)Member4.GetComponent<Member4>().stats.str * 2f) * (int)(Member4.GetComponent<Member4>().stats.lck * 3.5f));
                    Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member4.GetComponent<Member4>().stats.lck);
                    Member4.GetComponent<Member4>().stats.lck += (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl)) + raise;
                    manager.Announce(Member4.GetComponent<Member4>().tag + "'s Luck Stat, got raised to " + Member4.GetComponent<Member4>().stats.lck);
                }
            }
            #endregion

            if (!Member1gone && memberNumb == Member1)
            {

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            Debug.Log("raise: " + raise);

            showAbilties = false;
            abilityButts[4].SetActive(false);
        }
        public void Raise()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.lck) - 1, Mathf.Sqrt(Member1.GetComponent<Member1>().stats.lck) + Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl));
                Member1.GetComponent<Member1>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member1.GetComponent<Member1>().stats.lck);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.lck) - 1, Mathf.Sqrt(Member2.GetComponent<Member2>().stats.lck) + Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl));
                Member2.GetComponent<Member2>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member2.GetComponent<Member2>().stats.lck);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.lck) - 1, Mathf.Sqrt(Member3.GetComponent<Member3>().stats.lck) + Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl));
                Member3.GetComponent<Member3>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member3.GetComponent<Member3>().stats.lck);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.lck) - 1, Mathf.Sqrt(Member4.GetComponent<Member4>().stats.lck) + Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl));
                Member4.GetComponent<Member4>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member4.GetComponent<Member4>().stats.lck);
            }

            Debug.Log("raise: " + raise);

            showAbilties = false;
            abilityButts[4].SetActive(false);
        }
        public void Fold()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(2 * raise, raise * Member1.GetComponent<Member1>().stats.lck);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(2 * raise, raise * Member2.GetComponent<Member2>().stats.lck);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(2 * raise, raise * Member3.GetComponent<Member3>().stats.lck);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(2 * raise, raise * Member4.GetComponent<Member4>().stats.lck);
            }

            raise = 0;
            Debug.Log("raise: " + raise);

            showAbilties = false;
            abilityButts[4].SetActive(false);
        }
        public void AllIn()
        {
            Enemy.GetComponent<EnemyClass>().stats.HP -= raise * Member4.GetComponent<Member4>().stats.lck * 5;

            raise = 0;
            Debug.Log("raise: " + raise);

            showAbilties = false;
            abilityButts[4].SetActive(false);
        }
        #endregion

        #region Undead
        public void BadBreath()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().poisoned = true;

                Member1.GetComponent<Member1>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().poisoned = true;

                Member2.GetComponent<Member2>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().poisoned = true;

                Member3.GetComponent<Member3>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);

            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().poisoned = true;

                Member4.GetComponent<Member4>().stats.MP -= 15;
                Debug.Log("poison: " + Enemy.GetComponent<EnemyClass>().poisoned);
            }
            showAbilties = false;
            abilityButts[5].SetActive(false);
        }
        public void Decay()
        {
            if (Enemy.GetComponent<EnemyClass>().poisoned)
            {
                Enemy.GetComponent<EnemyClass>().decay = true;
            }

            showAbilties = false;
            abilityButts[5].SetActive(false);
        }
        public void Preserve()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (2 * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (2 * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (2 * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (2 * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[5].SetActive(false);
        }
        public void Bite()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.str, (int)Member1.GetComponent<Member1>().stats.str * 1.5f);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.str, (int)Member2.GetComponent<Member2>().stats.str * 1.5f);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.str, (int)Member3.GetComponent<Member3>().stats.str * 1.5f);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.str, (int)Member4.GetComponent<Member4>().stats.str * 1.5f);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[5].SetActive(false);
        }
        #endregion

        #region WM
        public void Cure()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (2 * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (2 * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (2 * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (2 * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }
            showAbilties = false;
            abilityButts[6].SetActive(false);
        }
        public void Absorb()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang, ((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang) * 1.5f);
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai, ((int)Member1.GetComponent<Member1>().stats.fai) * 1.5f);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang, ((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang) * 1.5f);
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai, ((int)Member2.GetComponent<Member2>().stats.fai) * 1.5f);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang, ((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang) * 1.5f);
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai, ((int)Member3.GetComponent<Member3>().stats.fai) * 1.5f);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.fai * (int)Member4.GetComponent<Member4>().stats.ang, ((int)Member4.GetComponent<Member4>().stats.fai * (int)Member4.GetComponent<Member4>().stats.ang) * 1.5f);
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range((int)Member4.GetComponent<Member4>().stats.fai, ((int)Member4.GetComponent<Member4>().stats.fai) * 1.5f);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }
            showAbilties = false;
            abilityButts[6].SetActive(false);
        }
        public void MassHeal()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                if (!Member2gone)
                    Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (1.5f * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);
                if (!Member3gone)
                    Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (1.5f * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);
                if (!Member4gone)
                    Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (1.5f * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                if (!Member1gone)
                   Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (1.5f * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);
                if (!Member3gone)
                    Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (1.5f * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);
                if (!Member4gone)
                    Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (1.5f * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                if (!Member1gone)
                    Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (1.5f * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);
                if (!Member2gone) 
                    Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (1.5f * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);
                if (!Member4gone)
                    Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (1.5f * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                if (!Member1gone)
                    Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (1.5f * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);
                if (!Member2gone)
                    Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (1.5f * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);
                if (!Member3gone)
                    Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (1.5f * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);


                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[6].SetActive(false);
        }
        public void SelfSacrifice()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                //
                if (!Member2gone)
                    Member2.GetComponent<Member2>().stats.HP += Member1.GetComponent<Member1>().stats.HP;
                if (!Member3gone)
                    Member3.GetComponent<Member3>().stats.HP += Member1.GetComponent<Member1>().stats.HP;
                if (!Member4gone)
                    Member4.GetComponent<Member4>().stats.HP += Member1.GetComponent<Member1>().stats.HP;


                Member1.GetComponent<Member1>().stats.HP -= Member1.GetComponent<Member1>().stats.HP;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                if (!Member1gone)
                    Member1.GetComponent<Member1>().stats.HP += Member2.GetComponent<Member2>().stats.HP;
                //
                if (!Member3gone)
                    Member3.GetComponent<Member3>().stats.HP += Member2.GetComponent<Member2>().stats.HP;
                if (!Member4gone)
                    Member4.GetComponent<Member4>().stats.HP += Member2.GetComponent<Member2>().stats.HP;


                Member2.GetComponent<Member2>().stats.HP -= Member2.GetComponent<Member2>().stats.HP;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                if (!Member1gone)
                    Member1.GetComponent<Member1>().stats.HP += Member3.GetComponent<Member3>().stats.HP;
                if (!Member2gone)
                    Member2.GetComponent<Member2>().stats.HP += Member3.GetComponent<Member3>().stats.HP;
                //
                if (!Member4gone)
                    Member4.GetComponent<Member4>().stats.HP += Member3.GetComponent<Member3>().stats.HP;


                Member3.GetComponent<Member3>().stats.HP -= Member3.GetComponent<Member3>().stats.HP;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                if (!Member1gone)
                    Member1.GetComponent<Member1>().stats.HP += Member4.GetComponent<Member4>().stats.HP;
                if (!Member1gone)
                    Member2.GetComponent<Member2>().stats.HP += Member4.GetComponent<Member4>().stats.HP;
                if (!Member3gone)
                    Member3.GetComponent<Member3>().stats.HP += Member4.GetComponent<Member4>().stats.HP;
                //


                Member4.GetComponent<Member4>().stats.HP -= Member4.GetComponent<Member4>().stats.HP;
            }
            showAbilties = false;
            abilityButts[6].SetActive(false);
        }
        #endregion

        #region RMs
        public void RedCure()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (2 * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (2 * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (2 * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (2 * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }
            showAbilties = false;
            abilityButts[7].SetActive(false);
        }
        public void RedAbsorb()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang, ((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang) * 1.5f);
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai, ((int)Member1.GetComponent<Member1>().stats.fai) * 1.5f);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang, ((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang) * 1.5f);
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai, ((int)Member2.GetComponent<Member2>().stats.fai) * 1.5f);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang, ((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang) * 1.5f);
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai, ((int)Member3.GetComponent<Member3>().stats.fai) * 1.5f);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.fai * (int)Member4.GetComponent<Member4>().stats.ang, ((int)Member4.GetComponent<Member4>().stats.fai * (int)Member4.GetComponent<Member4>().stats.ang) * 1.5f);
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range((int)Member4.GetComponent<Member4>().stats.fai, ((int)Member4.GetComponent<Member4>().stats.fai) * 1.5f);

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[7].SetActive(false);
        }
        public void RedFireblast()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl, (int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 2);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 20;
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl, (int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 2);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 20;
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl, (int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 2);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 20;
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl, (int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 2);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 20;
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
            }

            showAbilties = false;
            abilityButts[7].SetActive(false);
        }
        public void RedGravity()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 5, (int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 8);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 50;
                manager.Announce(Member1.GetComponent<Member1>().tag + "'s Strength Stat, got raised to " + Member1.GetComponent<Member1>().stats.str);
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 5, (int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 8);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 50;
                manager.Announce(Member2.GetComponent<Member2>().tag + "'s Strength Stat, got raised to " + Member2.GetComponent<Member2>().stats.str);
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 5, (int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 8);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 50;
                manager.Announce(Member3.GetComponent<Member3>().tag + "'s Strength Stat, got raised to " + Member3.GetComponent<Member3>().stats.str);
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 5, (int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 8);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 50;
                manager.Announce(Member4.GetComponent<Member4>().tag + "'s Strength Stat, got raised to " + Member4.GetComponent<Member4>().stats.str);
            }
            showAbilties = false;
            abilityButts[7].SetActive(false);
        }
        #endregion

        #region BM
        public void Shock()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang, (int)Member1.GetComponent<Member1>().stats.ang * 1.5f);

                Member1.GetComponent<Member1>().stats.MP -= 5;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang, (int)Member2.GetComponent<Member2>().stats.ang * 1.5f);

                Member2.GetComponent<Member2>().stats.MP -= 5;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang, (int)Member3.GetComponent<Member3>().stats.ang * 1.5f);

                Member3.GetComponent<Member3>().stats.MP -= 5;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang, (int)Member4.GetComponent<Member4>().stats.ang * 1.5f);

                Member4.GetComponent<Member4>().stats.MP -= 5;
            }

            Enemy.GetComponent<EnemyClass>().paralized = true;

            showAbilties = false;
            abilityButts[8].SetActive(false);
        }
        public void IceBeam()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl, (int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 2);


                Member1.GetComponent<Member1>().stats.MP -= 15;
        
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl, (int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 2);


                Member2.GetComponent<Member2>().stats.MP -= 15;
       
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl, (int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 2);


                Member3.GetComponent<Member3>().stats.MP -= 15;
 
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl, (int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 2);


                Member4.GetComponent<Member4>().stats.MP -= 15;

            }

            showAbilties = false;
            abilityButts[8].SetActive(false);
        }
        public void Earthquake()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)(Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 2.5f), (int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 5);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 30;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)(Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 2.5f), (int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 5);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 30;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)(Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 2.5f), (int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 5);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 30;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)(Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 2.5f), (int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 5);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 30;
            }

            showAbilties = false;
            abilityButts[8].SetActive(false);
        }

        public void Gravity()
        {
            if (!Member1gone && memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 5, (int)Member1.GetComponent<Member1>().stats.ang * (int)Member1.GetComponent<Member1>().stats.skl * 8);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 50;
            }
            if (!Member2gone && memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 5, (int)Member2.GetComponent<Member2>().stats.ang * (int)Member2.GetComponent<Member2>().stats.skl * 8);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 50;
            }
            if (!Member3gone && memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 5, (int)Member3.GetComponent<Member3>().stats.ang * (int)Member3.GetComponent<Member3>().stats.skl * 8);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 50;
            }
            if (!Member4gone && memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 5, (int)Member4.GetComponent<Member4>().stats.ang * (int)Member4.GetComponent<Member4>().stats.skl * 8);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 50;
            }
            showAbilties = false;
            abilityButts[8].SetActive(false);
        }

        #endregion
    }
}
