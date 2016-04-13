using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Skills
{
    //A special attack skill which can be utilized by an entity
    //against their opponent during combat.

    public class BreakneckPunch : Skill
    {
        //Allow possible customization.
        public BreakneckPunch(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default behavior.
        public BreakneckPunch() : this("Breakneck Punch", 9, 35, 7.14f, Target.Opponent)
        {
        }
    }
}
