using Game.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    //The player entity who the user plays as
    //during combat against the enemy.

    public class Player : Entity
    {
        //Pass in modifiers for the player different from the defaults.
        public Player(string name, byte level) :
            base(name, level, new Modifiers(74, 9.64f, 1.51f, 4.42f, 3.91f))
        {
            //Set the AttackDelay to something other than the default.
            this.AttackDelay = TimeSpan.FromMilliseconds(1421);
            //Skills that the player can unlock and utilize
            //once they reach the adequate level.
            this.SkillSet = new HashSet<Skill>()
            {
                new TyphoonKick(),
                new Heal(),
                new BreakneckPunch()
            };
        }

        //Constructor for name only parameter.
        public Player(string name) : this(name, 1)
        {
        }

        //Constructor for level only parameter.
        public Player(byte level) : this("Player", level)
        {
        }

        //Default level 1 constructor.
        public Player() :
            this(1)
        {
        }
    }
}
