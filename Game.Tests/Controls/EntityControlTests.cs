using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;

namespace Game.Tests
{
    [TestClass]
    public class EntityControlTests
    {
        //Verify that the EntityControl properly initializes.
        [TestMethod]
        public void EntityControlTest()
        {
            Entity player = new Player();
            EntityControl ec = new EntityControl(player);

            Entity expected = player;
            Entity actual = ec.Entity;

            Assert.AreEqual<Entity>(expected, actual);
            Assert.AreSame(expected, actual);
        }

        //Verify that the SetEntity() method properly changes
        //out the old entity with the newly passed.
        [TestMethod]
        public void SetEntityTest()
        {
            Entity player = new Player();
            EntityControl ec = new EntityControl(player);
            Entity enemy = new Enemy();

            ec.SetEntity(enemy);

            Entity expected = enemy;
            Entity actual = ec.Entity;

            Assert.AreEqual<Entity>(expected, actual);
            Assert.AreSame(expected, actual);
        }
    }
}