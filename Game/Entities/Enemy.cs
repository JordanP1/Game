using Game.Entities.AI;
using Game.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    //The enemy entity, which the player faces off
    //against in battle.

    public class Enemy : Entity
    {
        //AI logic for the enemy to determine
        //which skills to use and when.
        private EnemyAI _ai;

        public Enemy(string name, byte level) :
            base(name, level)
        {
            //Skills that the enemy can unlock and utilize
            //once it reaches the adequate level.
            this.SkillSet = new HashSet<Skill>()
            {
                new ProtrudingClaw(),
                new VileBite(),
                new VoraciousLunge()
            };

            this._ai = new EnemyAI(this);
        }

        //Constructor for name only parameter.
        public Enemy(string name) : this(name, 1)
        {
        }

        //Constructor for level only parameter.
        public Enemy(byte level) : this("Enemy", level)
        {
        }

        //Default level 1 constructor.
        public Enemy() :
            this(1)
        {
        }

        //Performs the basic auto-attack against the player and runs the
        //enemy AI, which may or may not also follow up with a skill
        //based on gauge level and certain conditions.
        public override void PerformAttack(Action<Skill, Entity, Entity> processSkill, Entity target)
        {
            base.PerformAttack(processSkill, target);

            this._ai.PerformSkill(processSkill, target);
        }
    }
}
