using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TeamSpigot
{
    public class ClassSetUp : MonoBehaviour
    {
        public GameObject[] classButts;
        public Toggle[] classTogs;
        public GameObject[] classPlayer;
        GameObject p1;
        GameObject p2;
        GameObject p3;
        GameObject p4;
        public GameObject[] players;

        public GameObject[] stands;
        public GameObject[] standPos;

        public GameObject confirmButt;
        public bool confirm;

        string empty = "";

        // Use this for initialization
        void Start()
        {
            confirm = false;

            PlayerPrefs.SetString("member1", empty);
            PlayerPrefs.SetString("member2", empty);
            PlayerPrefs.SetString("member3", empty);
            PlayerPrefs.SetString("member4", empty);
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<OpenningDia>().setUpActive && !confirm)
            {
                classButts[0].SetActive(true);
                classButts[1].SetActive(true);
                classButts[2].SetActive(true);
                classButts[3].SetActive(true);
                classButts[4].SetActive(true);
                classButts[5].SetActive(true);
                classButts[6].SetActive(true);
                classButts[7].SetActive(true);
                classButts[8].SetActive(true);

                stands[0].SetActive(true);
                stands[1].SetActive(true);
                stands[2].SetActive(true);
                stands[3].SetActive(true);
            }

            if (!standPos[0].activeSelf && !standPos[1].activeSelf && !standPos[2].activeSelf && !standPos[3].activeSelf)
            {
				confirmButt.SetActive(true);
            }
            else
            {
				confirmButt.SetActive(false);
            }

            players[0] = p1;
            players[1] = p2;
            players[2] = p3;
            players[3] = p4;
        }

        public void Warrior()
        {
            if (classTogs[0].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[0], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[0].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[0], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[0].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[0], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[0].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[0], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[0].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[0].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "WARRIOR")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "WARRIOR")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "WARRIOR")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "WARRIOR")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void Ninja()
        {
            if (classTogs[1].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[1], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[1].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[1], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[1].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[1], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[1].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[1], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[1].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[1].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "NINJA")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "NINJA")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "NINJA")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "NINJA")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void Monk()
        {
            if (classTogs[2].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[2], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[2].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[2], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[2].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[2], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[2].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[2], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[2].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[2].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "MONK")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "MONK")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "MONK")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "MONK")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void Sentinel()
        {
            if (classTogs[3].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[3], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[3].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[3], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[3].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[3], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[3].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[3], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[3].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[3].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "SENTINEL")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "SENTINEL")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "SENTINEL")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "SENTINEL")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void Gambler()
        {
            if (classTogs[4].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[4], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[4].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[4], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[4].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[4], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[4].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[4], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[4].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[4].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "GAMBLER")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "GAMBLER")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "GAMBLER")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "GAMBLER")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void Undead()
        {
            if (classTogs[5].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[5], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[5].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[5], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[5].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[5], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[5].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[5], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[5].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[5].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "UNDEAD")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "UNDEAD")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "UNDEAD")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "UNDEAD")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void WM()
        {
            if (classTogs[6].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[6], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[6].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[6], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[6].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[6], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[6].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[6], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[6].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[6].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "WM")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "WM")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "WM")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "WM")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void BM()
        {
            if (classTogs[7].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[7], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[7].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[7], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[7].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[7], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[7].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[7], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[7].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[7].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "BM")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "BM")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "BM")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "BM")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void RM()
        {
            if (classTogs[8].isOn)
            {
                if (standPos[0].activeSelf)
                {
                    p1 = (GameObject)Instantiate(classPlayer[8], standPos[0].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member1", classPlayer[8].tag);
                    standPos[0].SetActive(false);
                }
                else if (standPos[1].activeSelf)
                {
                    p2 = (GameObject)Instantiate(classPlayer[8], standPos[1].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member2", classPlayer[8].tag);
                    standPos[1].SetActive(false);
                }
                else if (standPos[2].activeSelf)
                {
                    p3 = (GameObject)Instantiate(classPlayer[8], standPos[2].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member3", classPlayer[8].tag);
                    standPos[2].SetActive(false);
                }
                else if (standPos[3].activeSelf)
                {
                    p4 = (GameObject)Instantiate(classPlayer[8], standPos[3].transform.position, Quaternion.Euler(0, 0, 0));
                    PlayerPrefs.SetString("member4", classPlayer[8].tag);
                    standPos[3].SetActive(false);
                }
            }
            if (!classTogs[8].isOn)
            {
                if (!standPos[0].activeSelf && p1.tag == "RM")
                {
                    standPos[0].SetActive(true);
                    PlayerPrefs.SetString("member1", empty);
                    Destroy(p1);
                }
                if (!standPos[1].activeSelf && p2.tag == "RM")
                {
                    standPos[1].SetActive(true);
                    PlayerPrefs.SetString("member2", empty);
                    Destroy(p2);
                }
                if (!standPos[2].activeSelf && p3.tag == "RM")
                {
                    standPos[2].SetActive(true);
                    PlayerPrefs.SetString("member3", empty);
                    Destroy(p3);
                }
                if (!standPos[3].activeSelf && p4.tag == "RM")
                {
                    standPos[3].SetActive(true);
                    PlayerPrefs.SetString("member4", empty);
                    Destroy(p4);
                }
            }
        }

        public void StatSetUp()
        {
            confirm = true;

            GetComponent<OpenningDia>().setUpActive = false;
            classButts[0].SetActive(false);
            classButts[1].SetActive(false);
            classButts[2].SetActive(false);
            classButts[3].SetActive(false);
            classButts[4].SetActive(false);
            classButts[5].SetActive(false);
            classButts[6].SetActive(false);
            classButts[7].SetActive(false);
            classButts[8].SetActive(false);


			Debug.Log("member1: " + PlayerPrefs.GetString("member1"));
			Debug.Log("member2: " + PlayerPrefs.GetString("member2"));
			Debug.Log("member3: " + PlayerPrefs.GetString("member3"));
			Debug.Log("member4: " + PlayerPrefs.GetString("member4"));
        }
    }
}
