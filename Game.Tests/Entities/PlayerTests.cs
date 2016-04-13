using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Tests
{
    [TestClass]
    public class PlayerTests : EntityTests
    {
        //Verify that the player was properly initialized.
        [TestMethod]
        public void Player_InitializesTest()
        {
            this.Entity_InitializesTest(this.Player);
        }

        //Verify that the player can perform an auto-attack.
        [TestMethod]
        public void Player_PerformAttackTest()
        {
            this.PerformAttackTest(this.Player, this.Enemy);
        }

        //Verify that the players's attributes increase
        //when their level increases.
        [TestMethod]
        public void Player_LevelIncreased_AttributesIncreased()
        {
            this.Entity_LevelIncreased_AttributesIncreased(this.Player);
        }

        //Verify that the players's attributes decrease
        //when their level decreases.
        [TestMethod]
        public void Player_LevelDecreased_AttributesDecrease()
        {
            this.Entity_LevelDecreased_AttributesDecrease(this.Player);
        }

        //Verify that the player's GaugePerAttack increases whenever
        //the AttackDelay increases.
        [TestMethod]
        public void Player_AttackDelayIncreased_GaugePerAttackIncreases()
        {
            this.Entity_AttackDelayIncreased_GaugePerAttackIncreases(this.Player);
        }

        //Verify that the player's GaugePerAttack decreases whenever
        //the AttackDelay decreases.
        [TestMethod]
        public void Player_AttackDelayDecreased_GaugePerAttackDecreases()
        {
            this.Entity_AttackDelayDecreased_GaugePerAttackDecreases(this.Player);
        }

        //Verify that the player's level never exceeds the maximum level
        //nor falls below 1.
        [TestMethod]
        public void Player_LevelExceedsMinMax_LevelRestricted()
        {
            this.Entity_LevelExceedsMinMax_LevelRestricted(this.Player);
        }

        //Verify that the player's Hp never exceeds the maximum value
        //nor falls below 0.
        [TestMethod]
        public void Player_HpExceedsMinMax_HpRestricted()
        {
            this.Entity_HpExceedsMinMax_HpRestricted(this.Player);
        }

        //Verify that the player's Gauge never exceeds the maximum value.
        [TestMethod]
        public void Player_GaugeExceedsMax_GaugeRestricted()
        {
            this.Entity_GaugeExceedsMax_GaugeRestricted(this.Player);
        }

        //Verify that the player's GaugePerAttack never exceeds the
        //maximum value nor falls below 1.
        [TestMethod]
        public void Player_GaugePerAttackExceedsMinMax_GaugePerAttackRestricted()
        {
            this.Entity_GaugePerAttackExceedsMinMax_GaugePerAttackRestricted(this.Player);
        }

        //Verify that the player's AttackDelay never exceeds the maximum value
        //nor falls below the minimum.
        [TestMethod]
        public void Player_AttackDelayExceedsMinMax_AttackDelayRestricted()
        {
            this.Entity_AttackDelayExceedsMinMax_AttackDelayRestricted(this.Player);
        }
    }
}
