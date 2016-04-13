using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Skills
{
    //A special attack skill which can be utilized by an entity
    //against their opponent during combat.

    public class VoraciousLunge : Skill
    {
        //Allow possible customization.
        public VoraciousLunge(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default behavior.
        public VoraciousLunge() : this("Voracious Lunge", 20, 55, 5.47f, Target.Opponent)
        {
        }
    }
}
