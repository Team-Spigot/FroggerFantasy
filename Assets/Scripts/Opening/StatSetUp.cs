using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public class StatSetUp : MonoBehaviour
    {
        //GameObject[] party;

        void Update()
        {
            //party = GetComponent<ClassSetUp>().players;

            if (GetComponent<ClassSetUp>().confirm)
            {
                GetComponent<ClassSetUp>().confirm = false;
                //foreach (GameObject member in party)
                //{
                //}
            }
        }
    }
}
