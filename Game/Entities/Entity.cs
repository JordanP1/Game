using Game.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    //The base entity class for the player and enemy.
    //Contains stats that both entities require for combat.

    public abstract class Entity
    {
        private string _name;
        private byte _level;
        private byte _maxLevel;
        private short _hp;
        private short _maxHp;
        private ushort _attack;
        private ushort _defense;
        private byte _gauge;
        private byte _maxGauge;
        private byte _gaugePerAttack;
        private TimeSpan _attackDelay;
        private TimeSpan _minAttackDelay;
        private TimeSpan _maxAttackDelay;
        private DateTime _lastAttack;

        //Modifiers are used to determine attribute values based on level.
        private Modifiers _modifiers;

        //The auto-attack skill to use against the combat target.
        private Skill _attackSkill;

        //The skills the entity can utilize once they reach the required level
        //based on specific skill.
        private HashSet<Skill> _skillSet;

        //Delegates for entity-related events.
        public delegate void NameChangedDelegate(string previousName, string newName);
        public delegate void LevelChangedDelegate(byte previousLevel, byte newLevel);
        public delegate void HpChangedDelegate(short previousHp, short newHp);
        public delegate void GaugeChangedDelegate(byte previousGauge, byte newGauge);

        //Triggers when the entity name changes.
        public event NameChangedDelegate NameChanged;
        //Triggers when the entity gains or loses a level.
        public event LevelChangedDelegate LevelChanged;
        //Triggers when the entity gains or loses Hp.
        public event HpChangedDelegate HpChanged;
        //Triggered when the entity gauge level changes.
        public event GaugeChangedDelegate GaugeChanged;

        protected Entity(string name, byte level, Modifiers modifiers)
        {
            this._name = name;
            this._modifiers = modifiers;
            this._maxLevel = 25;
            this._maxGauge = 100;
            this._attackSkill = new Attack();
            this._minAttackDelay = TimeSpan.FromMilliseconds(100);
            this._maxAttackDelay = TimeSpan.FromMilliseconds(10000);
            this.AttackDelay = TimeSpan.FromMilliseconds(1924);
            this.Level = level;
        }

        protected Entity(string name, byte level) :
            this(name, level, new Modifiers()) //Use defaults if none specified
        {
        }

        protected Entity(string name) : this(name, 1) //Default as level 1.
        {
        }

        protected Entity(byte level) : this("Entity", level) //Default "Entity" name
        {
        }

        protected Entity() : this(1) //Default as level 1.
        {
        }

        //The name of the entity, which is displayed
        //in the chatlog.
        public string Name
        {
            get { return this._name; }
            set
            {
                string previousName = this._name;
                this._name = value;

                //Call NameChanged after name has been changed.
                if (this.NameChanged != null && previousName != this._name)
                {
                    this.NameChanged(previousName, this._name);
                }
            }
        }

        //The entity level, which is used to calculate the
        //entity's attributes and unlock skills.
        public byte Level
        {
            get { return this._level; }
            set
            {
                //Store the current level before changing it.
                byte previousLevel = this._level;

                if (value > this.MaxLevel)
                {
                    //Restrict the level to the maximum level.
                    this._level = this.MaxLevel;
                }
                else if (value < 1)
                {
                    //Don't let the level fall below 1.
                    this._level = 1;
                }
                else
                {
                    this._level = value;
                }

                //Update the attributes to correspond with the new level.
                this.UpdateAttributes();

                //Call LevelChanged after new level has been updated.
                if (this.LevelChanged != null && previousLevel != this._level)
                {
                    this.LevelChanged(previousLevel, this._level);
                }

                //Refil Hp after level change.
                this.Hp = this._maxHp;
            }
        }

        //The maximum level the entity can reach.
        public byte MaxLevel
        {
            get { return this._maxLevel; }
            set
            {
                this._maxLevel = value;

                //Bring the entity's level down if it
                //exceeds the new max level.
                if (this.Level > value)
                {
                    this.Level = value;
                }
            }
        }

        //The health value used to determine whether or not
        //the entity was defeated in combat.
        public short Hp
        {
            get { return this._hp; }
            set
            {
                //Store the current Hp before changing it.
                short previousHp = this._hp;

                //Health cannot exceed the maximum health.
                if (value > this.MaxHp)
                {
                    this._hp = this.MaxHp;
                }
                //Do not let health drop below 0.
                else if (value < 0)
                {
                    this._hp = 0;
                }
                else
                {
                    this._hp = value;
                }

                //Trigger the HpChanged event once Hp has been updated.
                if (this.HpChanged != null && previousHp != this._hp)
                {
                    this.HpChanged(previousHp, this._hp);
                }
            }
        }

        //The maximum health value of the entity.
        public short MaxHp
        {
            get { return this._maxHp; }
        }

        //The attack value used to determine how much damage
        //the entity hits for based on a ratio with the
        //target's defense.
        public ushort Attack
        {
            get { return this._attack; }
        }

        //The defense value used to reduce damage taken
        //from an opponents attacks.
        public ushort Defense
        {
            get { return this._defense; }
        }

        //The gauge required for performing skills based
        //on their gauge cost.
        public byte Gauge
        {
            get { return this._gauge; }
            set
            {
                //Store the current gauge before changing it.
                byte previousGauge = this._gauge;

                //Restrict the gauge amount to the max gauge.
                if (value > this._maxGauge)
                {
                    this._gauge = this._maxGauge;
                }
                else
                {
                    this._gauge = value;
                }

                //Trigger the GaugeChanged event once the gauge has been updated.
                if (this.GaugeChanged != null && previousGauge != this._gauge)
                {
                    this.GaugeChanged(previousGauge, this._gauge);
                }
            }
        }

        //The maximum gauge value the entity can have.
        public byte MaxGauge
        {
            get { return this._maxGauge; }
        }

        //The amount of gauge points the entity receives per auto-attack.
        public byte GaugePerAttack
        {
            get { return this._gaugePerAttack; }
        }

        //The wait interval between the entity's auto-attacks.
        public TimeSpan AttackDelay
        {
            get { return this._attackDelay; }
            set
            {
                //Restrict the attack delay to the maximum attack delay.
                if (value >= this._maxAttackDelay)
                {
                    this._attackDelay = this._maxAttackDelay;
                }
                //Don't let the attack delay fall below the minimum attack delay.
                else if (value <= this._minAttackDelay)
                {
                    this._attackDelay = this._minAttackDelay;
                }
                else
                {
                    this._attackDelay = value;
                }

                //If the new AttackDelay value is 250 or lower,
                //restrict the GaugePerAttack value to 1.
                if (this._attackDelay.TotalMilliseconds <= 250)
                {
                    this._gaugePerAttack = 1;
                }
                else
                {
                    //Update the entity's gauge per hit value based on
                    //the AttackDelay value.
                    int gph =(int)Math.Pow(
                        this._attackDelay.TotalMilliseconds / 250, 1.45);

                    //Restrict the GaugePerAttack value to the maximum
                    //gauge value to prevent byte overflow.
                    if (gph > this.MaxGauge)
                    {
                        this._gaugePerAttack = this.MaxGauge;
                    }
                    //Don't let the GaugePerAttack fall below 1.
                    else if (gph <= 1)
                    {
                        this._gaugePerAttack = 1;
                    }
                    else
                    {
                        this._gaugePerAttack = (byte)gph;
                    }
                }
            }
        }

        //The highest the AttackDelay can be set to.
        public TimeSpan MaxAttackDelay
        {
            get { return this._maxAttackDelay; }
        }

        //The lowest the AttackDelay can be set to.
        public TimeSpan MinAttackDelay
        {
            get { return this._minAttackDelay; }
        }

        //The last time the entity performed an auto-attack.
        public DateTime LastAttack
        {
            get { return this._lastAttack; }
            set { this._lastAttack = value; }
        }

        //The entity's auto-attack skill, utilized for calculating
        //the damage dealt to the target.
        public Skill AttackSkill
        {
            get { return this._attackSkill; }
        }

        //The set of skills the entity will be able to use once
        //they reach the required level.
        public HashSet<Skill> SkillSet
        {
            get
            {
                //Initialize if null.
                if (this._skillSet == null)
                {
                    this._skillSet = new HashSet<Skill>();
                }

                return this._skillSet;
            }
            set { this._skillSet = value; }
        }

        //Update the entity's attributes based on level and modifiers.
        private void UpdateAttributes()
        {
            this._maxHp = (short)(this._modifiers.HpBase +
                Math.Pow(this._level, this._modifiers.HpExp) * this._modifiers.Hp);
            this._attack = (ushort)(this._modifiers.Attack * this._level);
            this._defense = (ushort)(this._modifiers.Defense * this._level);
        }

        //Performs the basic auto-attack against the target.
        public virtual void PerformAttack(Action<Skill, Entity, Entity> processSkill,
            Entity target)
        {
            //Only perform the auto-attack if the target has more than 0 HP
            //and the attack delay interval has past since the last attack.
            if (this._hp > 0 && target.Hp > 0 &&
                this._lastAttack.Add(this._attackDelay) <= DateTime.UtcNow)
            {
                //Perform the attack.
                processSkill(this._attackSkill, this, target);
                //Increase the gauge based on the entity's GaugePerAttack.
                this.Gauge += this.GaugePerAttack;
                //Update the last time the auto-attack was performed.
                this._lastAttack = DateTime.UtcNow;
            }
        }
    }
}
