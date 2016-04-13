using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Skills;

namespace Game.Tests
{
    [TestClass]
    public class ButtonSkillTests
    {
        //Verify that the ButtonSkill properly initializes.
        [TestMethod]
        public void ButtonSkillTest()
        {
            Skill skill = new Attack();
            ButtonSkill buttonSkill = new ButtonSkill(skill);

            Skill expected = skill;
            Skill actual = buttonSkill.Skill;

            Assert.AreEqual<Skill>(expected, actual);
            Assert.AreSame(expected, actual);
        }
    }
}