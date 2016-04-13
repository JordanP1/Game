using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;
using Game.Skills;

namespace Game.Tests
{
    [TestClass()]
    public class BattleSimulatorTests
    {
        //The BattleSimulator used in the tests.
        public BattleSimulator BattleSimulator
        {
            get
            {
                GameBase gb = new GameBase(new RichTextBoxScroll());
                return gb.BattleSimulator;
            }
        }

        //The player entity used for the tests.
        public Player Player
        {
            get { return new Player(1); }
        }

        //The enemy entity used for the tests.
        public Enemy Enemy
        {
            get { return new Enemy(1); }
        }

        //Test to verify that the ProcessSkill method executes
        //and damages the target as intended.
        [TestMethod]
        public void ProcessSkill_AttackTest()
        {
            //Initialize necessary instances.
            BattleSimulator battleSim = this.BattleSimulator;

            //A custom attack skill used for the tests.
            Skill attackSkill = new Attack("attack", 1, 25, 999, Target.Opponent);

            //Initialize entities.
            Player player = this.Player;
            Enemy enemy = this.Enemy;

            //Give the player enough gauge to use the attack skill.
            player.Gauge = attackSkill.Gauge;
            //Trigger the skill.
            battleSim.ProcessSkill(attackSkill, player, enemy);

            //Verify to see if the player's gauge was consumed, which
            //indicates a successful execution.
            Assert.AreEqual<byte>(0, player.Gauge);

            //Follow up by making sure the enemy took
            //damage from the attack.
            Assert.AreNotEqual<short>(enemy.MaxHp, enemy.Hp);
        }

        //Test to verify that the ProcessSkill method executes
        //and heals the target as intended.
        [TestMethod]
        public void ProcessSkill_RecoveryTest()
        {
            //Initialize necessary instances.
            BattleSimulator battleSim = this.BattleSimulator;

            //A custom healing skill used for the tests.
            Skill attackSkill = new Heal("Heal", 1, 25, 999, Target.Self);

            //Initialize entities.
            Player player = this.Player;
            Enemy enemy = this.Enemy;

            //Give the player enough gauge to use the healing skill.
            player.Gauge = attackSkill.Gauge;

            //Damage the player to verify that Hp gets recovered.
            player.Hp = 1;

            //Damage the enemy to make sure the enemy is not
            //recovering from the skill as well.
            enemy.Hp = 1;

            //Trigger the skill.
            battleSim.ProcessSkill(attackSkill, player, enemy);

            //Verify to see if the player's gauge was consumed, which
            //indicates a successful execution.
            Assert.AreEqual<byte>(0, player.Gauge);

            //Follow up by making sure the player recovered Hp.
            Assert.IsTrue(player.Hp > 1);

            //Check to make sure the healing effects were not
            //also applied to the enemy's Hp.
            Assert.AreEqual<short>(1, enemy.Hp);
        }
    }
}