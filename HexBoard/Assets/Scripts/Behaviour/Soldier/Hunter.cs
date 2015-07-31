﻿using Assets.Scripts.UI;
using Assets.Scripts.Util;
using Assets.Scripts.Util.Buffs;
using Assets.Scripts.Util.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Soldier
{
    public class Hunter : Util.Abstract.Soldier
    {
        public override void SpecialHit(ISoldier enemy)
        {
            GridManager.instance.Special.onClick.RemoveAllListeners();
            if (IsAttacking || !SkillBar.DecSkillPoints(30)) return;
            FloatingText.Show("Special!!!", "PlayerSpecialText",
            new FromWorldPointTextPositioner(Camera.main, transform.position, 2f, 60f));
            int damege = CalHit();
            if (CheckIfCritical())
                damege *= CriticalHit;
            damege *= SpecialHitParameter;
            enemy.GetHealth().TakeDamage(damege);
            EndOfTurnAction();
        }

        public override void FillSkillBar()
        {
            SkillBar.AddSkillPoints(8);
        }

        public override void ActivateBuffCast()
        {
            foreach (Util.Abstract.Soldier soldier in _player.GetSoldiers())
            {
                soldier.InAttackRange = true;
                soldier.Position.ChangeToBuff();
                AddObserver(soldier);
            }
        }

        public override void BuffAction(Util.Abstract.Soldier teamSoldier)
        {
            ArcherBuff buff = new ArcherBuff();
            buff.DoBuff(teamSoldier);
            Buffs.Add(buff);
            EndOfTurnAction();
        }

        protected override string BuffName()
        {
            return "Rage";
        }
    }
}