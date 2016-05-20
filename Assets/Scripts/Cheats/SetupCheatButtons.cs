using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace TeamSpigot
{
    public class SetupCheatButtons : MonoBehaviour
    {
        List<DropOffPoint> DropOffPoints = new List<DropOffPoint>();
        List<GameObject> Enemies = new List<GameObject>();

        // Use this for initialization
        void Awake()
        {
            GameObject.Find("getPlayerStatusBtn").GetComponent<Button>().onClick.AddListener(GetPlayerStatus);
            GameObject.Find("triggerEnemyBattleBtn").GetComponent<Button>().onClick.AddListener(TriggerEnemyBattle);
            GameObject.Find("triggerDropOffBattleBtn").GetComponent<Button>().onClick.AddListener(TriggerDropOffBattle);
        }

        void Start()
        {
            GetDropOffPoints();
            GetEnemies();
        }

        void Update()
        {
            GetEnemies();
        }

        void GetPlayerStatus()
        {
            Debug.Log(GameManager.instance.PlayerStatusStruct.ToString());
        }

        void TriggerEnemyBattle()
        {
            EnemyBattleManager.instance.TriggerBattle(ChooseRandomObject(Enemies));
        }

        void TriggerDropOffBattle()
        {
            DropOff.instance.TriggerBattle(ChooseRandomObject(DropOffPoints));
        }

        void GetDropOffPoints()
        {
            DropOffPoints.AddRange(FindObjectsOfType<DropOffPoint>());
        }

        void GetEnemies()
        {
            Enemies.Clear();

            foreach (EnemyMovement ebm in FindObjectsOfType<EnemyMovement>())
            {
                Enemies.Add(ebm.gameObject);
            }
        }

        T ChooseRandomObject<T>(List<T> CustomList)
        {
            return CustomList[Random.Range(0, CustomList.Count)];
        }
    }
}
