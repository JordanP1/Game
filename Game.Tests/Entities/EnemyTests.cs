using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Tests
{
    [TestClass]
    public class EnemyTests : EntityTests
    {
        //Verify that the enemy was properly initialized.
        [TestMethod]
        public void Enemy_InitializesTest()
        {
            this.Entity_InitializesTest(this.Enemy);
        }

        //Verify that the enemy can perform an auto-attack.
        [TestMethod]
        public void Enemy_PerformAttackTest()
        {
            this.PerformAttackTest(this.Enemy, this.Player);
        }

        //Verify that the enemy's attributes increase
        //when their level increases.
        [TestMethod]
        public void Enemy_LevelIncreased_AttributesIncreased()
        {
            this.Entity_LevelIncreased_AttributesIncreased(this.Enemy);
        }

        //Verify that the enemy's attributes decrease
        //when their level decreases.
        [TestMethod]
        public void Enemy_LevelDecreased_AttributesDecrease()
        {
            this.Entity_LevelDecreased_AttributesDecrease(this.Enemy);
        }

        //Verify that the enemy's GaugePerAttack increases whenever
        //the AttackDelay increases.
        [TestMethod]
        public void Enemy_AttackDelayIncreased_GaugePerAttackIncreases()
        {
            this.Entity_AttackDelayIncreased_GaugePerAttackIncreases(this.Enemy);
        }

        //Verify that the enemy's GaugePerAttack decreases whenever
        //the AttackDelay decreases.
        [TestMethod]
        public void Enemy_AttackDelayDecreased_GaugePerAttackDecreases()
        {
            this.Entity_AttackDelayDecreased_GaugePerAttackDecreases(this.Enemy);
        }

        //Verify that the enemy's level never exceeds the maximum level
        //nor falls below the minimum.
        [TestMethod]
        public void Enemy_LevelExceedsMinMax_LevelRestricted()
        {
            this.Entity_LevelExceedsMinMax_LevelRestricted(this.Enemy);
        }

        //Verify that the enemy's Hp never exceeds the maximum value
        //nor falls below 0.
        [TestMethod]
        public void Enemy_HpExceedsMinMax_HpRestricted()
        {
            this.Entity_HpExceedsMinMax_HpRestricted(this.Enemy);
        }

        //Verify that the enemy's Gauge never exceeds the maximum value.
        [TestMethod]
        public void Enemy_GaugeExceedsMax_GaugeRestricted()
        {
            this.Entity_GaugeExceedsMax_GaugeRestricted(this.Enemy);
        }

        //Verify that the enemy's GaugePerAttack never exceeds the
        //maximum value nor falls below 1.
        [TestMethod]
        public void Enemy_GaugePerAttackExceedsMinMax_GaugePerAttackRestricted()
        {
            this.Entity_GaugePerAttackExceedsMinMax_GaugePerAttackRestricted(this.Enemy);
        }

        //Verify that the enemy's AttackDelay never exceeds the maximum value
        //nor falls below the minimum.
        [TestMethod]
        public void Enemy_AttackDelayExceedsMinMax_AttackDelayRestricted()
        {
            this.Entity_AttackDelayExceedsMinMax_AttackDelayRestricted(this.Enemy);
        }
    }
}
