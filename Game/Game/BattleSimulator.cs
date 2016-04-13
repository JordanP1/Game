using Game.Entities;
using Game.Skills;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //The BattleSimulator controls the flow of combat between
    //the player and the enemy.

    public class BattleSimulator
    {
        //The GameBase to access the player and chatlog instance.
        private GameBase _game;
        //Create an easy to access chatlog and player instance without
        //having to constantly access it through GameBase.
        private Chatlog _chatlog;
        private Player _player;
        private Enemy _enemy;
        //A timer to constantly update and execute
        //battle-related methods.
        private Timer _battleTimer;

        //Called when a new battle has started.
        public delegate void NewBattleDelegate();
        public event NewBattleDelegate NewBattle;

        public BattleSimulator(GameBase game)
        {
            this._game = game;
            this._chatlog = game.Chatlog;
            this._player = game.Player;
            this._player.LevelChanged += _player_LevelChanged;
            this._battleTimer = new Timer();
            this._battleTimer.Tick += _battleTimer_Tick;
        }

        //An instance of the enemy the player faces off against in combat.
        public Enemy Enemy { get { return this._enemy; } }

        //When the player's level changes, notify the user via the chatlog.
        private void _player_LevelChanged(byte previousLevel, byte newLevel)
        {
            //A level was gained.
            if (newLevel > previousLevel)
            {
                this._chatlog.WriteLine("Level Up!!", Color.Yellow);
                this._chatlog.WriteLine(string.Format("{0} has reached level {1}!",
                    this._player.Name, this._player.Level), Color.Yellow);
            }
            //A level was lost.
            else
            {
                this._chatlog.WriteLine("Level Down...", Color.LightGoldenrodYellow);
                this._chatlog.WriteLine(string.Format("{0} falls to level {1}.",
                    this._player.Name, this._player.Level), Color.LightGoldenrodYellow);
            }
        }

        //Execute a skill if requirements are met.
        public void ProcessSkill(Skill skill, Entity user, Entity target)
        {
            //User's gauge must be equal or greater to the
            //skill's gauge cost.
            if (user.Gauge < skill.Gauge) { return; }

            //If the skill's target type is self,
            //set the target to user.
            if (skill.Target == Target.Self)
            {
                target = user;
            }

            //Deplete the user's gauge from the skill's gauge cost.
            user.Gauge -= skill.Gauge;

            //Calculate the damage based on user and target attributes.
            short damage = skill.GetDamage(user, target);
            //Reflect the damage result to the target's HP.
            target.Hp -= damage;

            //If the damage is greater than 0, it damaged the target.
            if (damage > 0)
            {
                Color color;

                //Color determined if the target is
                //the player or the enemy.
                if (target == this._player)
                {
                    color = Color.OrangeRed;
                }
                else
                {
                    color = Color.Orange;
                }

                //Print the result to the chatlog.
                this._chatlog.WriteLine(string.Format(
                    "{0}'s {1} deals {2} damage to {3}.",
                    user.Name, skill.Name, damage, target.Name), color);
            }
            //If the damage is less than 0, it healed the target.
            else if (damage < 0)
            {
                Color color;

                //Color determined if the target is
                //the player or the enemy.
                if (target == this._player)
                {
                    color = Color.LightBlue;
                }
                else
                {
                    color = Color.DeepSkyBlue;
                }

                //Print the result to the chatlog.
                this._chatlog.WriteLine(string.Format(
                    "{0}'s {1} causes {2} to recover {3} HP.",
                    user.Name, skill.Name, target.Name, -damage), color);
            }
            //If the damage is 0, it had no effect on the target.
            else
            {
                //Print the result to the chatlog.
                this._chatlog.WriteLine(string.Format(
                    "{0}'s {1} has absolutely no effect on {2}!",
                    user.Name, skill.Name, target.Name), Color.Gray);
            }
        }

        //Overload to shorten the call to pass in a skill
        //and trigger it with the player as the user and
        //the enemy as the target.
        public void ProcessSkill(Skill skill)
        {
            this.ProcessSkill(skill, this._player, this._enemy);
        }

        //Initialize the battle.
        private void Initialize()
        {
            //Player initialization.
            //Refil the player's HP.
            this._player.Hp = this._player.MaxHp;
            //Reset the player's gauge level.
            this._player.Gauge = 0;
            //Set the player's next attack based on half of their attack delay,
            //that way there is a short delay after the battle starts.
            this._player.LastAttack =
                DateTime.UtcNow.AddMilliseconds(this._player.AttackDelay.TotalMilliseconds / 2);

            //Enemy initialization.
            this._enemy = new Enemy(this._player.Level);
            //Set the enemy's next attack based on half of their attack delay,
            //that way there is a short delay after the battle starts.
            this._enemy.LastAttack =
                DateTime.UtcNow.AddMilliseconds(this._enemy.AttackDelay.TotalMilliseconds / 2);

            //Print out to the chatlog that the battle has started.
            this._chatlog.WriteLine("=== Battle Start! ===", Color.Red);

            //Call the NewBattle event.
            this.NewBattle?.Invoke();
        }

        //Used to start the BattleSimulator.
        public void Start()
        {
            if (!this._battleTimer.Enabled)
            {
                //Initialize the player and enemy.
                this.Initialize();
                //Start the battle.
                this._battleTimer.Start();
            }
        }

        //Used to stop the BattleSimulator.
        public void Stop()
        {
            //Stop the battle.
            this._battleTimer.Stop();
            //Delete the enemy.
            this._enemy = null;
        }

        //Used to update and execute battle-related features,
        //controlling the overall flow of battle.
        private void _battleTimer_Tick(object sender, EventArgs e)
        {
            //Trigger the player's auto-attack method.
            this._player.PerformAttack(this.ProcessSkill, this._enemy);

            //Check to see if the auto-attack defeated the enemy.
            if (this._enemy.Hp <= 0)
            {
                //Print out the enemy's defeat.
                this._chatlog.WriteLine(string.Format("{0} was defeated!", this._enemy.Name), Color.IndianRed);

                //Increase the player's level if they haven't yet
                //reached their maximum level.
                if (this._player.Level < this._player.MaxLevel)
                {
                    this._player.Level++;
                }

                //Start another battle and print out to the chatlog.
                this._chatlog.WriteLine("Another enemy approaches.");
                this.Initialize();
                return;
            }

            //Trigger the enemy's auto-attack method.
            this._enemy.PerformAttack(this.ProcessSkill, this._player);

            //Check to see if the auto-attack felled the player.
            if (this._player.Hp <= 0)
            {
                //Print out the player's defeat.
                this._chatlog.WriteLine(string.Format("{0} has fallen!", this._player.Name), Color.DarkRed);

                //Restart the fight, printing out to the chatlog.
                this._chatlog.WriteLine("Restarting fight...");
                this.Initialize();
                return;
            }
        }
    }
}
