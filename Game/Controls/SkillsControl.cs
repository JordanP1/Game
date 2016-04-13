using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game.Entities;
using Game.Skills;

namespace Game
{
    //A control to display and handle the player's skills.

    public partial class SkillsControl : UserControl
    {
        private GameBase _game;
        private Player _player;
        private Chatlog _chatlog;
        //A collection of accessible skills to the player.
        private Dictionary<Skill, ButtonSkill> _skillButtons;

        public SkillsControl()
        {
            InitializeComponent();
        }

        public SkillsControl(GameBase game) : this()
        {
            this._game = game;
            this._player = game.Player;
            this._chatlog = game.Chatlog;
            this._player.LevelChanged += _player_LevelChanged;
            this._player.GaugeChanged += _player_GaugeChanged;
            this._skillButtons = new Dictionary<Skill, ButtonSkill>();
            //Initial update once control is initialized.
            this.UpdateDisplayableSkills();
        }

        //Level change can mean the player either gained or lost a level.
        private void _player_LevelChanged(byte previousLevel, byte newLevel)
        {
            this.UpdateDisplayableSkills();
        }

        //Update whether or not the skill button is enabled or disabled
        //based on player's gauge level and skill gauge cost.
        private void _player_GaugeChanged(byte previousGauge, byte newGauge)
        {
            this.UpdateSkillButtonClickable();
        }

        //Adds or removes skill buttons based on player's
        //level and the skill level.
        private void UpdateDisplayableSkills()
        {
            //Verify each skill in the player's skill set.
            foreach (Skill skill in this._player.SkillSet)
            {
                //Player meets the level requirements for the skill.
                if (this._player.Level >= skill.Level)
                {
                    this.AddSkill(skill);
                }
                //Player does not meet the level requirements for the skill.
                else
                {
                    this.RemoveSkill(skill);
                }
            }
        }

        //Add a skill to the control.
        private void AddSkill(Skill skill)
        {
            //Check if skill button hasn't already been added.
            if (!this._skillButtons.ContainsKey(skill))
            {
                //Create the button.
                ButtonSkill btn = new ButtonSkill(skill);
                btn.Padding = new Padding(3);
                btn.Text = skill.ToString();
                btn.BackColor = SystemColors.ButtonFace;
                btn.Click += SkillBtn_Click;
                btn.Padding = new Padding(3);
                btn.AutoEllipsis = false;
                btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btn.AutoSize = true;

                //Add the button to the control and dictionary.
                this.flowLayoutPanelSkillButtons.Controls.Add(btn);
                this._skillButtons.Add(skill, btn);

                //Print out to the chatlog to alert the player of a
                //newly acquired skill.
                this._chatlog.WriteLine(string.Format("{0} learns the skill: ",
                    this._player.Name), Color.Yellow);
                this._chatlog.WriteString(string.Format("{0}", skill.Name), Color.LimeGreen);
                this._chatlog.WriteString("!", Color.Yellow);
            }
        }

        //Remove a skill from the control.
        private void RemoveSkill(Skill skill)
        {
            //Check if skill button has been added.
            if (this._skillButtons.ContainsKey(skill))
            {
                //Remove the button from the control and dictionary.
                Button skillBtn = this._skillButtons[skill];
                this.flowLayoutPanelSkillButtons.Controls.Remove(skillBtn);
                this._skillButtons.Remove(skill);
                //Dispose of the button to free memory.
                skillBtn.Dispose();

                //Print out to the chatlog to alert the player of a
                //recently unlearned skill.
                this._chatlog.WriteLine(string.Format("{0} forgets the skill: ",
                    this._player.Name), Color.Yellow);
                this._chatlog.WriteString(string.Format("{0}", skill.Name), Color.LimeGreen);
                this._chatlog.WriteString("!", Color.Yellow);
            }
        }

        //Trigger the skill against the enemy.
        private void SkillBtn_Click(object sender, EventArgs e)
        {
            ButtonSkill btn = sender as ButtonSkill;
            this._game.BattleSimulator.ProcessSkill(btn.Skill);
        }

        //Enable or disable skill buttons based on gauge sufficiency.
        private void UpdateSkillButtonClickable()
        {
            foreach (ButtonSkill btn in this.flowLayoutPanelSkillButtons.Controls)
            {
                btn.Enabled = this._player.Gauge >= btn.Skill.Gauge;
            }
        }
    }
}
