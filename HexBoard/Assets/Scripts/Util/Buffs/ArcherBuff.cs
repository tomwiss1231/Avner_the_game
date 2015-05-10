﻿using System.Collections;
using Assets.Scripts.Util.Abstract;
using UnityEngine;

namespace Assets.Scripts.Util.Buffs
{
    public class ArcherBuff : Buff
    {
        public ArcherBuff(int turnLeft) : base(turnLeft) { }

        public override void DoBuff(Soldier soldier)
        {
            soldier.MaxDamege *= 3;
            soldier.MinDamege *= 3;
        }

        public override void DisableBuff(Soldier soldier)
        {
            soldier.MaxDamege /= 3;
            soldier.MinDamege /= 3;
        }
    }
}