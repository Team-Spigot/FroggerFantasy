using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class EnemyBattleManager : Singleton<EnemyBattleManager>
    {
        public bool TriggeredTansition = false;

        public GameObject currentEnemy = null;

        public bool IsBattleType;

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

        private GameManager _gm;

        void Awake()
        {
            _gm = GameManager.instance;
        }

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
                    FindObjectOfType<PlayerMovement>().Locked = true;
                    FindObjectOfType<PlayerMovement>().Paused = true;
                    PauseEnemies(true);
                    FindObjectOfType<BattleTransition>().BeginBattle(false);
                    BattleStarted = true;
                    TriggeredTansition = true;
                    IsBattleType = true;
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

            if (HasWon)
            {
                HasWon = false;
            }

            // =======
            HasWon = false;
            
            PauseEnemies(false);
            //currentEnemy.GetComponent<EnemyMovement>().ResetEnemyAndDelay(5);
            // =======

            _gm.ResetPlayer();
            IsBattleType = false;
        }

        public void TriggerBattle(GameObject enemy)
        {
            FindObjectOfType<PlayerMovement>().Locked = true;
            currentEnemy = enemy;
        }

        void PauseEnemies(bool state)
        {
            foreach (EnemyMovement em in FindObjectsOfType<EnemyMovement>())
            {
                em.paused = state;
            }
        }
    }
}
