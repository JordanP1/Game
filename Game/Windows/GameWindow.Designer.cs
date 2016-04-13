namespace Game
{
    partial class GameWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelGame = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBattleDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panelEnemy = new System.Windows.Forms.Panel();
            this.panelSkills = new System.Windows.Forms.Panel();
            this.richTextBoxScrollChatlog = new Game.RichTextBoxScroll(this.components);
            this.tableLayoutPanelGame.SuspendLayout();
            this.tableLayoutPanelBattleDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelGame
            // 
            this.tableLayoutPanelGame.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelGame.ColumnCount = 1;
            this.tableLayoutPanelGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGame.Controls.Add(this.tableLayoutPanelBattleDisplay, 0, 0);
            this.tableLayoutPanelGame.Controls.Add(this.richTextBoxScrollChatlog, 0, 1);
            this.tableLayoutPanelGame.Controls.Add(this.panelSkills, 0, 2);
            this.tableLayoutPanelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGame.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGame.Name = "tableLayoutPanelGame";
            this.tableLayoutPanelGame.RowCount = 3;
            this.tableLayoutPanelGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59F));
            this.tableLayoutPanelGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tableLayoutPanelGame.Size = new System.Drawing.Size(624, 441);
            this.tableLayoutPanelGame.TabIndex = 0;
            // 
            // tableLayoutPanelBattleDisplay
            // 
            this.tableLayoutPanelBattleDisplay.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelBattleDisplay.ColumnCount = 2;
            this.tableLayoutPanelBattleDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBattleDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBattleDisplay.Controls.Add(this.panelPlayer, 0, 0);
            this.tableLayoutPanelBattleDisplay.Controls.Add(this.panelEnemy, 1, 0);
            this.tableLayoutPanelBattleDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBattleDisplay.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelBattleDisplay.Name = "tableLayoutPanelBattleDisplay";
            this.tableLayoutPanelBattleDisplay.RowCount = 1;
            this.tableLayoutPanelBattleDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBattleDisplay.Size = new System.Drawing.Size(616, 194);
            this.tableLayoutPanelBattleDisplay.TabIndex = 0;
            // 
            // panelPlayer
            // 
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(4, 4);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(300, 186);
            this.panelPlayer.TabIndex = 0;
            // 
            // panelEnemy
            // 
            this.panelEnemy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnemy.Location = new System.Drawing.Point(311, 4);
            this.panelEnemy.Name = "panelEnemy";
            this.panelEnemy.Size = new System.Drawing.Size(301, 186);
            this.panelEnemy.TabIndex = 1;
            // 
            // panelSkills
            // 
            this.panelSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSkills.Location = new System.Drawing.Point(1, 342);
            this.panelSkills.Margin = new System.Windows.Forms.Padding(0);
            this.panelSkills.Name = "panelSkills";
            this.panelSkills.Size = new System.Drawing.Size(622, 98);
            this.panelSkills.TabIndex = 3;
            // 
            // richTextBoxScrollChatlog
            // 
            this.richTextBoxScrollChatlog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxScrollChatlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxScrollChatlog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxScrollChatlog.Location = new System.Drawing.Point(4, 205);
            this.richTextBoxScrollChatlog.Name = "richTextBoxScrollChatlog";
            this.richTextBoxScrollChatlog.ReadOnly = true;
            this.richTextBoxScrollChatlog.Size = new System.Drawing.Size(616, 133);
            this.richTextBoxScrollChatlog.TabIndex = 2;
            this.richTextBoxScrollChatlog.Text = "";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tableLayoutPanelGame);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.tableLayoutPanelGame.ResumeLayout(false);
            this.tableLayoutPanelBattleDisplay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBattleDisplay;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelEnemy;
        private RichTextBoxScroll richTextBoxScrollChatlog;
        private System.Windows.Forms.Panel panelSkills;
    }
}

