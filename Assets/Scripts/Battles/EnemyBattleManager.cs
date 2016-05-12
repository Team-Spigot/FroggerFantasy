using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class EnemyBattleManager : MonoBehaviour
    {
        public bool TriggeredTansition = false;

        public GameObject currentEnemy = null;

        public bool hasTouchedEnemy
        {
            get
            {
                if (currentEnemy != null)
                {
                    return true;
                }

                return false;
            }
        }

        public bool BattleStarted = false;

        public bool HasWon = false;

        public GameObject MainOverworldCamera;

        // Use this for initialization
        void Start()
        {
            // Do Stuff
        }

        // Update is called once per frame
        void Update()
        {
            if (hasTouchedEnemy)
            {
                if (!TriggeredTansition)
                {
                    FindObjectOfType<BattleTransition>().BeginBattle(false);
                    BattleStarted = true;
                    currentEnemy.GetComponent<EnemyMovement>().paused = true;
                    FindObjectOfType<PlayerMovement>().paused = true;
                    TriggeredTansition = true;
                }
            }
            if (!hasTouchedEnemy && !BattleStarted && !HasWon)
            {
                TriggeredTansition = false;
            }
        }

        public void EndBattle(bool hasWon)
        {
            BattleStarted = false;
            HasWon = hasWon;

            MainOverworldCamera.SetActive(true);

            if (HasWon)
            {
                currentEnemy.GetComponent<EnemyMovement>().ResetEnemyAndDelay(5);
                FindObjectOfType<PlayerMovement>().ResetPlayer();
                HasWon = false;
            }
        }
    }
}
