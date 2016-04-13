using Game.Entities;
using Game.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.AI
{
    //An AI for the enemy, which randomly selects a skill and
    //uses it based on gauge value and a random interval.

    class EnemyAI
    {
        //The enemy to utilize the AI on.
        private Enemy _enemy;
        //A random skill selected for usage.
        private Skill _selectedSkill;
        //An array of skills that the enemy has access to.
        //These are skills the enemy meets the level
        //requirement for.
        private Skill[] _skills;

        //Delay interval to use the skill, so the enemy doesn't always
        //use it immediately upon acquiring enough gauge.
        private TimeSpan _minSkillDelay;
        private TimeSpan _maxSkillDelay;
        //The time the enemy can use the skill after a skill
        //has been selected.
        private DateTime _skillUseTime;
        //Signifies that _skillUseTime has been set.
        private bool _delayInit;

        public EnemyAI(Enemy enemy)
        {
            this._enemy = enemy;
            //Default delay intervals.
            this._minSkillDelay = TimeSpan.FromMilliseconds(0);
            this._maxSkillDelay = TimeSpan.FromMilliseconds(3458);

            //Subscribe to the enemy's LevelChanged event, so we can
            //add or remove skills based on level requirements.
            this._enemy.LevelChanged += _enemy_LevelChanged;
        }

        //The available skills to the enemy that passed the
        //level requirement check.
        public Skill[] Skills
        {
            get
            {
                //Initialize if null.
                if (this._skills == null)
                {
                    //Grab a list of skills the enemy meets the level
                    //requirement for in their SkillSet.
                    List<Skill> validSkills = new List<Skill>();
                    foreach (Skill s in this._enemy.SkillSet)
                    {
                        if (this._enemy.Level >= s.Level)
                        {
                            validSkills.Add(s);
                        }
                    }

                    //Convert and store the list into the skills array.
                    this._skills = validSkills.ToArray();
                }

                return this._skills;
            }
        }

        //The minimum wait delay for the enemy to use the skill.
        public TimeSpan MinSkillDelay
        {
            get { return this._minSkillDelay; }
            set { this._minSkillDelay = value; }
        }

        //The maximum wait delay for the enemy to use the skill.
        public TimeSpan MaxSkillDelay
        {
            get { return this._maxSkillDelay; }
            set { this._maxSkillDelay = value; }
        }

        //Reset the skills to null on level change, which will trigger a
        //re-evaluation and re-initialization of the array the next time
        //it is accessed.
        private void _enemy_LevelChanged(byte previousLevel, byte newLevel)
        {
            this._skills = null;
        }

        //Performs a random skill from the skills array if conditions are met.
        public void PerformSkill(Action<Skill, Entity, Entity> processSkill,
            Entity target)
        {
            //Exit from the method if the entity has no avaible skills, or
            //the target has already been defeated from an auto-attack.
            if (this.Skills.Length == 0 ||
                this._enemy.Hp <= 0 || target.Hp <= 0) { return; }

            //If a random skill has not yet been selected, select one now.
            if (this._selectedSkill == null)
            {
                //Selects a random skill from the skills array.
                Random random = new Random();
                int index = random.Next(0, this.Skills.Length);
                this._selectedSkill = this.Skills[index];
            }

            //Process the skill only when the enemy has enough gauge points.
            if (this._enemy.Gauge >= this._selectedSkill.Gauge)
            {
                //Check if the random delay interval to use the skill has been
                //set or not.
                if (!this._delayInit)
                {
                    //Generate a random delay interval between the minimum
                    //and maximum interval, and set the usage time based
                    //on that interval.
                    Random random = new Random();
                    TimeSpan interval = this._maxSkillDelay - this._minSkillDelay;

                    double delay = random.NextDouble() *
                        interval.TotalMilliseconds +
                        this._minSkillDelay.TotalMilliseconds;

                    this._skillUseTime = DateTime.UtcNow.AddMilliseconds(delay);
                    this._delayInit = true;
                }

                //If the interval has elapsed, perform the skill on the target.
                if (DateTime.UtcNow >= this._skillUseTime)
                {
                    //Perform the skill.
                    processSkill(this._selectedSkill, this._enemy, target);
                    //Set the selected skill back to null, which will allow for
                    //another random skill to be selected.
                    this._selectedSkill = null;
                    this._delayInit = false;
                }
            }
        }
    }
}
