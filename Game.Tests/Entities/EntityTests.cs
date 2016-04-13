using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Skills;

namespace Game.Entities.Tests
{
    [TestClass]
    public abstract class EntityTests
    {
        //The player entity used for the tests.
        public Entity Player
        {
            get
            {
                //Initialize a player at level 1.
                Entity player = new Player(1);
                return player;
            }
        }

        //The enemy entity used for the tests.
        public Entity Enemy
        {
            get
            {
                //Initialize an enemy at level 1.
                Entity enemy = new Player(1);
                return enemy;
            }
        }

        //Tests to see if an entity can properly attack.
        [TestMethod]
        protected void PerformAttackTest(Entity user, Entity target)
        {
            //Verify that the user's GaugePerAttack is not 0.
            Assert.AreNotEqual<byte>(0, user.GaugePerAttack);

            //Initialize necessary instances.
            GameBase gb = new GameBase(new RichTextBoxScroll());

            Action<Skill, Entity, Entity> processSkill =
                new Action<Skill, Entity, Entity>(gb.BattleSimulator.ProcessSkill);

            //Allow user to attack right away.
            user.AttackDelay = TimeSpan.FromMilliseconds(0);

            //Start with 0 gauge.
            user.Gauge = 0;

            //Perform the attack.
            user.PerformAttack(processSkill, target);

            //Check to see if the gauge increased by the
            //expected GaugePerAttack amount.
            Assert.AreEqual<byte>(user.GaugePerAttack, user.Gauge);
        }

        //Tests to see if the passed entity was properly initialized.
        [TestMethod]
        protected void Entity_InitializesTest(Entity entity)
        {
            Assert.IsNotNull(entity.Name);

            Assert.AreNotEqual<byte>(0, entity.Level);
            Assert.AreNotEqual<byte>(0, entity.MaxLevel);
            Assert.IsTrue(entity.MaxLevel >= entity.Level);

            Assert.AreNotEqual<short>(0, entity.Hp);
            Assert.AreNotEqual<short>(0, entity.MaxHp);
            Assert.IsTrue(entity.Hp == entity.MaxHp);

            Assert.AreNotEqual<ushort>(0, entity.Attack);
            Assert.AreNotEqual<ushort>(0, entity.Defense);

            Assert.AreNotEqual<byte>(0, entity.MaxGauge);
            Assert.IsTrue(entity.Gauge <= entity.MaxGauge);

            Assert.AreNotEqual<byte>(0, entity.GaugePerAttack);
            Assert.IsTrue(entity.GaugePerAttack <= entity.MaxGauge);

            Assert.AreNotEqual<double>(0, entity.AttackDelay.TotalMilliseconds);

            Assert.IsNotNull(entity.AttackSkill);
        }

        //Test to see if the entity's attributes increase
        //along with their level.
        [TestMethod]
        protected void Entity_LevelIncreased_AttributesIncreased(Entity entity)
        {
            //Starting level for test.
            entity.Level = 1;
            //Ensure the max level is high enough
            //for attribute changes.
            entity.MaxLevel = 25;

            //Store the entity's current attributes before
            //level is changed.
            short hp = entity.Hp;
            short maxHp = entity.MaxHp;
            ushort attack = entity.Attack;
            ushort defense = entity.Defense;

            //Set the entity to their maximum level.
            entity.Level = entity.MaxLevel;

            //Verify that the attributes have increased
            //to reflect new level.
            Assert.IsTrue(entity.Hp > hp);
            Assert.IsTrue(entity.MaxHp > maxHp);
            //Verify HP refill on level change.
            Assert.IsTrue(entity.Hp == entity.MaxHp);
            Assert.IsTrue(entity.Attack > attack);
            Assert.IsTrue(entity.Defense > defense);
        }


        //Test to see if the entity's attributes decrease
        //along with their level.
        [TestMethod]
        protected void Entity_LevelDecreased_AttributesDecrease(Entity entity)
        {
            //Ensure the max level is high enough
            //for attribute changes.
            entity.MaxLevel = 25;
            //Start entity at their maximum level.
            entity.Level = entity.MaxLevel;
            

            //Store the entity's current attributes before
            //level is changed.
            short hp = entity.Hp;
            short maxHp = entity.MaxHp;
            ushort attack = entity.Attack;
            ushort defense = entity.Defense;

            //Set the entity to level 1.
            entity.Level = 1;

            //Verify that the attributes have decreased
            //to reflect new level.
            Assert.IsTrue(entity.Hp < hp);
            Assert.IsTrue(entity.MaxHp < maxHp);
            //Verify HP refill on level change.
            Assert.IsTrue(entity.Hp == entity.MaxHp);
            Assert.IsTrue(entity.Attack < attack);
            Assert.IsTrue(entity.Defense < defense);
        }

