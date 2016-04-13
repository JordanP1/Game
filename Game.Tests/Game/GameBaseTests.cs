using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Tests
{
    [TestClass]
    public class GameBaseTests
    {
        //Verify the GameBase gets properly initialized.
        [TestMethod]
        public void GameBase_InitializedTest()
        {
            GameBase gb = new GameBase(new RichTextBoxScroll());
            Assert.IsNotNull(gb.Player);
            Assert.IsNotNull(gb.Chatlog);
            Assert.IsNotNull(gb.BattleSimulator);
        }
    }
}