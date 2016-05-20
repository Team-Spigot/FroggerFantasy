using System;
using UnityEngine;
using System.Collections.Generic;

namespace TeamSpigot
{
    public class DropOff : Singleton<DropOff>
    {
        public bool TriggeredTansition = false;

        public bool IsBattleType;

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

        public List<int> dropoffpoints = new List<int>() { 0, 0, 0, 0 };

        //public List<DropOffPoint> dropOffPoints = new List<DropOffPoint>(4);

        void Awake()
        {
            // Do stuff
        }

        // Use this for initialization
        void Start()
        {
            // Do stuff
        }

        // Update is called once per frame
        void Update()
        {
            if (isAtDropOffPoint && dropoffpoints[currentDropOffPoint.DropPointNum - 1] == 0)
            {
                if (!TriggeredTansition)
                {
                    FindObjectOfType<PlayerMovement>().Locked = true;
                    FindObjectOfType<BattleTransition>().BeginBattle(false);
                    FindObjectOfType<PlayerMovement>().Paused = true;
                    currentDropOffPoint.BattleStarted = true;
                    TriggeredTansition = true;
                    IsBattleType = true;
                }
            }
            if (isAtDropOffPoint && !currentDropOffPoint.BattleStarted && !currentDropOffPoint.HasWon)
            {
                TriggeredTansition = false;
            }

            foreach (DropOffPoint dop in FindObjectsOfType<DropOffPoint>())
            {
                dop.gameObject.GetComponent<Collider2D>().isTrigger = !dop.gameObject.GetComponent<Collider2D>().isTrigger;
            }
        }

        // OnGUI is called for the UI
        void OnGUI()
        {
            if (isAtDropOffPoint && dropoffpoints[currentDropOffPoint.DropPointNum - 1] == 1)
            {
                GUI.Window(0, new Rect(new Vector2(478, 268), new Vector2(250, 480)), DropOffWindow, "Choose To Drop Off");
            }
        }

        void DropOffWindow(int id)
        {
            if (!GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[0] && GUI.Button(new Rect(new Vector2(25, 25), new Vector2(200, 50)), PlayerPrefs.GetString("member1")))
            {
                GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[0] = true;
                currentDropOffPoint.MemberDroppedOff = 1;
                dropoffpoints[currentDropOffPoint.DropPointNum - 1] = 2;
            }
            if (!GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[1] && GUI.Button(new Rect(new Vector2(25, 75), new Vector2(200, 50)), PlayerPrefs.GetString("member2")))
            {
                GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[1] = true;
                currentDropOffPoint.MemberDroppedOff = 2;
                dropoffpoints[currentDropOffPoint.DropPointNum - 1] = 2;
            }
            if (!GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[2] && GUI.Button(new Rect(new Vector2(25, 125), new Vector2(200, 50)), PlayerPrefs.GetString("member3")))
            {
                GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[2] = true;
                currentDropOffPoint.MemberDroppedOff = 3;
                dropoffpoints[currentDropOffPoint.DropPointNum - 1] = 2;
            }
            if (!GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[3] && GUI.Button(new Rect(new Vector2(25, 175), new Vector2(200, 50)), PlayerPrefs.GetString("member4")))
            {
                GameManager.instance.PlayerStatusStruct.DroppedOffPlayers[3] = true;
                currentDropOffPoint.MemberDroppedOff = 4;
                dropoffpoints[currentDropOffPoint.DropPointNum - 1] = 2;
            }
        }

        public void EndBattle(bool hasWon)
        {
            currentDropOffPoint.BattleStarted = false;
            currentDropOffPoint.HasWon = hasWon;

            if (hasWon)
            {
                dropoffpoints[currentDropOffPoint.DropPointNum - 1] = 1;
            }

            if (dropoffpoints.TrueForAll(value => value == 2))
            {
                GameManager.instance.PlayerStatusStruct.DeadPlayers[0] = false;
                GameManager.instance.PlayerStatusStruct.DeadPlayers[1] = false;
                GameManager.instance.PlayerStatusStruct.DeadPlayers[2] = false;
                GameManager.instance.PlayerStatusStruct.DeadPlayers[3] = false;
            }
            
            GameManager.instance.ResetPlayer();
            IsBattleType = false;
        }

        public void TriggerBattle(DropOffPoint dropOffPoint)
        {
            currentDropOffPoint = dropOffPoint;
        }
    }
}
