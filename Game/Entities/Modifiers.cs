using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    //Modifiers used in a calculation to determine the
    //entity's attributes.

    public class Modifiers
    {
        private short _hpBase;
        private float _hp;
        private float _hpExp;
        private float _attack;
        private float _defense;

        public Modifiers(short hpBase, float hp, float hpExp, float attack, float defense)
        {
            this._hpBase = hpBase;
            this._hp = hp;
            this._hpExp = hpExp;
            this._attack = attack;
            this._defense = defense;
        }

        public Modifiers() : this(23, 15.32f, 1.56f, 5.13f, 5.22f) //Default modifiers.
        {
        }

        //The entity's base HP added on to the final
        //calculation result.
        public short HpBase
        {
            get { return this._hpBase; }
        }

        //The HP multiplier.
        public float Hp
        {
            get { return this._hp; }
        }

        //The HP's exponential multiplier value.
        public float HpExp
        {
            get { return this._hpExp; }
        }

        //The attack multiplier.
        public float Attack
        {
            get { return this._attack; }
        }

        //The defense multiplier.
        public float Defense
        {
            get { return this._defense; }
        }
    }
}
