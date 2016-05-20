using System.Collections.Generic;
using UnityEngine;

namespace TeamSpigot
{
    public class GameManager : Singleton<GameManager>
    {
        public class PlayerStatus
        {
            public List<bool> DeadPlayers = new List<bool>(4) { false, false, false, false };
            public List<bool> DroppedOffPlayers = new List<bool>(4) { false, false, false, false };

            public List<bool> InactivePlayers
            {
                get
                {
                    List<bool> tempList = new List<bool>(4);

                    for (int i = 0; i < 4; i++)
                    {
                        if (DeadPlayers[i] == true || DroppedOffPlayers[i] == true)
                        {
                            tempList.Insert(i, true);
                        }
                        else if (DeadPlayers[i] == false || DroppedOffPlayers[i] == false)
                        {
                            tempList.Insert(i, false);
                        }
                    }

                    return tempList;
                }
            }

            public override string ToString()
            {
                return "DeadPlayers: 1: " + DeadPlayers[0] + " 2: " + DeadPlayers[1] + " 3: " + DeadPlayers[2] + " 4: " + DeadPlayers[3] + "\n" + "DroppedOffPlayers: 1: " + DroppedOffPlayers[0] + " 2:" + DroppedOffPlayers[1] + " 3:" + DroppedOffPlayers[2] + " 4:" + DroppedOffPlayers[3] + "\n" + "InactivePlayers: 1: " + InactivePlayers[0] + " 2: " + InactivePlayers[1] + " 3: " + InactivePlayers[2] + " 4: " + InactivePlayers[3];
            }
        }

        public Vector3 playerPosition = Vector3.zero;

        private bool ResetPlayerBool = false;
        private bool ResetEnemiesBool = false;

        public PlayerStatus PlayerStatusStruct = new PlayerStatus();

        void Awake()
        {
        }

        void Update()
        {
            if (ResetPlayerBool == true && FindObjectOfType<PlayerMovement>() != null)
            {
                FindObjectOfType<PlayerMovement>().Locked = false;
                FindObjectOfType<PlayerMovement>().Paused = false;
                FindObjectOfType<PlayerMovement>().transform.position = new Vector3(Mathf.Round(playerPosition.x / FindObjectOfType<PlayerMovement>().SizeOfTiles) * FindObjectOfType<PlayerMovement>().SizeOfTiles,
                                                Mathf.Round(playerPosition.y / FindObjectOfType<PlayerMovement>().SizeOfTiles) * FindObjectOfType<PlayerMovement>().SizeOfTiles, 0);
                ResetPlayerBool = false;
            }

            if (ResetEnemiesBool == true && FindObjectOfType<EnemyMovement>() != null)
            {
                foreach (EnemyMovement em in FindObjectsOfType<EnemyMovement>())
                {
                    em.transform.localPosition = new Vector3(0, -em.SizeOfTiles, 0);
                    em.paused = true;
                    StartCoroutine(em.Wait(5));
                }
            }

            if (FindObjectOfType<PlayerMovement>() != null)
            {
                playerPosition = FindObjectOfType<PlayerMovement>().transform.position;
            }
        }

        void OnLevelWasLoaded(int level)
        {
            if (level == 1)
            {
                GameObject.Find("getPlayerStatusBtn").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(GetPlayerStatusButton);
                // Debug.Log("Found \"getPlayerStatusBtn\"");
            }
        }
        
        public void GetPlayerStatusButton()
        {
        }

        public void ResetPlayer()
        {
            ResetPlayerBool = true;
        }

        public void ResetEnemies()
        {
            ResetEnemiesBool = true;
        }
    }
}