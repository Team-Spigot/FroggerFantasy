using UnityEngine;
using UnityEditor;
using System.Collections;

namespace TeamSpigot
{
    public class Member2 : MonoBehaviour
    {
        public StatStruct stats;

        public GameObject mem2;

        public bool attackCalled = false;
        public GameObject battleManager;

        public bool mem2Dead;

        // Use this for initialization
        void Start()
        {
            mem2.tag = PlayerPrefs.GetString("member2");

            if (mem2.tag == "WARRIOR")
            {
                stats.str = PlayerPrefs.GetFloat("warStr");
                stats.vit = PlayerPrefs.GetFloat("warVit");
                stats.agl = PlayerPrefs.GetFloat("warAgl");
                stats.aim = PlayerPrefs.GetFloat("warAim");
                stats.lck = PlayerPrefs.GetFloat("warLck");
                stats.ang = PlayerPrefs.GetFloat("warAng");
                stats.fai = PlayerPrefs.GetFloat("warFai");
                stats.skl = PlayerPrefs.GetFloat("warSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("warMaxHP");
                stats.HP = PlayerPrefs.GetFloat("warHP");
                stats.MaxMP = PlayerPrefs.GetFloat("warMaxMP");
                stats.MP = PlayerPrefs.GetFloat("warMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/ArmoredFighterBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "NINJA")
            {
                stats.str = PlayerPrefs.GetFloat("ninjStr");
                stats.vit = PlayerPrefs.GetFloat("ninjVit");
                stats.agl = PlayerPrefs.GetFloat("ninjAgl");
                stats.aim = PlayerPrefs.GetFloat("ninjAim");
                stats.lck = PlayerPrefs.GetFloat("ninjLck");
                stats.ang = PlayerPrefs.GetFloat("ninjAng");
                stats.fai = PlayerPrefs.GetFloat("ninjFai");
                stats.skl = PlayerPrefs.GetFloat("ninjSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("ninjMaxHP");
                stats.HP = PlayerPrefs.GetFloat("ninjHP");
                stats.MaxMP = PlayerPrefs.GetFloat("ninjMaxMP");
                stats.MP = PlayerPrefs.GetFloat("ninjMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/NinjaBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "MONK")
            {
                stats.str = PlayerPrefs.GetFloat("monkStr");
                stats.vit = PlayerPrefs.GetFloat("monkVit");
                stats.agl = PlayerPrefs.GetFloat("monkAgl");
                stats.aim = PlayerPrefs.GetFloat("monkAim");
                stats.lck = PlayerPrefs.GetFloat("monkLck");
                stats.ang = PlayerPrefs.GetFloat("monkAng");
                stats.fai = PlayerPrefs.GetFloat("monkFai");
                stats.skl = PlayerPrefs.GetFloat("monkSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("monkMaxHP");
                stats.HP = PlayerPrefs.GetFloat("monkHP");
                stats.MaxMP = PlayerPrefs.GetFloat("monkMaxMP");
                stats.MP = PlayerPrefs.GetFloat("monkMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/RedFighterBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "SENTINEL")
            {
                stats.str = PlayerPrefs.GetFloat("sentStr");
                stats.vit = PlayerPrefs.GetFloat("sentVit");
                stats.agl = PlayerPrefs.GetFloat("sentAgl");
                stats.aim = PlayerPrefs.GetFloat("sentAim");
                stats.lck = PlayerPrefs.GetFloat("sentLck");
                stats.ang = PlayerPrefs.GetFloat("sentAng");
                stats.fai = PlayerPrefs.GetFloat("sentFai");
                stats.skl = PlayerPrefs.GetFloat("sentSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("sentMaxHP");
                stats.HP = PlayerPrefs.GetFloat("sentHP");
                stats.MaxMP = PlayerPrefs.GetFloat("sentMaxMP");
                stats.MP = PlayerPrefs.GetFloat("sentMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/SentinelBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "GAMBLER")
            {
                stats.str = PlayerPrefs.GetFloat("gambStr");
                stats.vit = PlayerPrefs.GetFloat("gambVit");
                stats.agl = PlayerPrefs.GetFloat("gambAgl");
                stats.aim = PlayerPrefs.GetFloat("gambAim");
                stats.lck = PlayerPrefs.GetFloat("gambLck");
                stats.ang = PlayerPrefs.GetFloat("gambAng");
                stats.fai = PlayerPrefs.GetFloat("gambFai");
                stats.skl = PlayerPrefs.GetFloat("gambSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("gambMaxHP");
                stats.HP = PlayerPrefs.GetFloat("gambHP");
                stats.MaxMP = PlayerPrefs.GetFloat("gambMaxMP");
                stats.MP = PlayerPrefs.GetFloat("gambMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/GamblerBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "UNDEAD")
            {
                stats.str = PlayerPrefs.GetFloat("UDStr");
                stats.vit = PlayerPrefs.GetFloat("UDVit");
                stats.agl = PlayerPrefs.GetFloat("UDAgl");
                stats.aim = PlayerPrefs.GetFloat("UDAim");
                stats.lck = PlayerPrefs.GetFloat("UDLck");
                stats.ang = PlayerPrefs.GetFloat("UDAng");
                stats.fai = PlayerPrefs.GetFloat("UDFai");
                stats.skl = PlayerPrefs.GetFloat("UDSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("UDMaxHP");
                stats.HP = PlayerPrefs.GetFloat("UDHP");
                stats.MaxMP = PlayerPrefs.GetFloat("UDMaxMP");
                stats.MP = PlayerPrefs.GetFloat("UDMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/UndeadBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "WM")
            {
                stats.str = PlayerPrefs.GetFloat("WMStr");
                stats.vit = PlayerPrefs.GetFloat("WMVit");
                stats.agl = PlayerPrefs.GetFloat("WMAgl");
                stats.aim = PlayerPrefs.GetFloat("WMAim");
                stats.lck = PlayerPrefs.GetFloat("WMLck");
                stats.ang = PlayerPrefs.GetFloat("WMAng");
                stats.fai = PlayerPrefs.GetFloat("wMFai");
                stats.skl = PlayerPrefs.GetFloat("WMSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("WMMaxHP");
                stats.HP = PlayerPrefs.GetFloat("WMHP");
                stats.MaxMP = PlayerPrefs.GetFloat("WMMaxMP");
                stats.MP = PlayerPrefs.GetFloat("WMMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/WhiteMageBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "BM")
            {
                stats.str = PlayerPrefs.GetFloat("BMStr");
                stats.vit = PlayerPrefs.GetFloat("BMVit");
                stats.agl = PlayerPrefs.GetFloat("BMAgl");
                stats.aim = PlayerPrefs.GetFloat("BMAim");
                stats.lck = PlayerPrefs.GetFloat("BMLck");
                stats.ang = PlayerPrefs.GetFloat("BMAng");
                stats.fai = PlayerPrefs.GetFloat("BMFai");
                stats.skl = PlayerPrefs.GetFloat("BMSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("BMMaxHP");
                stats.HP = PlayerPrefs.GetFloat("BMHP");
                stats.MaxMP = PlayerPrefs.GetFloat("BMMaxMP");
                stats.MP = PlayerPrefs.GetFloat("BMMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/BlackMageBunny.png", typeof(Sprite));
            }
            if (mem2.tag == "RM")
            {
                stats.str = PlayerPrefs.GetFloat("RMStr");
                stats.vit = PlayerPrefs.GetFloat("RMVit");
                stats.agl = PlayerPrefs.GetFloat("RMAgl");
                stats.aim = PlayerPrefs.GetFloat("RMAim");
                stats.lck = PlayerPrefs.GetFloat("RMLck");
                stats.ang = PlayerPrefs.GetFloat("RMAng");
                stats.fai = PlayerPrefs.GetFloat("RMFai");
                stats.skl = PlayerPrefs.GetFloat("RMSkl");

                stats.MaxHP = PlayerPrefs.GetFloat("RMMaxHP");
                stats.HP = PlayerPrefs.GetFloat("RMHP");
                stats.MaxMP = PlayerPrefs.GetFloat("RMMaxMP");
                stats.MP = PlayerPrefs.GetFloat("RMMP");

                mem2.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/Player/RedMageBunny.png", typeof(Sprite));
            }
            Debug.Log("mem2." + mem2.tag + "\nagl: " + stats.agl);
        }

        // Update is called once per frame
        void Update()
        {
            if (stats.HP <= 0)
            {
                mem2Dead = true;
            }
            else if (stats.HP > 0)
            {
                mem2Dead = false;
            }

            if (stats.HP > stats.MaxHP)
            {
                stats.HP = stats.MaxHP;
            }
            DeadCheck();
        }

        void DeadCheck()
        {
            if (mem2Dead)
            {
                gameObject.SetActive(false);
            }
        }
    }
}