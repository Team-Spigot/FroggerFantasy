﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace TeamSpigot
{
    public class BattleManager : MonoBehaviour
    {
        #region playerTurnStuff
        public bool runAttack = false;
        public bool playerAttacked = false;

        public GameObject currentPlayer;
        public GameObject enemy;
        public int enemySpawn;

        public StatStruct playerStats;

        GameObject Member1;
        GameObject Member2;
        GameObject Member3;
        GameObject Member4;

        float mem1Agl = 0;
        float mem2Agl = 0;
        float mem3Agl = 0;
        float mem4Agl = 0;

        public int sortOrder = 1;

        float hitRoll;
        float critRoll;
        float[] agilities;

        public bool isCrit;
        public bool playerDead;
        #endregion

        #region enemyTurnStuff
        public StatStruct enemyStats;
        float enmAgls = 0;
        public bool runEnemyAttack = false;
        bool enemyAttacked = false;

        public GameObject[] enemies;
        #endregion

        float time;

        void Start()
        {
            enemySpawn = UnityEngine.Random.Range(1, 1);

            for (int i = 0; i < enemySpawn; i++)
            {
                Instantiate(enemy, new Vector3(i * 2.0f - 6, 0, 0), Quaternion.identity);
            }

            Member1 = GameObject.Find("Member1");
            Member2 = GameObject.Find("Member2");
            Member3 = GameObject.Find("Member3");
            Member4 = GameObject.Find("Member4");
            //Warrior = GameObject.FindGameObjectWithTag("WARRIOR");
            //Ninja = GameObject.FindGameObjectWithTag("NINJA");
            //Monk = GameObject.FindGameObjectWithTag("MONK");
            //White_Mage = GameObject.FindGameObjectWithTag("WM");
            //Sentinel = GameObject.FindGameObjectWithTag("SENTINEL");
            //Gambler = GameObject.FindGameObjectWithTag("GAMBLER");

            enemies = GameObject.FindGameObjectsWithTag("ENEMY");
        }

        void Update()
        {
            TurnOrder();
            Battle();
            Debugs();
        }

        void TurnOrder()
        {
            #region playOrder

            #region objectSpeeds
            if (Member1 != null)
            {
                mem1Agl = Member1.GetComponent<Member1>().stats.agl + 0.04f;
            }
            if (Member2 != null)
            {
                mem2Agl = Member2.GetComponent<Member2>().stats.agl + 0.03f;
            }
            if (Member3 != null)
            {
                mem3Agl = Member3.GetComponent<Member3>().stats.agl + 0.02f;
            }
            if (Member4 != null)
            {
                mem4Agl = Member4.GetComponent<Member4>().stats.agl + 0.01f;
            }

            enmAgls = enemies[0].GetComponent<EnemyClass>().stats.agl;

            agilities = new float[] { mem1Agl, mem2Agl, mem3Agl, mem4Agl, enmAgls };
            Array.Sort(agilities);
            float highestAgl = agilities[agilities.Length - sortOrder];
            #endregion //objectSpeeds

            #region mem1
            if (highestAgl == mem1Agl)
            {
                currentPlayer = Member1;
                playerStats = currentPlayer.GetComponent<Member1>().stats;
                playerAttacked = currentPlayer.GetComponent<Member1>().attackCalled;
                playerDead = currentPlayer.GetComponent<Member1>().dead;
            }
            else if (highestAgl == mem1Agl && Member1 == null)
            {
                playerAttacked = false;
                if (sortOrder <= agilities.Length)
                {
                    sortOrder++;
                }
            }
            #endregion

            #region mem2
            if (highestAgl == mem2Agl)
            {
                currentPlayer = Member2;
                playerStats = currentPlayer.GetComponent<Member2>().stats;
                playerAttacked = currentPlayer.GetComponent<Member2>().attackCalled;
                playerDead = currentPlayer.GetComponent<Member2>().dead;
            }
            else if (highestAgl == mem2Agl && Member2 == null)
            {
                playerAttacked = false;
                if (sortOrder <= agilities.Length)
                {
                    sortOrder++;
                }
            }
            #endregion

            #region mem3
            if (highestAgl == mem3Agl)
            {
                currentPlayer = Member3;
                playerStats = currentPlayer.GetComponent<Member3>().stats;
                playerAttacked = currentPlayer.GetComponent<Member3>().attackCalled;
            }
            else if (highestAgl == mem3Agl && Member3 == null)
            {
                playerAttacked = false;
                if (sortOrder <= agilities.Length)
                {
                    sortOrder++;
                }
            }
            #endregion

            #region mem4
            if (highestAgl == mem4Agl)
            {
                currentPlayer = Member4;
                playerStats = currentPlayer.GetComponent<Member4>().stats;
                playerAttacked = currentPlayer.GetComponent<Member4>().attackCalled;
                playerDead = currentPlayer.GetComponent<Member4>().dead;
            }
            else if (highestAgl == mem4Agl && Member4 == null)
            {
                playerAttacked = false;
                if (sortOrder <= agilities.Length)
                {
                    sortOrder++;
                }
            }
            #endregion

            #region enemy
            if (highestAgl == enmAgls)
            {
                playerAttacked = false;
                enemyAttacked = true;
                enemyStats = enemies[0].GetComponent<EnemyClass>().stats;
            }
            #endregion

            if (playerStats.HP <= 0)
            {
                playerDead = true;
            }
            else
            {
                playerDead = false;
            }

            if (sortOrder > agilities.Length)
            {
                sortOrder = 1;
            }
            //Debug.Log("agilities.Length: " + agilities.Length);

            #endregion
        }

		string tempString;

        void Battle()
        {
            #region player attacked
            if (playerAttacked && !playerDead)
            {
                hitRoll = UnityEngine.Random.Range(0, 1f + (float)(playerStats.aim / 10));
                critRoll = UnityEngine.Random.Range(0, 1f + (float)(playerStats.lck / 20));

                if (hitRoll >= 0.3)
                {
					runAttack = true;
					tempString = "";

                    if (sortOrder < agilities.Length)
                    {
                        sortOrder++;
                    }
                    else if (sortOrder == agilities.Length)
                    {
                        sortOrder = 1;
                    }
                    //Debug.Log("order: " + sortOrder);

                    if (critRoll >= 0.9)
                    {
                        isCrit = true;
                        critRoll = 0;
                    }
                }
                if (hitRoll < 0.3)
                {
					tempString = "Miss D:";

                    if (sortOrder < agilities.Length)
                    {
                        sortOrder++;
                    }
                    else if (sortOrder == agilities.Length)
                    {
                        sortOrder = 1;
                    }
                    //Debug.Log("order: " + sortOrder);
                }
            }
            else if (playerAttacked && playerDead)
            {
                if (sortOrder < agilities.Length)
                {
                    sortOrder++;
                }
                else if (sortOrder == agilities.Length)
                {
                    sortOrder = 1;
                }
                playerAttacked = false;
                playerDead = false;
            }
            #endregion

            #region enemy attacked
            if (enemyAttacked)
            {
                hitRoll = UnityEngine.Random.Range(0, 1f + (float)(enemyStats.aim / 10));
                critRoll = UnityEngine.Random.Range(0, 1f + (float)(enemyStats.lck / 20));

                if (hitRoll >= 0.3)
                {
                    runEnemyAttack = true;
                    enemyAttacked = false;

                    if (sortOrder < agilities.Length)
                    {
                        sortOrder++;
                    }
                    else if (sortOrder == agilities.Length)
                    {
                        sortOrder = 1;
                    }
                    //Debug.Log("order: " + sortOrder);

                    if (critRoll >= 0.9)
                    {
                        isCrit = true;
                        critRoll = 0;
                    }
                }
                if (hitRoll < 0.3)
                {
                    enemyAttacked = false;
					tempString = "Miss :D";


                    if (sortOrder < agilities.Length)
                    {
                        sortOrder++;
                    }
                    else if (sortOrder == agilities.Length)
                    {
                        sortOrder = 1;
                    }
                    //Debug.Log("order: " + sortOrder);
                }
            }
            #endregion
        }

        void Debugs()
        {
            //Debug.Log(currentPlayer + " - " + currentPlayer.tag + ": " + playerStats.HP);
            //Debug.Log("playerDead: " + playerDead);
            //Debug.Log("agilities.Length: " + agilities.Length);
            //Debug.Log("sortOrder: " + sortOrder);
            //Debug.Log("highestAgl: " + highestAgl);
            //Debug.Log(playerAttacked);
            //Debug.Log(currentPlayer);
        }

		void OnGUI()
		{
			GUI.Window(0, new Rect(new Vector2(0, 0), new Vector2(480, 240)), DebugWindow, "DebugWindow");
		}

		void DebugWindow(int windowID)
		{
			GUI.TextField(new Rect(new Vector2(0, 24), new Vector2(480, 24)), "Player: " + currentPlayer.tag + " - " + currentPlayer);
			GUI.TextField(new Rect(new Vector2(0, 48), new Vector2(480, 24)), "HITROLL: " + hitRoll);
			GUI.TextField(new Rect(new Vector2(0, 72), new Vector2(480, 24)), "CRITROLL: " + critRoll);
			GUI.TextField(new Rect(new Vector2(0, 96), new Vector2(480, 24)), "Enemy: " + enemy);
			GUI.TextField(new Rect(new Vector2(0, 120), new Vector2(480, 24)), "CurrentTurnStatus: " + tempString);
		}
    }
}