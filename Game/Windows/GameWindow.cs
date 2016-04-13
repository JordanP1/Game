using Game.Entities;
using Game.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //The main game window, which displays the entirety of the game
    //such as player and enemy attributes, the chatlog, and the
    //skills window.

    public partial class GameWindow : Form
    {
        //The GameBase, used to access important instances such
        //as the player or the chatlog.
        private GameBase _game;

        //HUD controls to display player and enemy attributes.
        private EntityControl _playerControl;
        private EntityControl _enemyControl;
        //A player control used for displaying and executing skills.
        private SkillsControl _skillsControl;

        public GameWindow()
        {
            InitializeComponent();

            //Initialize the GameBase.
            this._game = new GameBase(this.richTextBoxScrollChatlog);
            //Subscribe to the NewBattle event so we know when a new
            //battle has begun.
            this._game.BattleSimulator.NewBattle += BattleSimulator_NewBattle;
            //Initialize the skills control and add it to panelSkills.
            this._skillsControl = new SkillsControl(this._game);
            this._skillsControl.Dock = DockStyle.Fill;
            this.panelSkills.Controls.Add(this._skillsControl);

            //Start the BattleSimulator, which will control
            //the flow of combat.
            this._game.BattleSimulator.Start();
        }

        //Alerts us of when a battle has been recently started.
        private void BattleSimulator_NewBattle()
        {
            //Initialize the player HUD display when a new battle
            //starts if it hasn't been initialized yet.
            if (this._playerControl == null)
            {
                this._playerControl = new EntityControl(this._game.Player);
                this._playerControl.Dock = DockStyle.Fill;
                this.panelPlayer.Controls.Clear();
                this.panelPlayer.Controls.Add(this._playerControl);
            }

            //Initialize the enemy HUD display when a new battle
            //starts if it hasn't been initialized yet.
            if (this._enemyControl == null)
            {
                this._enemyControl = new EntityControl(this._game.BattleSimulator.Enemy);
                this._enemyControl.Dock = DockStyle.Fill;
                this.panelEnemy.Controls.Clear();
                this.panelEnemy.Controls.Add(this._enemyControl);
            }
            //Otherwise, pass in the new entity that was created
            //for this new battle, replacing the previous one.
            else
            {
                this._enemyControl.SetEntity(this._game.BattleSimulator.Enemy);
            }
        }
    }
}
