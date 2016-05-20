using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class EnemyManager : MonoBehaviour
    {
        public EnemyMovement.Direction direction;

        public int enemyCount;

        public int maxEnemyCount;

        public float secondsOfWait;

        public bool _lock = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            while (enemyCount < maxEnemyCount && _lock == false)
            {
                _lock = true;
                StartCoroutine(Wait());
                break;
            }
        }

        void CreateEnemy()
        {
            GameObject tempEnemy = (GameObject)Instantiate(Resources.Load("OverworldEnemy"));

            tempEnemy.GetComponent<EnemyMovement>().direction = direction;

            tempEnemy.transform.SetParent(gameObject.transform);
            tempEnemy.transform.localPosition = new Vector3(0, -32, 0);
        }

        IEnumerator Wait()
        {
            CreateEnemy();
            yield return new WaitForSeconds(secondsOfWait);
            _lock = false;
        }
    }
}
