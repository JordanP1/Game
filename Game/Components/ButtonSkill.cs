using Game.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //A custom button used to hold its respective skill.

    public partial class ButtonSkill : Button
    {
        private Skill _skill;

        public ButtonSkill()
        {
            InitializeComponent();
        }

        public ButtonSkill(Skill skill) : this()
        {
            this._skill = skill;
        }

        public ButtonSkill(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Skill Skill
        {
            get { return this._skill; }
        }
    }
}
