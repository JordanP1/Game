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

namespace Game
{
    //A control to display updated information about an entity.

    public partial class EntityControl : UserControl
    {
        //The entity to display information on.
        private Entity _entity;

        //Formatters used in string.Format().
        private static string _levelFormat;
        private static string _levelCapFormat;
        private static string _attackFormat;
        private static string _defenseFormat;

        public EntityControl()
        {
            InitializeComponent();

            //Grab the formatting stored in the labels from
            //design mode (on the EntityControl.cs form).
            _levelFormat = this.labelLevel.Text;
            _levelCapFormat = this.labelLevelCap.Text;
            _attackFormat = this.labelAttack.Text;
            _defenseFormat = this.labelDefense.Text;
        }

        public EntityControl(Entity entity) : this()
        {
            this.SetEntity(entity);
        }

        //The entity to display information on.
        public Entity Entity
        {
            get { return this._entity; }
            set { this.SetEntity(value); }
        }

        public void SetEntity(Entity entity)
        {
            //Store the entity for later access.
            this._entity = entity;

            //Update the control with the new entity.
            this.UpdateAll();

            //Subscribe to events to reflect changes in
            //entity attributes.
            this._entity.NameChanged += _entity_NameChanged;
            this._entity.LevelChanged += _entity_LevelChanged;
            this._entity.HpChanged += _entity_HpChanged;
            this._entity.GaugeChanged += _entity_GaugeChanged;
        }

        #region Event Methods
        //Update the name if changed.
        private void _entity_NameChanged(string previousName, string newName)
        {
            this.UpdateNameChanged();
        }

        //Update all of the necessary attributes on level change.
        private void _entity_LevelChanged(byte previousLevel, byte newLevel)
        {
            this.UpdateLevelChanged();
        }

        //Keep the entity's current Hp display updated.
        private void _entity_HpChanged(short previousHp, short newHp)
        {
            this.UpdateHpChanged();
        }

        //Update the gauge bar when entity gains or loses gauge.
        private void _entity_GaugeChanged(byte previousGauge, byte newGauge)
        {
            this.UpdateGaugeChanged();
        }
        #endregion

        #region Update Methods
        //Update the name label.
        private void UpdateNameChanged()
        {
            this.groupBoxEntity.Text = this._entity.Name;
        }

        //Update all level-related attributes.
        private void UpdateLevelChanged()
        {
            this.labelLevel.Text = string.Format(_levelFormat, this._entity.Level);
            this.labelLevelCap.Text = string.Format(_levelCapFormat, this._entity.MaxLevel);
            this.labelAttack.Text = string.Format(_attackFormat, this._entity.Attack);
            this.labelDefense.Text = string.Format(_defenseFormat, this._entity.Defense);
            this.progressBarHP.Maximum = this._entity.MaxHp;
        }

        //Update Hp.
        private void UpdateHpChanged()
        {
            this.progressBarHP.Value = this._entity.Hp;
        }

        //Update the gauge.
        private void UpdateGaugeChanged()
        {
            this.progressBarGauge.Maximum = this._entity.MaxGauge;
            this.progressBarGauge.Value = this._entity.Gauge;
        }

        //Update everything at once.
        private void UpdateAll()
        {
            this.UpdateNameChanged();
            this.UpdateLevelChanged();
            this.UpdateHpChanged();
            this.UpdateGaugeChanged();
        }
        #endregion
    }
}
