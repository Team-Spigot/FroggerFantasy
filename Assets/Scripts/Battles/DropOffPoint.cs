using UnityEngine;

namespace TeamSpigot
{
    public class DropOffPoint : MonoBehaviour
    {
        public int MemberDroppedOff = 0;
        public bool droppedOff = false;
        public bool DroppedOff
        {
            get
            {
                return droppedOff;
            }
            set
            {
                if (HasWon && value && MemberDroppedOff != 0)
                {
                    PlayerPrefs.SetInt("DropPoint" + DropPointNum, MemberDroppedOff);
                    droppedOff = true;
                }
                else
                {
                    droppedOff = false;
                }
            }
        }
        public string DropPointNum = "1";
        public bool hasWon;
        public bool HasWon
        {
            get
            {
                return hasWon;
            }
            set
            {
                PlayerPrefs.SetString("HasWon" + DropPointNum, value.ToString());
                hasWon = value;
            }
        }

        void Start()
        {
            if (PlayerPrefs.GetInt("DropPoint" + DropPointNum, 0) != 0)
            {
                DroppedOff = true;
                MemberDroppedOff = PlayerPrefs.GetInt("DropPoint" + DropPointNum, 0);
            }
            if (PlayerPrefs.GetString("HasWon" + DropPointNum, "false") != "false")
            {
                HasWon = true;
            }
        }

        void Update()
        {
            if (HasWon && DroppedOff && MemberDroppedOff != 0)
            {
            }
        }

        public bool HasNotDropped()
        {
            return HasWon != true && DroppedOff != true && MemberDroppedOff == 0;
        }

        public bool IsAllowedToDrop()
        {
            return HasWon == true && DroppedOff != true && MemberDroppedOff == 0;
        }

        public bool IsDropped()
        {
            return DroppedOff == true && MemberDroppedOff != 0;
        }
    }
}
