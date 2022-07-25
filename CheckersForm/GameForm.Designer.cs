namespace CheckersForm
{
    using System.Windows.Forms;

    public partial class GameForm
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
            this.GamePanel = new System.Windows.Forms.Panel();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.P1ScoreLabel = new System.Windows.Forms.Label();
            this.P2ScoreLabel = new System.Windows.Forms.Label();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GamePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.GamePanel.Location = new System.Drawing.Point(55, 80);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(514, 520);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // Player1Label
            // 
            this.Player1Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player1Label.AutoSize = true;
            this.Player1Label.BackColor = System.Drawing.Color.Transparent;
            this.Player1Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Player1Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Player1Label.Location = new System.Drawing.Point(114, 12);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(72, 24);
            this.Player1Label.TabIndex = 1;
            this.Player1Label.Text = "Player1";
            // 
            // Player2Label
            // 
            this.Player2Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player2Label.AutoSize = true;
            this.Player2Label.BackColor = System.Drawing.Color.Transparent;
            this.Player2Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Player2Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Player2Label.Location = new System.Drawing.Point(477, 12);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(72, 24);
            this.Player2Label.TabIndex = 2;
            this.Player2Label.Text = "Player2";
            // 
            // P1ScoreLabel
            // 
            this.P1ScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.P1ScoreLabel.AutoSize = true;
            this.P1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1ScoreLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.P1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.P1ScoreLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.P1ScoreLabel.Location = new System.Drawing.Point(114, 35);
            this.P1ScoreLabel.Name = "P1ScoreLabel";
            this.P1ScoreLabel.Size = new System.Drawing.Size(20, 24);
            this.P1ScoreLabel.TabIndex = 3;
            this.P1ScoreLabel.Text = "0";
            // 
            // P2ScoreLabel
            // 
            this.P2ScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.P2ScoreLabel.AutoSize = true;
            this.P2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2ScoreLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.P2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.P2ScoreLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.P2ScoreLabel.Location = new System.Drawing.Point(477, 35);
            this.P2ScoreLabel.Name = "P2ScoreLabel";
            this.P2ScoreLabel.Size = new System.Drawing.Size(20, 24);
            this.P2ScoreLabel.TabIndex = 4;
            this.P2ScoreLabel.Text = "0";
            // 
            // TurnLabel
            // 
            this.TurnLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.BackColor = System.Drawing.Color.Transparent;
            this.TurnLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TurnLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TurnLabel.Location = new System.Drawing.Point(257, 12);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(0, 24);
            this.TurnLabel.TabIndex = 5;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 611);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.P2ScoreLabel);
            this.Controls.Add(this.P1ScoreLabel);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.GamePanel);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Checkers - Game on!";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel GamePanel;
        private Label Player1Label;
        private Label Player2Label;
        private Label P1ScoreLabel;
        private Label P2ScoreLabel;
        private Label TurnLabel;
    }
}