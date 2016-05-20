using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TeamSpigot
{
    public class BattleManager : MonoBehaviour
    {
        bool debugShit;

        #region playerTurnStuff
        public bool runAttack;
        public bool playerAttacked;
        bool callAttack;
        [HideInInspector]
        public bool statSet;

        public GameObject currentPlayer;
        public GameObject enemy;
        public int enemySpawn;

        public StatStruct playerStats;

        GameObject Member1;
        GameObject Member2;
        GameObject Member3;
        GameObject Member4;

        [HideInInspector]
        public float mem1Agl = 0;
        [HideInInspector]
        public float mem2Agl = 0;
        [HideInInspector]
        public float mem3Agl = 0;
        [HideInInspector]
        public float mem4Agl = 0;

        float mem1HP = 0;
        float mem2HP = 0;
        float mem3HP = 0;
        float mem4HP = 0;

        float highestAgl;
        float highestHP;

        public int sortOrder = 1;

        float hitRoll;
        float critRoll;

        public List<float> agilities = new List<float>();
        List<float> playerHPs = new List<float>();

        public bool isCrit;
        public bool playerDead;
        public bool EnemyKilledCheck;
        bool mem1Stop;
        bool mem2Stop;
        bool mem3Stop;
        bool mem4Stop;

        bool mem1current;
        bool mem2current;
        bool mem3current;
        bool mem4current;
        #endregion

        #region enemyTurnStuff
        public StatStruct enemyStats;
        public float enmAgls = 0;
        public bool runEnemyAttack = false;
        bool enemyAttacked = false;
        
        public GameObject[] enemies;
        #endregion

        Animator anim1;
        Animator anim2;
        Animator anim3;
        Animator anim4;

        TextMesh mem1Healths;
        TextMesh mem2Healths;
        TextMesh mem3Healths;
        TextMesh mem4Healths;
        TextMesh enmHealths;

        TextMesh playerTurn;
        GameObject playerPointer;
        public GameObject attackButt;

        int WaitTime;

        void Start()
        {
            SpawnEnemy();

            debugShit = false;

            Member1 = GameObject.Find("Member1");
            Member2 = GameObject.Find("Member2");
            Member3 = GameObject.Find("Member3");
            Member4 = GameObject.Find("Member4");
            
            //Debug.Log("enemy: " + enemies[0].GetComponent<EnemyClass>().stats.agl);

            statSet = false;

            mem1Stop = false;
            mem2Stop = false;
            mem3Stop = false;
            mem4Stop = false;

            EnemyKilledCheck = false;

            #region objectSpeeds
            if (Member1 != null)
            {
                mem1Agl = Member1.GetComponent<Member1>().stats.agl + 0.04f;
                mem1HP = Member1.GetComponent<Member1>().stats.HP;
            }
            if (Member2 != null)
            {
                mem2Agl = Member2.GetComponent<Member2>().stats.agl + 0.03f;
                mem2HP = Member2.GetComponent<Member2>().stats.HP;
            }
            if (Member3 != null)
            {
                mem3Agl = Member3.GetComponent<Member3>().stats.agl + 0.02f;
                mem3HP = Member3.GetComponent<Member3>().stats.HP;
            }
            if (Member4 != null)
            {
                mem4Agl = Member4.GetComponent<Member4>().stats.agl + 0.01f;
                mem4HP = Member4.GetComponent<Member4>().stats.HP;
            }

            #endregion //objectSpeeds

            mem1Healths = GameObject.Find("mem1P").GetComponent<TextMesh>();
            mem2Healths = GameObject.Find("mem2P").GetComponent<TextMesh>();
            mem3Healths = GameObject.Find("mem3P").GetComponent<TextMesh>();
            mem4Healths = GameObject.Find("mem4P").GetComponent<TextMesh>();
            enmHealths = GameObject.Find("enemyHP").GetComponent<TextMesh>();

            playerTurn = GameObject.Find("Player Turn").GetComponent<TextMesh>();
            playerPointer = GameObject.Find("currentPlayer");
        }

        void Update()
        {
            Wait();
            DeadCheck();
            DeadChangeOrder();
            TurnOrder();
            HandleVisuals();
        }
        
        void SpawnEnemy ()
        {
            enemySpawn = UnityEngine.Random.Range(1, 1);

            for (int i = 0; i < enemySpawn; i++)
            {
                Instantiate(enemy, new Vector3(i * 2.0f - 6, 0, 0), Quaternion.identity);
            }
            enemies = GameObject.FindGameObjectsWithTag("ENEMY");
        }

        void Wait()
        {
            if (!playerAttacked)
            {
                WaitTime++;
            }

            if (WaitTime == 70)
            {
                attackButt.SetActive(true);
            }
            if (WaitTime < 70)
            {
                attackButt.SetActive(false);
            }
        }

        void DeadCheck()
        {

            playerHPs.Sort(delegate (float a, float b)
            {
                return (a).CompareTo(b);
            });

            #region mem1
            if (Member1.GetComponent<Member1>().mem1Dead && !mem1Stop)
            {
                agilities.Remove(mem1Agl);
                playerDead = true;
                mem1Stop = true;
            }
            #endregion

            #region mem2
            if (Member2.GetComponent<Member2>().mem2Dead && !mem2Stop)
            {
                agilities.Remove(mem2Agl);
                playerDead = true;
                mem2Stop = true;
            }
            #endregion

            #region mem3
            if (Member3.GetComponent<Member3>().mem3Dead && !mem3Stop)
            {
                agilities.Remove(mem3Agl);
                playerDead = true;
                mem3Stop = true;
            }
            #endregion

            #region mem4
            if (Member4.GetComponent<Member4>().mem4Dead && !mem4Stop)
            {
                agilities.Remove(mem4Agl);
                playerDead = true;
                mem4Stop = true;
            }
            #endregion

        }

        void DeadChangeOrder()
        {
            if (playerDead)
            {
                if (!EnemyKilledCheck)
                {
                    sortOrder -= 1;
                    playerDead = false;
                }
                if (EnemyKilledCheck)
                {
                    sortOrder -= 0;
                    playerDead = false;
                    EnemyKilledCheck = false;
                }
            }
        }

        void TurnOrder()
        {
            if (!statSet)
            {
                //Debug.Log("enemySpeeeeeed: " + enmAgls);
                //Debug.Log("ActualEnemySpeeeeeeed: " + enemies[0].GetComponent<EnemyClass>().stats.agl);

                agilities.Clear();

                agilities.Add(mem1Agl);
                agilities.Add(mem2Agl);
                agilities.Add(mem3Agl);
                agilities.Add(mem4Agl);
                agilities.Add(enmAgls);

                playerHPs.Add(mem1HP);
                playerHPs.Add(mem2HP);
                playerHPs.Add(mem3HP);
                playerHPs.Add(mem4HP);

                anim1 = Member1.GetComponent<Animator>();
                anim2 = Member2.GetComponent<Animator>();
                anim3 = Member3.GetComponent<Animator>();
                anim4 = Member4.GetComponent<Animator>();

                Debugs();

                agilities.Sort(delegate (float a, float b)
                {
                    return (a).CompareTo(b);
                });

                playerHPs.Sort(delegate (float a, float b)
                {
                    return (a).CompareTo(b);
                });

                Debugs();

                statSet = true;
            }

            #region playOrder

            highestAgl = agilities[agilities.Count - sortOrder];
            //highestHP = playerHPs[playerHPs.Count - sortOrder];


            #region mem1
            if (highestAgl == mem1Agl)
            {
                currentPlayer = Member1;
                playerStats = currentPlayer.GetComponent<Member1>().stats;
            }
            #endregion

            #region mem2
            if (highestAgl == mem2Agl)
            {
                currentPlayer = Member2;
                playerStats = currentPlayer.GetComponent<Member2>().stats;
            }
            #endregion

            #region mem3
            if (highestAgl == mem3Agl)
            {
                currentPlayer = Member3;
                playerStats = currentPlayer.GetComponent<Member3>().stats;
            }
            #endregion

            #region mem4
            if (highestAgl == mem4Agl)
            {
                currentPlayer = Member4;
                playerStats = currentPlayer.GetComponent<Member4>().stats;
            }
            #endregion

            #region enemy
            if (highestAgl == enmAgls)
            {
                enemyAttacked = true;
                enemyStats = enemies[0].GetComponent<EnemyClass>().stats;
            }
            #endregion

            #endregion

            #region running the players animation
            if (highestAgl == mem1Agl)
            {
                mem1current = true;
                mem2current = false;
                mem3current = false;
                mem4current = false;
            }
            if (highestAgl == mem2Agl)
            {
                mem2current = true;
                mem1current = false;
                mem3current = false;
                mem4current = false;
            }
            if (highestAgl == mem3Agl)
            {
                mem3current = true;
                mem1current = false;
                mem2current = false;
                mem4current = false;
            }
            if (highestAgl == mem4Agl)
            {
                mem4current = true;
                mem1current = false;
                mem2current = false;
                mem3current = false;
            }

            anim1.SetBool("Mem1Current", mem1current);
            anim2.SetBool("Mem2Current", mem2current);
            anim3.SetBool("Mem3Current", mem3current);
            anim4.SetBool("Mem4Current", mem4current);
            #endregion

            if (callAttack)
            {
                PlayerAttack();
                callAttack = false;
            }
            if (enemyAttacked)
            {
                EnemyAttack();
                enemyAttacked = false;
            }
        }

        string tempString;

        public void Attack()
        {
            callAttack = true;
        }

        public void ChangeOrder()
        {
            if (sortOrder < agilities.Count)
            {
                sortOrder++;
            }
            else if (sortOrder >= agilities.Count)
            {
                sortOrder = 1;
            }
        }

        void PlayerAttack()
        {
            #region player attacked
            if (WaitTime >= 70)
            {
                hitRoll = UnityEngine.Random.Range(0, 1f + (float)(playerStats.aim / 10));
                critRoll = UnityEngine.Random.Range(0, 1f + (float)(playerStats.lck / 20));

                if (hitRoll >= 0.3)
                {
					runAttack = true;
					tempString = "Hit! ;3";

                    if (runAttack)
                    {
                        if (critRoll < 0.9)
                        {
                            Debug.Log(currentPlayer.tag + "\n str: " + playerStats.str);
                            enemies[0].GetComponent<EnemyClass>().stats.HP -= playerStats.str;

                            runAttack = false;
                            callAttack = false;
                            critRoll = 0;
                            WaitTime = 0;
                            if (sortOrder < agilities.Count)
                            {
                                sortOrder++;
                            }
                            else if (sortOrder >= agilities.Count)
                            {
                                sortOrder = 1;
                            }
                        }

                        if (critRoll >= 0.9)
                        {
                            Debug.Log(currentPlayer.tag + "\n str: " + playerStats.str);
                            enemies[0].GetComponent<EnemyClass>().stats.HP -= playerStats.str * 5;

                            runAttack = false;
                            callAttack = false;
                            critRoll = 0;
                            WaitTime = 0;
                            if (sortOrder < agilities.Count)
                            {
                                sortOrder++;
                            }
                            else if (sortOrder >= agilities.Count)
                            {
                                sortOrder = 1;
                            }
                        }
                    }
                }
                if (hitRoll < 0.3)
                {
					tempString = "Miss D:";
                    callAttack = false;
                    WaitTime = 0;
                    if (sortOrder < agilities.Count)
                    {
                        sortOrder++;
                    }
                    else if (sortOrder >= agilities.Count)
                    {
                        sortOrder = 1;
                    }
                }
            }
            #endregion
        }

        void EnemyAttack()
        {
            #region enemy attacked
            if (WaitTime >= 70)
            {
                hitRoll = UnityEngine.Random.Range(0, 1f + (float)(enemyStats.aim / 10));
                critRoll = UnityEngine.Random.Range(0, 1f + (float)(enemyStats.lck / 20));

                if (hitRoll >= 0.3)
                {
                    if (critRoll >= 0.9)
                    {
                        isCrit = true;
                        critRoll = 0;
                        enemyAttacked = false;
                        WaitTime = 0;

                        Member1.GetComponent<Member1>().stats.HP -= enemyStats.str * 2;

                        if (sortOrder < agilities.Count)
                        {
                            sortOrder++;
                        }
                        else if (sortOrder >= agilities.Count)
                        {
                            sortOrder = 1;
                        }
                    }
                    if (critRoll < 0.9)
                    {
                        isCrit = false;
                        critRoll = 0;
                        enemyAttacked = false;
                        WaitTime = 0;

                        Member1.GetComponent<Member1>().stats.HP -= enemyStats.str * 2;

                        if (sortOrder < agilities.Count)
                        {
                            sortOrder++;
                        }
                        else if (sortOrder >= agilities.Count)
                        {
                            sortOrder = 1;
                        }
                    }
                }
                if (hitRoll < 0.3)
                {
                    enemyAttacked = false;
                    tempString = "Miss :D";
                    WaitTime = 0;

                    if (sortOrder < agilities.Count)
                    {
                        sortOrder++;
                    }
                    else if (sortOrder >= agilities.Count)
                    {
                        sortOrder = 1;
                    }
                }
            }
            #endregion

        }

        void EndBattle()
        {
            if (enemyStats.HP <= 0)
            {

            }
        }

        void HandleVisuals()
        {
            mem1Healths.text = Member1.tag + "\nHP: " + Member1.GetComponent<Member1>().stats.HP + " / " + Member1.GetComponent<Member1>().stats.MaxHP + "\nMP: " + Member1.GetComponent<Member1>().stats.MP + " / " + Member1.GetComponent<Member1>().stats.MaxMP;
            mem2Healths.text = Member2.tag + "\nHP: " + Member2.GetComponent<Member2>().stats.HP + " / " + Member2.GetComponent<Member2>().stats.MaxHP + "\nMP: " + Member2.GetComponent<Member2>().stats.MP + " / " + Member2.GetComponent<Member2>().stats.MaxMP;
            mem3Healths.text = Member3.tag + "\nHP: " + Member3.GetComponent<Member3>().stats.HP + " / " + Member3.GetComponent<Member3>().stats.MaxHP + "\nMP: " + Member3.GetComponent<Member3>().stats.MP + " / " + Member3.GetComponent<Member3>().stats.MaxMP;
            mem4Healths.text = Member4.tag + "\nHP: " + Member4.GetComponent<Member4>().stats.HP + " / " + Member4.GetComponent<Member4>().stats.MaxHP + "\nMP: " + Member4.GetComponent<Member4>().stats.MP + " / " + Member4.GetComponent<Member4>().stats.MaxMP;
            enmHealths.text = enemies[0].tag + "\nHP: " + enemies[0].GetComponent<EnemyClass>().stats.HP + " / " + enemies[0].GetComponent<EnemyClass>().stats.MaxHP;

            if (statSet)
            {
                playerTurn.text = currentPlayer.tag + "'s Turn";
                playerPointer.transform.position = currentPlayer.transform.position + new Vector3(0.9f, 0, -2);
            }

            if (enemies[0].GetComponent<EnemyClass>().stats.HP <= 0)
            {
                //attackButt.SetActive(false);
            }
            else if (enemies[0].GetComponent<EnemyClass>().stats.HP > 0)
            {
                //attackButt.SetActive(true);
            }
        }

        void Debugs()
        {
            //Debug.Log(currentPlayer + " - " + currentPlayer.tag + ": " + playerStats.HP);
            //Debug.Log("playerDead: " + playerDead);
            //Debug.Log("agilities.Length: " + agilities.Length);
            //Debug.Log("sortOrder: " + sortOrder + "\n   CurrentPlayer: " + currentPlayer.tag);
            //Debug.Log("highestAgl: " + highestAgl);
            //Debug.Log(playerAttacked);
            //Debug.Log(currentPlayer);
            for (int i = 0; i < agilities.Count; i++)
            {
                Debug.Log("index: " + i + " | agil: " + agilities[i]);
            }
        }
    }
}
