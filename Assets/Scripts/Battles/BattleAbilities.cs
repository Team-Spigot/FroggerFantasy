﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TeamSpigot
{
    public class BattleAbilities : MonoBehaviour
    {
        string memberTag;
        GameObject memberNumb;
        StatStruct memberStats;
        bool showAbilties;
        public GameObject[] abilityButts;

        GameObject Member1;
        GameObject Member2;
        GameObject Member3;
        GameObject Member4;
        public GameObject manager;

        GameObject Enemy;

        void Start()
        {
            Member1 = GameObject.Find("Member1");
            Member2 = GameObject.Find("Member2");
            Member3 = GameObject.Find("Member3");
            Member4 = GameObject.Find("Member4");
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
            memberStats = GetComponent<BattleManager>().playerStats;
        }

        void TagCheck()
        {
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

        #region Warrior
        public void Ravage()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.str / 2.5f, (int)Member1.GetComponent<Member1>().stats.str / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.str / 2.5f, (int)Member2.GetComponent<Member2>().stats.str / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.str / 2.5f, (int)Member3.GetComponent<Member3>().stats.str / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
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
            abilityButts[0].SetActive(false);
        }
        public void Parry()
        {
            showAbilties = false;
            abilityButts[0].SetActive(false);
        }
        public void BurstBlade()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.skl), ((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.skl * 3.5f));
                Member1.GetComponent<Member1>().stats.HP -= (int)Random.Range(10, 20);

                Member1.GetComponent<Member1>().stats.MP -= 100;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.skl), ((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.skl * 3.5f));
                Member2.GetComponent<Member2>().stats.HP -= (int)Random.Range(10, 20);

                Member2.GetComponent<Member2>().stats.MP -= 100;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.skl), ((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.skl * 3.5f));
                Member3.GetComponent<Member3>().stats.HP -= (int)Random.Range(10, 20);

                Member3.GetComponent<Member3>().stats.MP -= 100;
            }
            if (memberNumb == Member4)
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
            if (memberNumb == Member1)
            {
                manager.GetComponent<BattleManager>().mem1Agl += Member1.GetComponent<Member1>().stats.skl;
                Member1.GetComponent<Member1>().stats.aim += Member1.GetComponent<Member1>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member1.GetComponent<Member1>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member1.GetComponent<Member1>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem1Agl);
                Debug.Log("memberStats.aim: " + Member1.GetComponent<Member1>().stats.aim);
            }
            if (memberNumb == Member2)
            {
                manager.GetComponent<BattleManager>().mem2Agl += Member2.GetComponent<Member2>().stats.skl;
                Member2.GetComponent<Member2>().stats.aim += Member2.GetComponent<Member2>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member2.GetComponent<Member2>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member2.GetComponent<Member2>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem2Agl);
                Debug.Log("memberStats.aim: " + Member2.GetComponent<Member2>().stats.aim);
            }
            if (memberNumb == Member3)
            {
                manager.GetComponent<BattleManager>().mem3Agl += Member3.GetComponent<Member3>().stats.skl;
                Member3.GetComponent<Member3>().stats.aim += Member3.GetComponent<Member3>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member3.GetComponent<Member3>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member3.GetComponent<Member3>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem3Agl);
                Debug.Log("memberStats.aim: " + Member3.GetComponent<Member3>().stats.aim);
            }
            if (memberNumb == Member4)
            {
                manager.GetComponent<BattleManager>().mem4Agl += Member4.GetComponent<Member4>().stats.skl;
                Member4.GetComponent<Member4>().stats.aim += Member4.GetComponent<Member4>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member4.GetComponent<Member4>().stats.MP -= 15;

                Debug.Log("memberStats.skl: " + Member4.GetComponent<Member4>().stats.skl);
                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem4Agl);
                Debug.Log("memberStats.aim: " + Member4.GetComponent<Member4>().stats.aim);
            }
            showAbilties = false;
            abilityButts[1].SetActive(false);
        }

        public void Substitute()
        {

            showAbilties = false;
            abilityButts[1].SetActive(false);
        }

        public void PoisonBlade()
        {

            showAbilties = false;
            abilityButts[1].SetActive(false);
        }

        public void Sharpen()
        {
            if (memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
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
            if (memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member1.GetComponent<Member1>().stats.str);
            }
            if (memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member2.GetComponent<Member2>().stats.str);
            }
            if (memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member3.GetComponent<Member3>().stats.str);
            }
            if (memberNumb == Member4)
            {
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member4.GetComponent<Member4>().stats.str);
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }

        public void FocusPunch()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.str / 2.5f, (int)Member1.GetComponent<Member1>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem1Agl += Member1.GetComponent<Member1>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member1.GetComponent<Member1>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem1Agl);
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.str / 2.5f, (int)Member2.GetComponent<Member2>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem2Agl += Member2.GetComponent<Member2>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member2.GetComponent<Member2>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem2Agl);
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.str / 2.5f, (int)Member3.GetComponent<Member3>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem3Agl += Member3.GetComponent<Member3>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member3.GetComponent<Member3>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem3Agl);
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.str / 2.5f, (int)Member4.GetComponent<Member4>().stats.str / 1.5f);
                manager.GetComponent<BattleManager>().mem4Agl += Member4.GetComponent<Member4>().stats.skl;
                manager.GetComponent<BattleManager>().statSet = false;

                Member4.GetComponent<Member4>().stats.MP -= 30;

                Debug.Log("memberStats.agl: " + manager.GetComponent<BattleManager>().mem4Agl);
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }

        public void Counter()
        {

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
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 1.5f), ((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 2.5f));
                Member2.GetComponent<Member2>().stats.HP -= (int)Random.Range(15, 20);
                Member2.GetComponent<Member2>().stats.str -= (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.str));

                Debug.Log("memberStats.str: " + Member2.GetComponent<Member2>().stats.str);
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 1.5f), ((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 2.5f));
                Member3.GetComponent<Member3>().stats.HP -= (int)Random.Range(15, 20);
                Member3.GetComponent<Member3>().stats.str -= (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.str));

                Debug.Log("memberStats.str: " + Member3.GetComponent<Member3>().stats.str);
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 1.5f), ((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 2.5f));
                Member4.GetComponent<Member4>().stats.HP -= (int)Random.Range(15, 20);
                Member4.GetComponent<Member4>().stats.str -= (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.str));

                Debug.Log("memberStats.str: " + Member4.GetComponent<Member4>().stats.str);
            }
            showAbilties = false;
            abilityButts[2].SetActive(false);
        }

        #endregion

        #region Sentinel

        public void Protect()
        {
            showAbilties = false;
            abilityButts[3].SetActive(false);
        }

        public void Agro()
        {
            showAbilties = false;
            abilityButts[3].SetActive(false);
        }

        public void Sturdy()
        {

            showAbilties = false;
            abilityButts[3].SetActive(false);
        }

        public void Smash()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 1.5f), ((int)Member1.GetComponent<Member1>().stats.str * 1.5f) * (int)(Member1.GetComponent<Member1>().stats.skl * 2.5f));
                Member1.GetComponent<Member1>().stats.str -= (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.str));

                Member1.GetComponent<Member1>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member1.GetComponent<Member1>().stats.str);
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 1.5f), ((int)Member2.GetComponent<Member2>().stats.str * 1.5f) * (int)(Member2.GetComponent<Member2>().stats.skl * 2.5f));
                Member2.GetComponent<Member2>().stats.str -= (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.str));

                Member2.GetComponent<Member2>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member2.GetComponent<Member2>().stats.str);
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 1.5f), ((int)Member3.GetComponent<Member3>().stats.str * 1.5f) * (int)(Member3.GetComponent<Member3>().stats.skl * 2.5f));
                Member3.GetComponent<Member3>().stats.str -= (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.str));

                Member3.GetComponent<Member3>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member3.GetComponent<Member3>().stats.str);
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 1.5f), ((int)Member4.GetComponent<Member4>().stats.str * 1.5f) * (int)(Member4.GetComponent<Member4>().stats.skl * 2.5f));
                Member4.GetComponent<Member4>().stats.str -= (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.str));

                Member4.GetComponent<Member4>().stats.MP -= 15;

                Debug.Log("memberStats.str: " + Member4.GetComponent<Member4>().stats.str);
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
                if (memberNumb == Member1)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member1.GetComponent<Member1>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                }
                if (memberNumb == Member2)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member2.GetComponent<Member2>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                }
                if (memberNumb == Member3)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member3.GetComponent<Member3>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                }
                if (memberNumb == Member4)
                {
                    Enemy.GetComponent<EnemyClass>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                    Member4.GetComponent<Member4>().stats.aim += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                }
            }
            if (roll == 3)
            {
                if (memberNumb == Member1)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise) * 5;
                }
                if (memberNumb == Member2)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl)) + raise) * 5;
                }
                if (memberNumb == Member3)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl)) + raise) * 5;
                }
                if (memberNumb == Member4)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= ((int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl)) + raise) * 5;
                }
            }
            if (roll == 4)
            {
                if (memberNumb == Member1)
                {
                    Member1.GetComponent<Member1>().stats.str += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                }
                if (memberNumb == Member2)
                {
                    Member2.GetComponent<Member2>().stats.str += (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl)) + raise;
                }
                if (memberNumb == Member3)
                {
                    Member3.GetComponent<Member3>().stats.str += (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl)) + raise;
                }
                if (memberNumb == Member4)
                {
                    Member4.GetComponent<Member4>().stats.str += (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl)) + raise;
                }
            }
            if (roll == 5)
            {
                MassHeal();
            }
            if (roll == 6)
            {
                if (memberNumb == Member1)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.lck), ((int)Member1.GetComponent<Member1>().stats.str * 2f) * (int)(Member1.GetComponent<Member1>().stats.lck * 3.5f));
                    Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member1.GetComponent<Member1>().stats.lck);
                    Member1.GetComponent<Member1>().stats.lck += (int)(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl)) + raise;
                }
                if (memberNumb == Member2)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.lck), ((int)Member2.GetComponent<Member2>().stats.str * 2f) * (int)(Member2.GetComponent<Member2>().stats.lck * 3.5f));
                    Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member2.GetComponent<Member2>().stats.lck);
                    Member2.GetComponent<Member2>().stats.lck += (int)(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl)) + raise;
                }
                if (memberNumb == Member3)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.lck), ((int)Member3.GetComponent<Member3>().stats.str * 2f) * (int)(Member3.GetComponent<Member3>().stats.lck * 3.5f));
                    Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member3.GetComponent<Member3>().stats.lck);
                    Member3.GetComponent<Member3>().stats.lck += (int)(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl)) + raise;
                }
                if (memberNumb == Member4)
                {
                    Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range(((int)Member4.GetComponent<Member4>().stats.str * 2f) * (int)(Member4.GetComponent<Member4>().stats.lck), ((int)Member4.GetComponent<Member4>().stats.str * 2f) * (int)(Member4.GetComponent<Member4>().stats.lck * 3.5f));
                    Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(5 * raise, 5 * raise * Member4.GetComponent<Member4>().stats.lck);
                    Member4.GetComponent<Member4>().stats.lck += (int)(Mathf.Sqrt(Member4.GetComponent<Member4>().stats.skl)) + raise;
                }
            }
            #endregion

            if (memberNumb == Member1)
            {

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            Debug.Log("raise: " + raise);

            showAbilties = false;
            abilityButts[4].SetActive(false);
        }

        public void Raise()
        {
            if (memberNumb == Member1)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member1.GetComponent<Member1>().stats.lck) - 1, Mathf.Sqrt(Member1.GetComponent<Member1>().stats.lck) + Mathf.Sqrt(Member1.GetComponent<Member1>().stats.skl));
                Member1.GetComponent<Member1>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member1.GetComponent<Member1>().stats.lck);
            }
            if (memberNumb == Member2)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member2.GetComponent<Member2>().stats.lck) - 1, Mathf.Sqrt(Member2.GetComponent<Member2>().stats.lck) + Mathf.Sqrt(Member2.GetComponent<Member2>().stats.skl));
                Member2.GetComponent<Member2>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member2.GetComponent<Member2>().stats.lck);
            }
            if (memberNumb == Member3)
            {
                raise += (int)Random.Range(Mathf.Sqrt(Member3.GetComponent<Member3>().stats.lck) - 1, Mathf.Sqrt(Member3.GetComponent<Member3>().stats.lck) + Mathf.Sqrt(Member3.GetComponent<Member3>().stats.skl));
                Member3.GetComponent<Member3>().stats.HP -= (int)Random.Range(5 * Mathf.Sqrt(raise), Mathf.Sqrt(raise) * Member3.GetComponent<Member3>().stats.lck);
            }
            if (memberNumb == Member4)
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
            if (memberNumb == Member1)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(2 * raise, raise * Member1.GetComponent<Member1>().stats.lck);
            }
            if (memberNumb == Member2)
            {
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(2 * raise, raise * Member2.GetComponent<Member2>().stats.lck);
            }
            if (memberNumb == Member3)
            {
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(2 * raise, raise * Member3.GetComponent<Member3>().stats.lck);
            }
            if (memberNumb == Member4)
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
            showAbilties = false;
            abilityButts[5].SetActive(false);
        }

        public void Decay()
        {
            showAbilties = false;
            abilityButts[5].SetActive(false);
        }

        public void Preserve()
        {

            showAbilties = false;
            abilityButts[5].SetActive(false);
        }

        public void Bite()
        {
            showAbilties = false;
            abilityButts[5].SetActive(false);
        }

        #endregion

        #region WM

        public void Cure()
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
            abilityButts[6].SetActive(false);
        }

        public void Absorb()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang, ((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang) * 1.5f);
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai, ((int)Member1.GetComponent<Member1>().stats.fai) * 1.5f);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang, ((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang) * 1.5f);
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai, ((int)Member2.GetComponent<Member2>().stats.fai) * 1.5f);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang, ((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang) * 1.5f);
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai, ((int)Member3.GetComponent<Member3>().stats.fai) * 1.5f);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
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
            if (memberNumb == Member1)
            {

                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (1.5f * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (1.5f * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (1.5f * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (1.5f * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);

                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (1.5f * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);
                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (1.5f * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (1.5f * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (1.5f * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);

                Member4.GetComponent<Member4>().stats.HP += (int)Random.Range(Member4.GetComponent<Member4>().stats.skl * Member4.GetComponent<Member4>().stats.fai, (1.5f * Member4.GetComponent<Member4>().stats.skl) * Member4.GetComponent<Member4>().stats.fai);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range(Member1.GetComponent<Member1>().stats.skl * Member1.GetComponent<Member1>().stats.fai, (1.5f * Member1.GetComponent<Member1>().stats.skl) * Member1.GetComponent<Member1>().stats.fai);
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range(Member2.GetComponent<Member2>().stats.skl * Member2.GetComponent<Member2>().stats.fai, (1.5f * Member2.GetComponent<Member2>().stats.skl) * Member2.GetComponent<Member2>().stats.fai);
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range(Member3.GetComponent<Member3>().stats.skl * Member3.GetComponent<Member3>().stats.fai, (1.5f * Member3.GetComponent<Member3>().stats.skl) * Member3.GetComponent<Member3>().stats.fai);


                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[6].SetActive(false);
        }

        public void SelfSacrifice()
        {
            if (memberNumb == Member1)
            {
                //
                Member2.GetComponent<Member2>().stats.HP += Member1.GetComponent<Member1>().stats.HP;
                Member3.GetComponent<Member3>().stats.HP += Member1.GetComponent<Member1>().stats.HP;
                Member4.GetComponent<Member4>().stats.HP += Member1.GetComponent<Member1>().stats.HP;


                Member1.GetComponent<Member1>().stats.HP -= Member1.GetComponent<Member1>().stats.HP;
            }
            if (memberNumb == Member2)
            {
                Member1.GetComponent<Member1>().stats.HP += Member2.GetComponent<Member2>().stats.HP;
                //
                Member3.GetComponent<Member3>().stats.HP += Member2.GetComponent<Member2>().stats.HP;
                Member4.GetComponent<Member4>().stats.HP += Member2.GetComponent<Member2>().stats.HP;


                Member2.GetComponent<Member2>().stats.HP -= Member2.GetComponent<Member2>().stats.HP;
            }
            if (memberNumb == Member3)
            {
                Member1.GetComponent<Member1>().stats.HP += Member3.GetComponent<Member3>().stats.HP;
                Member2.GetComponent<Member2>().stats.HP += Member3.GetComponent<Member3>().stats.HP;
                //
                Member4.GetComponent<Member4>().stats.HP += Member3.GetComponent<Member3>().stats.HP;


                Member3.GetComponent<Member3>().stats.HP -= Member3.GetComponent<Member3>().stats.HP;
            }
            if (memberNumb == Member4)
            {
                Member1.GetComponent<Member1>().stats.HP += Member4.GetComponent<Member4>().stats.HP;
                Member2.GetComponent<Member2>().stats.HP += Member4.GetComponent<Member4>().stats.HP;
                Member3.GetComponent<Member3>().stats.HP += Member4.GetComponent<Member4>().stats.HP;
                //


                Member4.GetComponent<Member4>().stats.HP -= Member4.GetComponent<Member4>().stats.HP;
            }
            showAbilties = false;
            abilityButts[6].SetActive(false);
        }

        #endregion

        #region RM

        public void RedCure()
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
            abilityButts[7].SetActive(false);
        }

        public void RedAbsorb()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang, ((int)Member1.GetComponent<Member1>().stats.fai * (int)Member1.GetComponent<Member1>().stats.ang) * 1.5f);
                Member1.GetComponent<Member1>().stats.HP += (int)Random.Range((int)Member1.GetComponent<Member1>().stats.fai, ((int)Member1.GetComponent<Member1>().stats.fai) * 1.5f);

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang, ((int)Member2.GetComponent<Member2>().stats.fai * (int)Member2.GetComponent<Member2>().stats.ang) * 1.5f);
                Member2.GetComponent<Member2>().stats.HP += (int)Random.Range((int)Member2.GetComponent<Member2>().stats.fai, ((int)Member2.GetComponent<Member2>().stats.fai) * 1.5f);

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang, ((int)Member3.GetComponent<Member3>().stats.fai * (int)Member3.GetComponent<Member3>().stats.ang) * 1.5f);
                Member3.GetComponent<Member3>().stats.HP += (int)Random.Range((int)Member3.GetComponent<Member3>().stats.fai, ((int)Member3.GetComponent<Member3>().stats.fai) * 1.5f);

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
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
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang / 2.5f, (int)Member1.GetComponent<Member1>().stats.ang / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang / 2.5f, (int)Member2.GetComponent<Member2>().stats.ang / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang / 2.5f, (int)Member3.GetComponent<Member3>().stats.ang / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang / 2.5f, (int)Member4.GetComponent<Member4>().stats.ang / 1.5f);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[7].SetActive(false);
        }

        public void RedGravity()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang / 2.5f, (int)Member1.GetComponent<Member1>().stats.ang / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang / 2.5f, (int)Member2.GetComponent<Member2>().stats.ang / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang / 2.5f, (int)Member3.GetComponent<Member3>().stats.ang / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang / 2.5f, (int)Member4.GetComponent<Member4>().stats.ang / 1.5f);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }
            showAbilties = false;
            abilityButts[7].SetActive(false);
        }

        #endregion

        #region BM

        public void Shock()
        {
            showAbilties = false;
            abilityButts[8].SetActive(false);
        }

        public void IceBeam()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang / 2.5f, (int)Member1.GetComponent<Member1>().stats.ang / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang / 2.5f, (int)Member2.GetComponent<Member2>().stats.ang / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang / 2.5f, (int)Member3.GetComponent<Member3>().stats.ang / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang / 2.5f, (int)Member4.GetComponent<Member4>().stats.ang / 1.5f);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[8].SetActive(false);
        }

        public void Earthquake()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang / 2.5f, (int)Member1.GetComponent<Member1>().stats.ang / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang / 2.5f, (int)Member2.GetComponent<Member2>().stats.ang / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang / 2.5f, (int)Member3.GetComponent<Member3>().stats.ang / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang / 2.5f, (int)Member4.GetComponent<Member4>().stats.ang / 1.5f);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }

            showAbilties = false;
            abilityButts[8].SetActive(false);
        }

        public void Gravity()
        {
            if (memberNumb == Member1)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member1.GetComponent<Member1>().stats.ang / 2.5f, (int)Member1.GetComponent<Member1>().stats.ang / 1.5f);
                Member1.GetComponent<Member1>().stats.str += Member1.GetComponent<Member1>().stats.skl;

                Member1.GetComponent<Member1>().stats.MP -= 15;
            }
            if (memberNumb == Member2)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member2.GetComponent<Member2>().stats.ang / 2.5f, (int)Member2.GetComponent<Member2>().stats.ang / 1.5f);
                Member2.GetComponent<Member2>().stats.str += Member2.GetComponent<Member2>().stats.skl;

                Member2.GetComponent<Member2>().stats.MP -= 15;
            }
            if (memberNumb == Member3)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member3.GetComponent<Member3>().stats.ang / 2.5f, (int)Member3.GetComponent<Member3>().stats.ang / 1.5f);
                Member3.GetComponent<Member3>().stats.str += Member3.GetComponent<Member3>().stats.skl;

                Member3.GetComponent<Member3>().stats.MP -= 15;
            }
            if (memberNumb == Member4)
            {
                Enemy.GetComponent<EnemyClass>().stats.HP -= (int)Random.Range((int)Member4.GetComponent<Member4>().stats.ang / 2.5f, (int)Member4.GetComponent<Member4>().stats.ang / 1.5f);
                Member4.GetComponent<Member4>().stats.str += Member4.GetComponent<Member4>().stats.skl;

                Member4.GetComponent<Member4>().stats.MP -= 15;
            }
            showAbilties = false;
            abilityButts[8].SetActive(false);
        }

        #endregion


    }
}