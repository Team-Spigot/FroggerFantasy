using UnityEngine;
using System.Collections;
using TeamSpigot;

public class Boss : MonoBehaviour {
    public bool hit;
    public EnemyBattleManager _ebm;

    void Awake()
    {
        _ebm = EnemyBattleManager.instance;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (PlayerPrefs.GetInt("Won") != 1 && hit)
        {
            EnemyBattleManager.instance.boss = true;
            FindObjectOfType<SetupCheatButtons>().TriggerEnemyBattle();
        }
	}

    void OnColliderHit2D(Collider2D col)
    {
    }
}
