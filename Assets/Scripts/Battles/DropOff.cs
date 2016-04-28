using System;
using UnityEngine;

namespace TeamSpigot
{
    public class DropOff : MonoBehaviour
    {
        public bool[] Member = new bool[4];

        public bool HasChosen = false;

        bool TriggeredTansition = false;

        Rect Window = new Rect();

        public DropOffPoint dropOffPoint;

        public bool AtDropOff
        {
            get
            {
                return atDropOff;
            }
            set
            {
                atDropOff = value;
            }
        }

        public bool atDropOff = false;

        // Use this for initialization
        void Start()
        {
            Member[0] = Convert.ToBoolean(PlayerPrefs.GetString("mem1Dropped", "false"));
            Member[1] = Convert.ToBoolean(PlayerPrefs.GetString("mem2Dropped", "false"));
            Member[2] = Convert.ToBoolean(PlayerPrefs.GetString("mem3Dropped", "false"));
            Member[3] = Convert.ToBoolean(PlayerPrefs.GetString("mem4Dropped", "false"));
        }

        // Update is called once per frame
        void Update()
        {
            if (AtDropOff && dropOffPoint != null && dropOffPoint.HasNotDropped())
            {
                if (TriggeredTansition == false)
                {
                    FindObjectOfType<BattleTransition>().BeginBattle(true);
                    TriggeredTansition = true;
                }
                dropOffPoint.HasWon = true;
            }
            if (AtDropOff && dropOffPoint.HasWon && dropOffPoint.IsDropped())
            {
                PlayerPrefs.SetString("mem1Dropped", Member[0].ToString());
                PlayerPrefs.SetString("mem2Dropped", Member[1].ToString());
                PlayerPrefs.SetString("mem3Dropped", Member[2].ToString());
                PlayerPrefs.SetString("mem4Dropped", Member[3].ToString());
            }
            if (!AtDropOff)
            {
                TriggeredTansition = false;
            }
        }

        // OnGUI is called for the UI
        void OnGUI()
        {
            if (AtDropOff && dropOffPoint.IsAllowedToDrop())
            {
                Window = GUI.Window(0, new Rect(new Vector2(478, 268), new Vector2(250, 480)), DropOffWindow, "Choose To Drop Off");
            }
        }

        void DropOffWindow(int id)
        {
            if (!Member[0] && GUI.Button(new Rect(new Vector2(25, 25), new Vector2(200, 50)), PlayerPrefs.GetString("member1")))
            {
                Member[0] = true;
                dropOffPoint.MemberDroppedOff = 1;
                dropOffPoint.DroppedOff = true;
            }
            if (!Member[1] && GUI.Button(new Rect(new Vector2(25, 75), new Vector2(200, 50)), PlayerPrefs.GetString("member2")))
            {
                Member[1] = true;
                dropOffPoint.MemberDroppedOff = 2;
                dropOffPoint.DroppedOff = true;
            }
            if (!Member[2] && GUI.Button(new Rect(new Vector2(25, 125), new Vector2(200, 50)), PlayerPrefs.GetString("member3")))
            {
                Member[2] = true;
                dropOffPoint.MemberDroppedOff = 3;
                dropOffPoint.DroppedOff = true;
            }
            if (!Member[3] && GUI.Button(new Rect(new Vector2(25, 175), new Vector2(200, 50)), PlayerPrefs.GetString("member4")))
            {
                Member[3] = true;
                dropOffPoint.MemberDroppedOff = 4;
                dropOffPoint.DroppedOff = true;
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
            FindObjectOfType<Fade>().FadeToLevel(1);
        }
    }
}
