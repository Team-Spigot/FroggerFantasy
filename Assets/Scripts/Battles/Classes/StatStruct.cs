using UnityEngine;
using System.Collections;

namespace TeamSpigot
{
    public struct StatStruct
    {
        #region stats
        private float hp;
        public float HP
        {
            get
            {
                return hp;
            }
            set
            {
                float test = value;
                hp = Mathf.Clamp(test, 0, MaxHP);
            }
        }
        public float MaxHP;
        //Health points and max hp
        private float mp;
        public float MP
        {
            get
            {
                return mp;
            }
            set
            {
                mp = Mathf.Clamp(value, 0, MaxMP);
            }
        }
        public float MaxMP;
        //Magic points and max mp
        public float str;
        //(strength: effects base damage output)
        public float vit;
        //(vitality: effects base health)
        public float agl;
        //(agility: effects speed of player and ability to dodge)
        public float aim;
        //(Aim: effects ability to hit enemy)
        public float lck;
        //(lck: effects how much money/exp is earned from enemies, effects crit hits from player and enemy)
        public float ang;
        //(angst: effects damage from black spells and adds MP)
        public float fai;
        //(faith: effects healing effects from white spells and adds MP)
        public float skl;
        //(skill: effects the mitigation of all stats and adds some MP and HP)
        public float exp;

        public bool attacked;
        #endregion
    }
}
