using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Skills
{
    //The base Skill class, which is inherited by various
    //skills to be used for combat by an entity.

    public abstract class Skill
    {
        private string _name;
        private byte _level;
        private byte _gauge;
        private float _potency;
        private Target _target;

        protected Skill(string name, byte level, byte gauge, float potency, Target target)
        {
            this._name = name;
            this._level = level;
            this._gauge = gauge;
            this._potency = potency;
            this._target = target;
        }

        //The name of the skill, which is also utilized
        //when printing to the chatlog.
        public string Name
        {
            get { return this._name; }
        }

        //The level required to learn and use the skill.
        public byte Level
        {
            get { return this._level; }
        }

        //The gauge required to execute the skill.
        public byte Gauge
        {
            get { return this._gauge; }
        }

        //A potency modifier used a calculation to determine
        //the damage (or healing) result.
        public float Potency
        {
            get { return this._potency; }
        }

        //Determines whether the skill targets the user
        //or the opponent.
        public Target Target
        {
            get { return this._target; }
        }

        //Calculate the power of the skill based on the
        //skill's potency and the user's level.
        private float GetPower(Entity user)
        {
            return this.Potency * user.Level * 1.5f;
        }

        //Get the ratio for the skill based on the user's attack
        //and the target's defense.
        private float GetRatio(Entity user, Entity target)
        {
            //The base multiplier, calculated by the ratio of
            //the user's attack and the target's defense.
            //Example:
            //     User Attack: 50
            //Defender Defense: 20
            //50 / 20 = 2.5
            float ratio = (float)user.Attack / target.Defense;

            //Generate a random value between a min and max interval to
            //add to the ratio.
            //This prevents the damage from always being the same each time
            //a skill is performed.
            Random random = new Random();
            float rMin = 0.0f;
            float rMax = (float)(0.05 + Math.Pow(0.93, user.Level));
            float rRandom = (float)(rMin + random.NextDouble() * (rMax - rMin));

            //Add the ratio and random value together.
            return ratio + rRandom;
        }

        //Get the final damage result based on the product of
        //the ratio and power factors.
        public virtual short GetDamage(Entity user, Entity target)
        {
            return (short)(this.GetPower(user) * this.GetRatio(user, target));
        }

        //Display the skill name along with the gauge cost.
        //Used for printing out the skill on clickable buttons.
        public override string ToString()
        {
            return string.Format("{0} - {1} Gauge", this.Name, this.Gauge);
        }
    }

    //Used to determine whether the skill targets
    //the user or the opponent.
    public enum Target
    {
        Self,
        Opponent
    }
}
