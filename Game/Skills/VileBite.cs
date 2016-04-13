using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Skills
{
    //A special attack skill which can be utilized by an entity
    //against their opponent during combat.

    public class VileBite : Skill
    {
        //Allow possible customization.
        public VileBite(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default behavior.
        public VileBite() : this("Vile Bite", 10, 60, 3.82f, Target.Opponent)
        {
        }
    }
}
