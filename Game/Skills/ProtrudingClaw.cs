using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Skills
{
    //A special attack skill which can be utilized by an entity
    //against their opponent during combat.

    public class ProtrudingClaw : Skill
    {
        //Allow possible customization.
        public ProtrudingClaw(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default behavior.
        public ProtrudingClaw() : this("Protruding Claw", 5, 50, 2.55f, Target.Opponent)
        {
        }
    }
}
