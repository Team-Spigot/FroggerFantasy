using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TeamSpigot
{
    public class BattleManager : MonoBehaviour
    {
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

        public List<GameObject> enemies;
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

        GameObject announcePanel;
        Text announceText;

        TextMesh playerTurn;
        GameObject playerPointer;
        public GameObject attackButt;

        private GameManager _gm;
        private DropOff _do;
        private EnemyBattleManager _ebm;

        int WaitTime;

        public int attack;

        public bool Member1gone, Member2gone, Member3gone, Member4gone = false;

        void Awake()
        {
            _gm = GameManager.instance;
            _do = DropOff.instance;
            _ebm = EnemyBattleManager.instance;
        }

        void Start()
        {

            SpawnEnemy();

            if (_gm.PlayerStatusStruct.DeadPlayers[0] == false)
            {
                Member1 = GameObject.Find("Member1");
                Member1gone = false;
            }
            else
            {
                Member1 = GameObject.Find("Member1");
                Member1.SetActive(false);
                Member1gone = true;
            }
            if (_gm.PlayerStatusStruct.DeadPlayers[1] == false)
            {
                Member2 = GameObject.Find("Member2");
                Member2gone = false;
            }
            else
            {
                Member2 = GameObject.Find("Member2");
                Member2.SetActive(false);
                Member2gone = true;
            }
            if (_gm.PlayerStatusStruct.DeadPlayers[2] == false)
            {
                Member3 = GameObject.Find("Member3");
                Member3gone = false;
            }
            else
            {
                Member3 = GameObject.Find("Member3");
                Member3.SetActive(false);
                Member3gone = true;
            }
            if (_gm.PlayerStatusStruct.DeadPlayers[3] == false)
            {
                Member4 = GameObject.Find("Member4");
                Member4gone = false;
            }
            else
            {
                Member4 = GameObject.Find("Member4");
                Member4.SetActive(false);
                Member4gone = true;
            }

            mem1Healths = GameObject.Find("mem1P").GetComponent<TextMesh>();
            mem2Healths = GameObject.Find("mem2P").GetComponent<TextMesh>();
            mem3Healths = GameObject.Find("mem3P").GetComponent<TextMesh>();
            mem4Healths = GameObject.Find("mem4P").GetComponent<TextMesh>();
            enmHealths = GameObject.Find("enemyHP").GetComponent<TextMesh>();

            //Debug.Log("enemy: " + enemies[0].GetComponent<EnemyClass>().stats.agl);

            SetStats(false);

            mem1Stop = false;
            mem2Stop = false;
            mem3Stop = false;
            mem4Stop = false;

            EnemyKilledCheck = false;

            #region objectSpeeds
            if (!Member1gone)
            {
                mem1Agl = Member1.GetComponent<Member1>().stats.agl + 0.04f;
                mem1HP = Member1.GetComponent<Member1>().stats.HP;
            }
            else
            {
                mem1Agl = -1;
                mem1HP = -1;
            }
            if (!Member2gone)
            {
                mem2Agl = Member2.GetComponent<Member2>().stats.agl + 0.03f;
                mem2HP = Member2.GetComponent<Member2>().stats.HP;
            }
            else
            {
                mem2Agl = -1;
                mem2HP = -1;
            }
            if (!Member3gone)
            {
                mem3Agl = Member3.GetComponent<Member3>().stats.agl + 0.02f;
                mem3HP = Member3.GetComponent<Member3>().stats.HP;
            }
            else
            {
                mem3Agl = -1;
                mem3HP = -1;
            }
            if (!Member4gone)
            {
                mem4Agl = Member4.GetComponent<Member4>().stats.agl + 0.01f;
                mem4HP = Member4.GetComponent<Member4>().stats.HP;
            }
            else
            {
                mem4Agl = -1;
                mem4HP = -1;
            }

            #endregion //objectSpeeds

            announcePanel = GameObject.Find("AnnPanel");
            announceText = GameObject.Find("AnnText").GetComponent<Text>();
            announcePanel.SetActive(false);

            if (!Member1gone)
            {
                anim1 = Member1.GetComponent<Animator>();
            }
            if (!Member2gone)
            {
                anim2 = Member2.GetComponent<Animator>();
            }
            if (!Member3gone)
            {
                anim3 = Member3.GetComponent<Animator>();
            }
            if (!Member4gone)
            {
                anim4 = Member4.GetComponent<Animator>();
            }

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
            EndBattle();
        }

        void SpawnEnemy()
        {
            enemySpawn = UnityEngine.Random.Range(1, 1);

            for (int i = 0; i < enemySpawn; i++)
            {
                GameObject tempEnemy = (GameObject)Instantiate(enemy, new Vector3(i * 2.0f - 4, 1, -1), Quaternion.identity);
                enemies.Add(tempEnemy);
            }
        }

        void Wait()
        {
            if (!playerAttacked)
            {
                WaitTime++;
            }

            if (WaitTime == 70)
            {
                attackButt.GetComponent<Button>().interactable = true;
            }
            if (WaitTime < 70)
            {
                attackButt.GetComponent<Button>().interactable = false;
            }
        }

        void DeadCheck()
        {

            playerHPs.Sort(delegate (float a, float b)
            {
                return (a).CompareTo(b);
            });

            //Debug.Log("1: " + Member1.GetComponent<Member1>().stats.HP + " | 2: " + Member2.GetComponent<Member2>().stats.HP + " | 3: " + Member3.GetComponent<Member3>().stats.HP + " | 4: " + Member4.GetComponent<Member4>().stats.HP);

            #region mem1
            if (Member1.GetComponent<Member1>().stats.HP < 0 && !mem1Stop)
            {
                playerDead = true;
                mem1Stop = true;
                _gm.PlayerStatusStruct.DeadPlayers[0] = true;
                Member1gone = true;
                SetStats(true);
                Member1.SetActive(false);
            }
            #endregion

            #region mem2
            if (Member2.GetComponent<Member2>().stats.HP < 0 && !mem2Stop)
            {
                playerDead = true;
                mem2Stop = true;
                _gm.PlayerStatusStruct.DeadPlayers[1] = true;
                Member2gone = true;
                SetStats(true);
                Member2.SetActive(false);
            }
            #endregion

            #region mem3
            if (Member3.GetComponent<Member3>().stats.HP < 0 && !mem3Stop)
            {
                SetStats(true);
                playerDead = true;
                mem3Stop = true;
                _gm.PlayerStatusStruct.DeadPlayers[2] = true;
                Member3gone = true;
                SetStats(true);
                Member3.SetActive(false);
            }
            #endregion

            #region mem4
            if (Member4.GetComponent<Member4>().stats.HP < 0 && !mem4Stop)
            {
                SetStats(true);
                playerDead = true;
                mem4Stop = true;
                _gm.PlayerStatusStruct.DeadPlayers[3] = true;
                Member4gone = true;
                SetStats(true);
                Member4.SetActive(false);
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

        void SetStats(bool changeOrder)
        {
            //Debug.Log("enemySpeeeeeed: " + enmAgls);
            //Debug.Log("ActualEnemySpeeeeeeed: " + enemies[0].GetComponent<EnemyClass>().stats.agl);

            agilities.Clear();
            playerHPs.Clear();

            if (!Member1gone)
            {
                agilities.Add(mem1Agl);
                playerHPs.Add(mem1HP);
            }
            if (!Member2gone)
            {
                agilities.Add(mem2Agl);
                playerHPs.Add(mem2HP);
            }
            if (!Member3gone)
            {
                agilities.Add(mem3Agl);
                playerHPs.Add(mem3HP);
            }
            if (!Member4gone)
            {
                agilities.Add(mem4Agl);
                playerHPs.Add(mem4HP);
            }
            agilities.Add(enmAgls);

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

            if (changeOrder)
            {
                ChangeOrder();
            }
        }

        void TurnOrder()
        {
            if (!statSet)
            {
                SetStats(false);
                statSet = true;
            }

            #region playOrder

            highestAgl = agilities[agilities.Count - sortOrder];
            //highestHP = playerHPs[playerHPs.Count - sortOrder];


            #region mem1
            if (!Member1gone && highestAgl == mem1Agl)
            {
                currentPlayer = Member1;
                playerStats = currentPlayer.GetComponent<Member1>().stats;
            }
            #endregion

            #region mem2
            if (!Member2gone && highestAgl == mem2Agl)
            {
                currentPlayer = Member2;
                playerStats = currentPlayer.GetComponent<Member2>().stats;
            }
            #endregion

            #region mem3
            if (!Member3gone && highestAgl == mem3Agl)
            {
                currentPlayer = Member3;
                playerStats = currentPlayer.GetComponent<Member3>().stats;
            }
            #endregion

            #region mem4
            if (!Member4gone && highestAgl == mem4Agl)
            {
                currentPlayer = Member4;
                playerStats = currentPlayer.GetComponent<Member4>().stats;
            }
            #endregion

            #region enemy
            if (highestAgl == enmAgls)
            {
                currentPlayer = Member1;
                enemyAttacked = true;
                enemyStats = enemies[0].GetComponent<EnemyClass>().stats;
            }
            #endregion

            #endregion

            #region running the players animation
            if (!Member1gone && highestAgl == mem1Agl)
            {
                mem1current = true;
                mem2current = false;
                mem3current = false;
                mem4current = false;
            }
            if (!Member2gone && highestAgl == mem2Agl)
            {
                mem2current = true;
                mem1current = false;
                mem3current = false;
                mem4current = false;
            }
            if (!Member3gone && highestAgl == mem3Agl)
            {
                mem3current = true;
                mem1current = false;
                mem2current = false;
                mem4current = false;
            }
            if (!Member4gone && highestAgl == mem4Agl)
            {
                mem4current = true;
                mem1current = false;
                mem2current = false;
                mem3current = false;
            }

            if (!Member1gone)
            {
                anim1.SetBool("Attack", mem1current);
            }
            if (!Member2gone)
            {
                anim2.SetBool("Attack", mem2current);
            }
            if (!Member3gone)
            {
                anim3.SetBool("Attack", mem3current);
            }
            if (!Member4gone)
            {
                anim4.SetBool("Attack", mem4current);
            }
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
            else if (sortOrder >= agilities.Count || sortOrder <= 0)
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

                            ChangeOrder();
                        }

                        if (critRoll >= 0.9)
                        {
                            Debug.Log(currentPlayer.tag + "\n str: " + playerStats.str);
                            enemies[0].GetComponent<EnemyClass>().stats.HP -= playerStats.str * 5;

                            runAttack = false;
                            callAttack = false;
                            critRoll = 0;
                            WaitTime = 0;

                            ChangeOrder();
                        }
                    }
                }
                if (hitRoll < 0.3)
                {
                    callAttack = false;
                    WaitTime = 0;

                    ChangeOrder();
                }
            }
            #endregion
        }

        int decay;
        void EnemyAttack()
        {
            if (WaitTime >= 70)
            {
                if (enemies[0].GetComponent<EnemyClass>().poisoned)
                {
                    enemies[0].GetComponent<EnemyClass>().stats.HP -= 10;
                    Debug.Log("poison");
                }

                if (enemies[0].GetComponent<EnemyClass>().decay)
                {
                    enemies[0].GetComponent<EnemyClass>().stats.HP -= 5 * decay;
                    decay++;
                    Debug.Log("decay");
                }
            }
            #region enemy attacked
            if (WaitTime >= 70)
            {
                hitRoll = UnityEngine.Random.Range(0, 1f + (float)(enemyStats.aim / 10));
                critRoll = UnityEngine.Random.Range(0, 1f + (float)(enemyStats.lck / 20));

                if (hitRoll >= 0.3)
                {
                    if (GetComponent<BattleAbilities>().agro1)
                    {
                        attack = 0;
                    }
                    if (GetComponent<BattleAbilities>().agro2)
                    {
                        attack = 1;
                    }
                    if (GetComponent<BattleAbilities>().agro3)
                    {
                        attack = 2;
                    }
                    if (GetComponent<BattleAbilities>().agro4)
                    {
                        attack = 3;
                    }
                    if (!GetComponent<BattleAbilities>().agro1 && !GetComponent<BattleAbilities>().agro2 && !GetComponent<BattleAbilities>().agro3 && !GetComponent<BattleAbilities>().agro4)
                    {
                        attack = UnityEngine.Random.Range(0, 4);
                    }

                    if (critRoll >= 0.9)
                    {
                        isCrit = true;
                        critRoll = 0;
                        enemyAttacked = false;
                        WaitTime = 0;

                        if (attack == 0)
                        {
                            if (!Member1gone)
                            {
                                Member1.GetComponent<Member1>().stats.HP -= enemyStats.str * 2;

                                if (Member1.GetComponent<Member1>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member1.GetComponent<Member1>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member1.GetComponent<Member1>().SetHP();
                            }
                        }
                        if (attack == 1)
                        {
                            if (!Member2gone)
                            {
                                Member2.GetComponent<Member2>().stats.HP -= enemyStats.str * 2;

                                if (Member2.GetComponent<Member2>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member2.GetComponent<Member2>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member2.GetComponent<Member2>().SetHP();
                            }
                        }
                        if (attack == 2)
                        {
                            if (!Member3gone)
                            {
                                Member3.GetComponent<Member3>().stats.HP -= enemyStats.str * 2;

                                if (Member3.GetComponent<Member3>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member3.GetComponent<Member3>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member3.GetComponent<Member3>().SetHP();
                            }
                        }
                        if (attack == 3)
                        {
                            if (!Member4gone)
                            {
                                Member4.GetComponent<Member4>().stats.HP -= enemyStats.str * 2;

                                if (Member4.GetComponent<Member4>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member4.GetComponent<Member4>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member4.GetComponent<Member4>().SetHP();
                            }
                        }
                        
                        if (attack > 3)
                        {
                            Debug.Log("Enemy Missed!");
                        }

                        ChangeOrder();
                    }
                    if (critRoll < 0.9)
                    {
                        isCrit = false;
                        critRoll = 0;
                        enemyAttacked = false;
                        WaitTime = 0;

                        if (attack == 0)
                        {
                            if (!Member1gone)
                            {
                                Member1.GetComponent<Member1>().stats.HP -= enemyStats.str * 2;

                                if (Member1.GetComponent<Member1>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member1.GetComponent<Member1>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member1.GetComponent<Member1>().SetHP();
                            }
                        }
                        if (attack == 1)
                        {
                            if (!Member2gone)
                            {
                                Member2.GetComponent<Member2>().stats.HP -= enemyStats.str * 2;

                                if (Member2.GetComponent<Member2>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member2.GetComponent<Member2>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member2.GetComponent<Member2>().SetHP();
                            }
                        }
                        if (attack == 2)
                        {
                            if (!Member3gone)
                            {
                                Member3.GetComponent<Member3>().stats.HP -= enemyStats.str * 2;

                                if (Member3.GetComponent<Member3>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member3.GetComponent<Member3>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member3.GetComponent<Member3>().SetHP();
                            }
                        }
                        if (attack == 3)
                        {
                            if (!Member4gone)
                            {
                                Member4.GetComponent<Member4>().stats.HP -= enemyStats.str * 2;

                                if (Member4.GetComponent<Member4>().stats.HP <= 0)
                                {
                                    EnemyKilledCheck = true;
                                }
                                else if (Member4.GetComponent<Member4>().stats.HP > 0)
                                {
                                    EnemyKilledCheck = false;
                                }

                                Member4.GetComponent<Member4>().SetHP();
                            }
                        }

                        if (attack > 3)
                        {
                            Debug.Log("Enemy Missed!");
                        }

                        ChangeOrder();
                    }
                }
                if (hitRoll < 0.3)
                {
                    enemyAttacked = false;
                    WaitTime = 0;

                    ChangeOrder();
                }
            }
            #endregion
        }

        void EndBattle()
        {
            if (enemies[0].GetComponent<EnemyClass>().stats.HP <= 0)
            {
                if (_ebm.IsBattleType)
                {
                    _ebm.EndBattle(true);
                    FindObjectOfType<Fade>().FadeToLevel(1);
                }
                else if (_do.IsBattleType)
                {
                    _do.EndBattle(true);
                    FindObjectOfType<Fade>().FadeToLevel(1);
                }
            }
            if (Member1.GetComponent<Member1>().mem1Dead && Member2.GetComponent<Member2>().mem2Dead && Member3.GetComponent<Member3>().mem3Dead && Member4.GetComponent<Member4>().mem4Dead)
            {
                if (_ebm.IsBattleType)
                {
                    _ebm.EndBattle(false);
                    FindObjectOfType<Fade>().FadeToLevel(1);
                }
                else if (_do.IsBattleType)
                {
                    _do.EndBattle(false);
                    FindObjectOfType<Fade>().FadeToLevel(1);
                }
            }
        }

        void HandleVisuals()
        {
            if (!Member1gone)
            {
                mem1Healths.text = Member1.tag + "\nHP: " + Member1.GetComponent<Member1>().stats.HP + " / " + Member1.GetComponent<Member1>().stats.MaxHP + "\nMP: " + Member1.GetComponent<Member1>().stats.MP + " / " + Member1.GetComponent<Member1>().stats.MaxMP;
            }
            else
            {
                mem1Healths.text = Member1.tag + "\nHP: " + 0 + " / " + Member1.GetComponent<Member1>().stats.MaxHP + "\nMP: " + Member1.GetComponent<Member1>().stats.MP + " / " + Member1.GetComponent<Member1>().stats.MaxMP + "\n[DEAD]";
            }
            if (!Member2gone)
            {
                mem2Healths.text = Member2.tag + "\nHP: " + Member2.GetComponent<Member2>().stats.HP + " / " + Member2.GetComponent<Member2>().stats.MaxHP + "\nMP: " + Member2.GetComponent<Member2>().stats.MP + " / " + Member2.GetComponent<Member2>().stats.MaxMP;
            }
            else
            {
                mem2Healths.text = Member2.tag + "\nHP: " + 0 + " / " + Member2.GetComponent<Member2>().stats.MaxHP + "\nMP: " + Member2.GetComponent<Member2>().stats.MP + " / " + Member2.GetComponent<Member2>().stats.MaxMP + "\n[DEAD]";
            }
            if (!Member3gone)
            {
                mem3Healths.text = Member3.tag + "\nHP: " + Member3.GetComponent<Member3>().stats.HP + " / " + Member3.GetComponent<Member3>().stats.MaxHP + "\nMP: " + Member3.GetComponent<Member3>().stats.MP + " / " + Member3.GetComponent<Member3>().stats.MaxMP;
            }
            else
            {
                mem3Healths.text = Member3.tag + "\nHP: " + 0 + " / " + Member3.GetComponent<Member3>().stats.MaxHP + "\nMP: " + Member3.GetComponent<Member3>().stats.MP + " / " + Member3.GetComponent<Member3>().stats.MaxMP + "\n[DEAD]";
            }
            if (!Member4gone)
            {
                mem4Healths.text = Member4.tag + "\nHP: " + Member4.GetComponent<Member4>().stats.HP + " / " + Member4.GetComponent<Member4>().stats.MaxHP + "\nMP: " + Member4.GetComponent<Member4>().stats.MP + " / " + Member4.GetComponent<Member4>().stats.MaxMP;
            }
            else
            {
                mem4Healths.text = Member4.tag + "\nHP: " + 0 + " / " + Member4.GetComponent<Member4>().stats.MaxHP + "\nMP: " + Member4.GetComponent<Member4>().stats.MP + " / " + Member4.GetComponent<Member4>().stats.MaxMP + "\n[DEAD]";
            }
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

        public void Announce(string announcetext)
        {
            announcePanel.SetActive(true);
            announceText.text = announcetext;

            StartCoroutine(WaitToCloseAnnounce());
        }

        IEnumerator WaitToCloseAnnounce()
        {
            yield return new WaitForSeconds(5);
            announceText.text = "";
            announcePanel.SetActive(false);
        }
    }
}
