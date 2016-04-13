using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Skills
{
    //A special attack skill which can be utilized by an entity
    //against their opponent during combat.

    public class TyphoonKick : Skill
    {
        //Allow possible customization.
        public TyphoonKick(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default behavior.
        public TyphoonKick() : this("Typhoon Kick", 3, 25, 4.92f, Target.Opponent)
        {
        }
    }
}
