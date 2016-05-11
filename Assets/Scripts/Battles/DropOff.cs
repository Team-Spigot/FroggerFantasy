using System;
using UnityEngine;
using System.Collections.Generic;

namespace TeamSpigot
{
    public class DropOff : MonoBehaviour
    {
        public bool[] Member = new bool[4];

        public bool TriggeredTansition = false;

        public DropOffPoint currentDropOffPoint = null;

        public bool isAtDropOffPoint
        {
            get
            {
                if (currentDropOffPoint != null)
                {
                    return true;
                }

                return false;
            }
        }

        public List<DropOffPoint> dropOffPoints = new List<DropOffPoint>(4);

        // Use this for initialization
        void Start()
        {
            // Do stuff
        }

        // Update is called once per frame
        void Update()
        {
            if (isAtDropOffPoint && currentDropOffPoint.HasNotDropped())
            {
                if (TriggeredTansition == false)
                {
                    FindObjectOfType<BattleTransition>().BeginBattle(false);
                    currentDropOffPoint.BattleStarted = true;
                    TriggeredTansition = true;
                }
            }
            if (isAtDropOffPoint && currentDropOffPoint.BattleStarted != true && currentDropOffPoint.HasWon != true)
            {
                TriggeredTansition = false;
            }
        }

        // OnGUI is called for the UI
        void OnGUI()
        {
            if (isAtDropOffPoint && currentDropOffPoint.IsAllowedToDrop())
            {
                GUI.Window(0, new Rect(new Vector2(478, 268), new Vector2(250, 480)), DropOffWindow, "Choose To Drop Off");
            }
        }

        void DropOffWindow(int id)
        {
            if (!Member[0] && GUI.Button(new Rect(new Vector2(25, 25), new Vector2(200, 50)), PlayerPrefs.GetString("member1")))
            {
                Member[0] = true;
                currentDropOffPoint.MemberDroppedOff = 1;
                currentDropOffPoint.DroppedOff = true;
            }
            if (!Member[1] && GUI.Button(new Rect(new Vector2(25, 75), new Vector2(200, 50)), PlayerPrefs.GetString("member2")))
            {
                Member[1] = true;
                currentDropOffPoint.MemberDroppedOff = 2;
                currentDropOffPoint.DroppedOff = true;
            }
            if (!Member[2] && GUI.Button(new Rect(new Vector2(25, 125), new Vector2(200, 50)), PlayerPrefs.GetString("member3")))
            {
                Member[2] = true;
                currentDropOffPoint.MemberDroppedOff = 3;
                currentDropOffPoint.DroppedOff = true;
            }
            if (!Member[3] && GUI.Button(new Rect(new Vector2(25, 175), new Vector2(200, 50)), PlayerPrefs.GetString("member4")))
            {
                Member[3] = true;
                currentDropOffPoint.MemberDroppedOff = 4;
                currentDropOffPoint.DroppedOff = true;
            }
        }

        public void ClearData()
        {
            PlayerPrefs.DeleteKey("mem1Dropped");
            PlayerPrefs.DeleteKey("mem2Dropped");
            PlayerPrefs.DeleteKey("mem3Dropped");
            PlayerPrefs.DeleteKey("mem4Dropped");
            PlayerPrefs.DeleteKey("DropPoint1");
            PlayerPrefs.DeleteKey("DropPoint2");
            PlayerPrefs.DeleteKey("DropPoint3");
            PlayerPrefs.DeleteKey("DropPoint4");
            PlayerPrefs.DeleteKey("HasWon1");
            PlayerPrefs.DeleteKey("HasWon2");
            PlayerPrefs.DeleteKey("HasWon3");
            PlayerPrefs.DeleteKey("HasWon4");
            PlayerPrefs.DeleteKey("HasWon");
            FindObjectOfType<Fade>().FadeToLevel(1);
        }
    }
}
