using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;

namespace Game.Skills.Tests
{
    [TestClass]
    public class SkillTests
    {
        //Constant variables for the skill in the tests.
        private const string _name = "attack";
        private const byte _level = 20;
        private const byte _gauge = 22;
        private const float _potency = 12.34f;
        private const Target _target = Target.Self;

        //The offensive skill used in the tests.
        private Skill OffenseSkill
        {
            get { return new Attack(_name, _level, _gauge, _potency, _target); }
        }

        //The player entity for the tests.
        private Entity Player
        {
            get { return new Player(1); }
        }

        //The enemy entity for the tests.
        private Entity Enemy
        {
            get { return new Enemy(1); }
        }

        //Verify that skills properly initialize.
        [TestMethod]
        public void SkillTest_Initialized()
        {

            Skill skill = this.OffenseSkill;

            Assert.AreEqual<string>(_name, skill.Name);
            Assert.AreEqual<byte>(_level, skill.Level);
            Assert.AreEqual<byte>(_gauge, skill.Gauge);
            Assert.AreEqual<float>(_potency, skill.Potency);
            Assert.AreEqual<Target>(_target, skill.Target);
        }

        //Verify that the damage output is as expected.
        [TestMethod]
        public void GetDamageTest_Offensive()
        {
            Skill offenseSkill = this.OffenseSkill;
            short damage = offenseSkill.GetDamage(this.Player, this.Enemy);
            //Damage can be 0 or greater.
            Assert.IsTrue(damage >= 0);
        }

        //Verify that the "damage" output for healing
        //is as expected.
        [TestMethod]
        public void GetDamageTest_Healing()
        {
            Skill healingSkill = new Heal("Heal", 33, 44, 20, Target.Self);
            Entity player = this.Player;
            short damage = healingSkill.GetDamage(player, player);
            //Damage can be 0 or lower.
            Assert.IsTrue(damage <= 0);
        }
    }
}