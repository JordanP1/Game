using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;

namespace Game.Skills
{
    //A special healing skill which can be utilized by an entity
    //to recover their HP.

    public class Heal : Skill
    {
        //Allow possible customization for the heal skill.
        public Heal(string name, byte level, byte gauge, float potency, Target target) :
            base(name, level, gauge, potency, target)
        {
        }

        //Default heal behavior.
        public Heal() :
            this("Heal", 5, 30, 0.25f, Target.Self)
        {
        }

        //Change the "damage" calculation, which will return a negative
        //value to heal the target's HP rather than damage.
        public override short GetDamage(Entity user, Entity target)
        {
            //User's level adds 1% potency per level.
            //Level 25 would add 25% additional potency.
            //25% (default base potency) + 25% = 50% total potency.
            //This percent is multiplied with the target's Max HP.
            //The result is the amount of HP healed for.
            short damage = (short)((this.Potency + user.Level / 100) * target.MaxHp);

            //The amount of HP the target is missing
            short dHp = (short)(target.MaxHp - target.Hp);

            //Cap the healed amount if it exceeds the amount of missing HP.
            if (damage > dHp) { damage = dHp; }

            //Negate the result so it heals instead of damages.
            return (short)-damage;
        }
    }
}
