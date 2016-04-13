namespace Game
{
    partial class EntityControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxEntity = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelEntityControl = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarHP = new ProgressBarInfo(this.components);
            this.tableLayoutPanelStats = new System.Windows.Forms.TableLayoutPanel();
            this.labelDefense = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelAttack = new System.Windows.Forms.Label();
            this.labelLevelCap = new System.Windows.Forms.Label();
            this.labelHP = new System.Windows.Forms.Label();
            this.labelGauge = new System.Windows.Forms.Label();
            this.progressBarGauge = new ProgressBarInfo(this.components);
            this.groupBoxEntity.SuspendLayout();
            this.tableLayoutPanelEntityControl.SuspendLayout();
            this.tableLayoutPanelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEntity
            // 
            this.groupBoxEntity.Controls.Add(this.tableLayoutPanelEntityControl);
            this.groupBoxEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEntity.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEntity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEntity.Name = "groupBoxEntity";
            this.groupBoxEntity.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxEntity.Size = new System.Drawing.Size(270, 188);
            this.groupBoxEntity.TabIndex = 1;
            this.groupBoxEntity.TabStop = false;
            this.groupBoxEntity.Text = "Entity";
            // 
            // tableLayoutPanelEntityControl
            // 
            this.tableLayoutPanelEntityControl.ColumnCount = 1;
            this.tableLayoutPanelEntityControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEntityControl.Controls.Add(this.progressBarHP, 0, 2);
            this.tableLayoutPanelEntityControl.Controls.Add(this.tableLayoutPanelStats, 0, 0);
            this.tableLayoutPanelEntityControl.Controls.Add(this.labelHP, 0, 1);
            this.tableLayoutPanelEntityControl.Controls.Add(this.labelGauge, 0, 3);
            this.tableLayoutPanelEntityControl.Controls.Add(this.progressBarGauge, 0, 4);
            this.tableLayoutPanelEntityControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEntityControl.Location = new System.Drawing.Point(10, 25);
            this.tableLayoutPanelEntityControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanelEntityControl.Name = "tableLayoutPanelEntityControl";
            this.tableLayoutPanelEntityControl.RowCount = 6;
            this.tableLayoutPanelEntityControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanelEntityControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanelEntityControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelEntityControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanelEntityControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelEntityControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanelEntityControl.Size = new System.Drawing.Size(250, 153);
            this.tableLayoutPanelEntityControl.TabIndex = 3;
            // 
            // progressBarHP
            // 
            this.progressBarHP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarHP.Location = new System.Drawing.Point(3, 78);
            this.progressBarHP.Name = "progressBarHP";
            this.progressBarHP.Size = new System.Drawing.Size(244, 22);
            this.progressBarHP.TabIndex = 7;
            // 
            // tableLayoutPanelStats
            // 
            this.tableLayoutPanelStats.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelStats.ColumnCount = 2;
            this.tableLayoutPanelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelStats.Controls.Add(this.labelDefense, 1, 1);
            this.tableLayoutPanelStats.Controls.Add(this.labelLevel, 0, 0);
            this.tableLayoutPanelStats.Controls.Add(this.labelAttack, 0, 1);
            this.tableLayoutPanelStats.Controls.Add(this.labelLevelCap, 1, 0);
            this.tableLayoutPanelStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStats.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanelStats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanelStats.Name = "tableLayoutPanelStats";
            this.tableLayoutPanelStats.RowCount = 2;
            this.tableLayoutPanelStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelStats.Size = new System.Drawing.Size(244, 50);
            this.tableLayoutPanelStats.TabIndex = 2;
            // 
            // labelDefense
            // 
            this.labelDefense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDefense.AutoSize = true;
            this.labelDefense.Location = new System.Drawing.Point(135, 29);
            this.labelDefense.Name = "labelDefense";
            this.labelDefense.Size = new System.Drawing.Size(94, 16);
            this.labelDefense.TabIndex = 1;
            this.labelDefense.Text = "Defense: {0}";
            // 
            // labelLevel
            // 
            this.labelLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(24, 4);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(74, 16);
            this.labelLevel.TabIndex = 0;
            this.labelLevel.Text = "Level: {0}";
            // 
            // labelAttack
            // 
            this.labelAttack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAttack.AutoSize = true;
            this.labelAttack.Location = new System.Drawing.Point(21, 29);
            this.labelAttack.Name = "labelAttack";
            this.labelAttack.Size = new System.Drawing.Size(79, 16);
            this.labelAttack.TabIndex = 0;
            this.labelAttack.Text = "Attack: {0}";
            // 
            // labelLevelCap
            // 
            this.labelLevelCap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLevelCap.AutoSize = true;
            this.labelLevelCap.Location = new System.Drawing.Point(129, 4);
            this.labelLevelCap.Name = "labelLevelCap";
            this.labelLevelCap.Size = new System.Drawing.Size(106, 16);
            this.labelLevelCap.TabIndex = 1;
            this.labelLevelCap.Text = "Level Cap: {0}";
            // 
            // labelHP
            // 
            this.labelHP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelHP.AutoSize = true;
            this.labelHP.Location = new System.Drawing.Point(3, 56);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(29, 16);
            this.labelHP.TabIndex = 4;
            this.labelHP.Text = "HP";
            // 
            // labelGauge
            // 
            this.labelGauge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelGauge.AutoSize = true;
            this.labelGauge.Location = new System.Drawing.Point(3, 105);
            this.labelGauge.Name = "labelGauge";
            this.labelGauge.Size = new System.Drawing.Size(54, 16);
            this.labelGauge.TabIndex = 5;
            this.labelGauge.Text = "Gauge";
            // 
            // progressBarGauge
            // 
            this.progressBarGauge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGauge.Location = new System.Drawing.Point(3, 127);
            this.progressBarGauge.Name = "progressBarGauge";
            this.progressBarGauge.Size = new System.Drawing.Size(244, 22);
            this.progressBarGauge.TabIndex = 6;
            // 
            // EntityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxEntity);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntityControl";
            this.Size = new System.Drawing.Size(270, 188);
            this.groupBoxEntity.ResumeLayout(false);
            this.tableLayoutPanelEntityControl.ResumeLayout(false);
            this.tableLayoutPanelEntityControl.PerformLayout();
            this.tableLayoutPanelStats.ResumeLayout(false);
            this.tableLayoutPanelStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEntity;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEntityControl;
        private System.Windows.Forms.Label labelLevelCap;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Label labelDefense;
        private System.Windows.Forms.Label labelAttack;
        private System.Windows.Forms.Label labelGauge;
        private ProgressBarInfo progressBarGauge;
        private ProgressBarInfo progressBarHP;
    }
}
