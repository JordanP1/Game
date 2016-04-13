using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //The GameBase, which holds important instances such as
    //the player, chatlog, and battle simulator.
    //An instance of the GameBase can be passed to other
    //classes, which grants them easy access to vital
    //components of the game.

    public class GameBase
    {
        private Chatlog _chatlog;
        private Player _player;
        private BattleSimulator _battleSimulator;

        public GameBase(RichTextBoxScroll textBox)
        {
            this._chatlog = new Chatlog(textBox);
            this._player = new Player();
            this._battleSimulator = new BattleSimulator(this);
        }

        //The chatlog for printing text out to.
        public Chatlog Chatlog { get { return this._chatlog; } }

        //The player the user plays as during combat.
        public Player Player { get { return this._player; } }

        //The battle simulator, which handles and controls the flow of combat.
        public BattleSimulator BattleSimulator { get { return this._battleSimulator; } }
    }
}