        //Test to verify that the GaugePerAttack increases along
        //with the AttackDelay.
        [TestMethod]
        protected void Entity_AttackDelayIncreased_GaugePerAttackIncreases(Entity entity)
        {
            //A 1000 millisecond attack delay.
            entity.AttackDelay = TimeSpan.FromMilliseconds(1000);

            //Store the GaugePerAttack at a 1000 millisecond attack delay.
            byte gaugePerAttack = entity.GaugePerAttack;

            //Increase the attack delay to 3000 milliseconds.
            entity.AttackDelay = TimeSpan.FromMilliseconds(3000);

            //Verify that the GaugePerAttack increased.
            Assert.IsTrue(entity.GaugePerAttack > gaugePerAttack);
        }

        //Test to verify that the GaugePerAttack decreases along
        //with the AttackDelay.
        [TestMethod]
        protected void Entity_AttackDelayDecreased_GaugePerAttackDecreases(Entity entity)
        {
            //A 3000 millisecond attack delay.
            entity.AttackDelay = TimeSpan.FromMilliseconds(3000);

            //Store the GaugePerAttack at a 3000 millisecond attack delay.
            byte gaugePerAttack = entity.GaugePerAttack;

            //Decrease the attack delay to 1000 milliseconds.
            entity.AttackDelay = TimeSpan.FromMilliseconds(1000);

            //Verify that the GaugePerAttack decreased.
            Assert.IsTrue(entity.GaugePerAttack < gaugePerAttack);
        }

        //Tests to ensure that the entity's level does not exceed the
        //maximum level or fall below the minimum.
        [TestMethod]
        protected void Entity_LevelExceedsMinMax_LevelRestricted(Entity entity)
        {
            //Initial values.
            entity.MaxLevel = 25;
            entity.Level = 1;

            //Ensure the level does not exceed the maximum.
            entity.Level = (byte)(entity.MaxLevel + 1);
            Assert.AreEqual<byte>(entity.MaxLevel, entity.Level);

            //Ensure the level cannot drop below 1.
            entity.Level = 0;
            Assert.AreEqual<byte>(1, entity.Level);

            //Ensure that the level does not exceed the maximum
            //level should the maximum level decrease.
            entity.Level = entity.MaxLevel;
            entity.MaxLevel = 10;
            Assert.AreEqual<byte>(entity.MaxLevel, entity.Level);
        }

        //Tests to ensure that the entity's Hp does not exceed the
        //maximum value or fall below 0.
        [TestMethod]
        protected void Entity_HpExceedsMinMax_HpRestricted(Entity entity)
        {
            //Verify that the Hp value cannot exceed the MaxHp value.
            entity.Hp = (short)(entity.MaxHp + 1);
            Assert.AreEqual<short>(entity.MaxHp, entity.Hp);

            //Verify that the Hp value cannot drop below 0.
            entity.Hp = -1;
            Assert.AreEqual<short>(0, entity.Hp);
        }

        //Tests to ensure that the entity's Gauge does not exceed the
        //maximum value.
        [TestMethod]
        protected void Entity_GaugeExceedsMax_GaugeRestricted(Entity entity)
        {
            //Verify that the Gauge value cannot exceed the MaxGauge value.
            entity.Gauge = (byte)(entity.MaxGauge + 1);
            Assert.AreEqual<byte>(entity.MaxGauge, entity.Gauge);
        }

        //Tests to ensure that the entity's GaugePerAttack does not
        //exceed the maximum value or fall below the minimum.
        [TestMethod]
        protected void Entity_GaugePerAttackExceedsMinMax_GaugePerAttackRestricted(Entity entity)
        {
            //Verify that the GaugePerAttack value cannot exceed the MaxGauge value.
            entity.AttackDelay = TimeSpan.FromMilliseconds(100000);
            Assert.AreEqual<byte>(entity.MaxGauge, entity.GaugePerAttack);

            //Verify that the GaugePerAttack value does not fall below 1.
            entity.AttackDelay = TimeSpan.FromMilliseconds(0);
            Assert.AreEqual<byte>(1, entity.GaugePerAttack);
        }

        //Tests to ensure that the entity's AttackDelay does not
        //exceed the maximum value or fall below the minimum.
        [TestMethod]
        protected void Entity_AttackDelayExceedsMinMax_AttackDelayRestricted(Entity entity)
        {
            //Verify that the AttackDelay value cannot exceed the MaxAttackDelay value.
            entity.AttackDelay = entity.MaxAttackDelay.Add(TimeSpan.FromMilliseconds(1));
            Assert.AreEqual<TimeSpan>(entity.MaxAttackDelay, entity.AttackDelay);

            //Verify that the AttackDelay value does not fall below the MinAttackDelay value.
            entity.AttackDelay = entity.MinAttackDelay.Subtract(TimeSpan.FromMilliseconds(1));
            Assert.AreEqual<TimeSpan>(entity.MinAttackDelay, entity.AttackDelay);
        }
    }
}