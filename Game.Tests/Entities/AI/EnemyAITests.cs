using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Skills;

namespace Game.Entities.AI.Tests
{
    [TestClass]
    public class EnemyAITests
    {
        //The level requirement for all skills in the test.
        private const byte _skillLevel = 1;

        //The gauge cost for all skills in the test.
        private const byte _skillGauge = 1;

        //The potency for all skills in the test.
        //A high potency ensures it will damage the target.
        private const float _skillPotency = 999;

        //The target of all skills in the test.
        private const Target _skillTarget = Target.Opponent;

        //The levels for the enemy and player in the tests.
        private const byte _enemyLevel = 1;
        private const byte _playerLevel = 1;

        //The enemy used for the AI tests.
        private Enemy Enemy
        {
            get
            {
                //Initialize the enemy.
                Enemy enemy = new Enemy(_enemyLevel);

                Skill skill1 = new ProtrudingClaw(
                    "Protruding Claw",
                    _skillLevel,
                    _skillGauge,
                    _skillPotency,
                    _skillTarget);

                Skill skill2 = new VileBite(
                    "Vile Bite",
                    _skillLevel,
                    _skillGauge,
                    _skillPotency,
                    _skillTarget);

                Skill skill3 = new VoraciousLunge(
                    "Voracious Lunge",
                    _skillLevel,
                    _skillGauge,
                    _skillPotency,
                    _skillTarget);

                //Give the enemy the new skill set.
                enemy.SkillSet = new HashSet<Skill>() { skill1, skill2, skill3 };

                return enemy;
            }
        }

        //The player target used for the AI tests.
        private Player Player
        {
            get
            {
                //Initialize the player.
                Player player = new Player(_playerLevel);
                return player;
            }
        }

        //Verify that the enemy does not execute a skill
        //with insufficient gauge.
        [TestMethod]
        public void PerformSkillTest_EnemyHasNoGauge_SkillNotExecuted()
        {
            //Initialize required instances.
            GameBase gb = new GameBase(new RichTextBoxScroll());
            BattleSimulator battleSim = gb.BattleSimulator;

            //Initialize the enemy and player.
            Enemy enemy = this.Enemy;
            Player player = this.Player;

            //Create the AI for the enemy.
            EnemyAI ai = new EnemyAI(enemy);
            //Set the skill delay to 0 in order to
            //trigger skills right away.
            ai.MinSkillDelay = TimeSpan.FromMilliseconds(0);
            ai.MaxSkillDelay = TimeSpan.FromMilliseconds(0);

            //Trigger a skill against the player.
            Action<Skill, Entity, Entity> processSkill =
                new Action<Skill, Entity, Entity>(battleSim.ProcessSkill);
            ai.PerformSkill(processSkill, player);

            //We expect the skill to not trigger due to the enemy having
            //no gauge value.
            //Check to see if the player took any damage.
            //This should be false, since the enemy shouldn't be able
            //to execute any skills, and thus the player takes no
            //damage and has equal HP and MaxHP.
            bool condition = player.Hp != player.MaxHp;

            Assert.IsFalse(condition);
        }

        //Verify that the enemy can execute a skill once
        //sufficient gauge has been achieved.
        [TestMethod]
        public void PerformSkillTest_EnemyHasMaxGauge_SkillIsExecuted()
        {
            //Initialize required instances.
            GameBase gb = new GameBase(new RichTextBoxScroll());
            BattleSimulator battleSim = gb.BattleSimulator;

            //Initialize the enemy and player.
            Enemy enemy = this.Enemy;
            Player player = this.Player;

            //Give the enemy maximum gauge to execute skills.
            enemy.Gauge = enemy.MaxGauge;

            //Create the AI for the enemy.
            EnemyAI ai = new EnemyAI(enemy);
            //Set the skill delay to 0 in order to
            //trigger skills right away.
            ai.MinSkillDelay = TimeSpan.FromMilliseconds(0);
            ai.MaxSkillDelay = TimeSpan.FromMilliseconds(0);

            //Trigger a skill against the player.
            Action<Skill, Entity, Entity> processSkill =
                new Action<Skill, Entity, Entity>(battleSim.ProcessSkill);
            ai.PerformSkill(processSkill, player);

            //We expect the skill to trigger and damage the player
            //due to having a sufficient amount of gauge.
            //Check to see if the player took any damage.
            //This should be true, since the enemy should be able
            //to execute skills which will damage the player's HP.
            bool condition = player.Hp != player.MaxHp;

            Assert.IsTrue(condition);
        }
    }
}