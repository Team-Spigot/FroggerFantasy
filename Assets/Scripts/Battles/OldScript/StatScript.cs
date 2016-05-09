using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TeamSpigot
{
    public class StatScript : MonoBehaviour
    {

        //StatStruct stats;

        /*


            #region stats
            public int HP;
            public int MaxHP;
            //Health points and max hp
            public int MP;
            public int MaxMP;
            //Magic points and max mp
            int str;
            //(strength: effects base damage output)
            int vit;
            //(vitality: effects base health)
            int agl;
            //(agility: effects speed of player and ability to dodge)
            int aim;
            //(Aim: effects ability to hit enemy)
            int lck;
            //(lck: effects how much money/exp is earned from enemies, effects crit hits from player and enemy)
            int ang;
            //(angst: effects damage from black spells and adds MP)
            int fai;
            //(faith: effects healing effects from white spells and adds MP)
            int skl;
            //(skill: effects the mitigation of all stats and adds some MP and HP)
            #endregion

            #region texts
            public Text mOneHPTxt;
            public Text mTwoHPTxt;
            public Text mThreeHPTxt;
            public Text mFourHPTxt;
            #endregion

            public GameObject members;

            public GameObject memOne;
            public GameObject memTwo;
            public GameObject memThree;
            public GameObject memFour;
            public GameObject memEnemy;

            public StatScript(GameObject mems)
            {
                mems = members;
            }

            // Use this for initialization
            void Start ()
            {
                #region classes
                if (gameObject.tag == "Warrior")
                {
                    str = Random.Range(6, 9);
                    vit = Random.Range(6, 9);
                    agl = Random.Range(6, 9);
                    aim = Random.Range(5, 8);
                    lck = Random.Range(3, 6);
                    ang = Random.Range(1, 3);
                    fai = Random.Range(2, 4);
                    skl = Random.Range(4, 7);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "Ninja")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "Monk")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "WhiteMage")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "BlackMage")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "RedMage")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "Sentinel")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "Undead")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                if (gameObject.tag == "Gambler")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }


                if (gameObject.tag == "Enemy")
                {
                    str = Random.Range(5, 5);
                    vit = Random.Range(5, 5);
                    agl = Random.Range(5, 5);
                    aim = Random.Range(5, 5);
                    lck = Random.Range(5, 5);
                    ang = Random.Range(5, 5);
                    fai = Random.Range(5, 5);
                    skl = Random.Range(5, 5);
                    HP = MaxHP = 100 + (20 * vit);
                    MP = MaxMP = 50 + (20 * vit);
                }
                Debug.Log("HP = " + HP + ", MP = " + MP + ", str = " + str + ", vit = " + vit + ", agl = " + agl + ", aim = " + aim + ", lck = " + lck + ", ang = " + ang + ", fai = " + fai + ", skl = " + skl);
                #endregion

                #region texts
                mOneHPTxt.text = "";
                mTwoHPTxt.text = "";
                mThreeHPTxt.text = "";
                mFourHPTxt.text = "";
                #endregion
            }

            // Update is called once per frame
            void Update ()
            {


                #region texts
                mOneHPTxt.text = memOne.tag + "\n" + memOne.GetComponent<StatScript>().HP + "/" + memOne.GetComponent<StatScript>().MaxHP;
                mTwoHPTxt.text = memTwo.tag + "\n" + memTwo.GetComponent<StatScript>().HP + "/" + memTwo.GetComponent<StatScript>().MaxHP;
                mThreeHPTxt.text = memThree.tag + "\n" + memThree.GetComponent<StatScript>().HP + "/" + memThree.GetComponent<StatScript>().MaxHP;
                mFourHPTxt.text = memFour.tag + "\n" + memFour.GetComponent<StatScript>().HP + "/" + memFour.GetComponent<StatScript>().MaxHP;
                #endregion
            }*/
    }
}
