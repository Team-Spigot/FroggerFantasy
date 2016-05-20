using UnityEngine;

namespace TeamSpigot
{
    public class DropOffPoint : MonoBehaviour
    {
        public int MemberDroppedOff = 0;

        public bool DroppedOff = false;
        private bool droppedOff
        {
            set
            {
                if (HasWon && value && MemberDroppedOff != 0)
                {
                    DroppedOff = true;
                }
                else
                {
                    DroppedOff = false;
                }
            }
        }

        public string DropPointNum = "1";

        public bool HasWon;
        public bool BattleStarted;

        public bool IsAtDropOffPoint
        {
            get
            {
                if (FindObjectOfType<DropOff>().isAtDropOffPoint && FindObjectOfType<DropOff>().currentDropOffPoint == this)
                {
                    return true;
                }
                return false;
            }
        }

        void Start()
        {
            // Do stuff
        }

        void Update()
        {
            // Do stuff
        }

        public bool HasNotDropped()
        {
            return !HasWon && !DroppedOff && MemberDroppedOff == 0;
        }

        public bool IsAllowedToDrop()
        {
            return IsAtDropOffPoint && HasWon && !BattleStarted && !DroppedOff && MemberDroppedOff == 0;
        }

        public bool HasDropped()
        {
            return DroppedOff && MemberDroppedOff != 0;
        }
    }
}
