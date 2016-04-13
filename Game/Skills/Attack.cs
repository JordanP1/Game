using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;

namespace Game.Skills
{
    //The auto-attack skill used automatically during combat
    //when a delay interval has passed.

    public class Attack : Skill
    {
        //Allow possible customization.
        public Attack(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default attack behavior.
        public Attack() :
            this("attack", 1, 0, 2.25f, Target.Opponent)
        {
        }
    }
}
