namespace Game
{
    partial class SkillsControl
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
            this.groupBoxSkills = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelSkillButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSkills
            // 
            this.groupBoxSkills.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxSkills.Controls.Add(this.flowLayoutPanelSkillButtons);
            this.groupBoxSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSkills.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSkills.Name = "groupBoxSkills";
            this.groupBoxSkills.Size = new System.Drawing.Size(308, 169);
            this.groupBoxSkills.TabIndex = 0;
            this.groupBoxSkills.TabStop = false;
            this.groupBoxSkills.Text = "Skills";
            // 
            // flowLayoutPanelSkillButtons
            // 
            this.flowLayoutPanelSkillButtons.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanelSkillButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSkillButtons.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanelSkillButtons.Name = "flowLayoutPanelSkillButtons";
            this.flowLayoutPanelSkillButtons.Size = new System.Drawing.Size(302, 148);
            this.flowLayoutPanelSkillButtons.TabIndex = 0;
            // 
            // SkillsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxSkills);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SkillsControl";
            this.Size = new System.Drawing.Size(308, 169);
            this.groupBoxSkills.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSkills;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSkillButtons;
    }
}
