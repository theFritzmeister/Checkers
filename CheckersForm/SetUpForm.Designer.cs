namespace CheckersForm
{
    using System.Windows.Forms;

    public partial class SetUpForm
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
            this.Donebutton = new System.Windows.Forms.Button();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.BoardLabel = new System.Windows.Forms.Label();
            this.Radio6 = new System.Windows.Forms.RadioButton();
            this.Radio8 = new System.Windows.Forms.RadioButton();
            this.Radio10 = new System.Windows.Forms.RadioButton();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.P1Label = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Donebutton
            // 
            this.Donebutton.Location = new System.Drawing.Point(351, 218);
            this.Donebutton.Name = "Donebutton";
            this.Donebutton.Size = new System.Drawing.Size(64, 20);
            this.Donebutton.TabIndex = 0;
            this.Donebutton.Text = "Done";
            this.Donebutton.UseVisualStyleBackColor = true;
            this.Donebutton.Click += new System.EventHandler(this.Donebutton_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeLabel.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Italic);
            this.WelcomeLabel.ForeColor = System.Drawing.Color.Crimson;
            this.WelcomeLabel.Location = new System.Drawing.Point(100, 8);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(256, 27);
            this.WelcomeLabel.TabIndex = 1;
            this.WelcomeLabel.Text = "Welcome to checkers";
            // 
            // BoardLabel
            // 
            this.BoardLabel.AutoSize = true;
            this.BoardLabel.BackColor = System.Drawing.Color.Transparent;
            this.BoardLabel.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.BoardLabel.ForeColor = System.Drawing.Color.White;
            this.BoardLabel.Location = new System.Drawing.Point(100, 48);
            this.BoardLabel.Name = "BoardLabel";
            this.BoardLabel.Size = new System.Drawing.Size(106, 24);
            this.BoardLabel.TabIndex = 2;
            this.BoardLabel.Text = "Board size:";
            // 
            // Radio6
            // 
            this.Radio6.AutoSize = true;
            this.Radio6.BackColor = System.Drawing.Color.Transparent;
            this.Radio6.Checked = true;
            this.Radio6.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.Radio6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Radio6.Location = new System.Drawing.Point(100, 80);
            this.Radio6.Name = "Radio6";
            this.Radio6.Size = new System.Drawing.Size(58, 28);
            this.Radio6.TabIndex = 3;
            this.Radio6.TabStop = true;
            this.Radio6.Text = "6x6";
            this.Radio6.UseVisualStyleBackColor = false;
            this.Radio6.CheckedChanged += new System.EventHandler(this.Radio6_CheckedChanged);
            // 
            // Radio8
            // 
            this.Radio8.AutoSize = true;
            this.Radio8.BackColor = System.Drawing.Color.Transparent;
            this.Radio8.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.Radio8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Radio8.Location = new System.Drawing.Point(169, 80);
            this.Radio8.Name = "Radio8";
            this.Radio8.Size = new System.Drawing.Size(60, 28);
            this.Radio8.TabIndex = 4;
            this.Radio8.Text = "8x8";
            this.Radio8.UseVisualStyleBackColor = false;
            this.Radio8.CheckedChanged += new System.EventHandler(this.Radio8_CheckedChanged);
            // 
            // Radio10
            // 
            this.Radio10.AutoSize = true;
            this.Radio10.BackColor = System.Drawing.Color.Transparent;
            this.Radio10.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.Radio10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Radio10.Location = new System.Drawing.Point(238, 80);
            this.Radio10.Name = "Radio10";
            this.Radio10.Size = new System.Drawing.Size(76, 28);
            this.Radio10.TabIndex = 5;
            this.Radio10.Text = "10x10";
            this.Radio10.UseVisualStyleBackColor = false;
            this.Radio10.CheckedChanged += new System.EventHandler(this.Radio10_CheckedChanged);
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayersLabel.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.PlayersLabel.ForeColor = System.Drawing.Color.White;
            this.PlayersLabel.Location = new System.Drawing.Point(100, 107);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(80, 24);
            this.PlayersLabel.TabIndex = 6;
            this.PlayersLabel.Text = "Players:";
            // 
            // P1Label
            // 
            this.P1Label.AutoSize = true;
            this.P1Label.BackColor = System.Drawing.Color.Transparent;
            this.P1Label.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.P1Label.ForeColor = System.Drawing.Color.White;
            this.P1Label.Location = new System.Drawing.Point(100, 127);
            this.P1Label.Name = "P1Label";
            this.P1Label.Size = new System.Drawing.Size(84, 24);
            this.P1Label.TabIndex = 7;
            this.P1Label.Text = "Player 1:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(85, 151);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(108, 28);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Player 2:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(188, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Computer";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SetUpForm
            // 
            this.AcceptButton = this.Donebutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::CheckersForm.Properties.Resources.CheckerFlag;
            this.ClientSize = new System.Drawing.Size(423, 249);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.P1Label);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Radio10);
            this.Controls.Add(this.Radio8);
            this.Controls.Add(this.Radio6);
            this.Controls.Add(this.BoardLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.Donebutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetUpForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Checkers set-up";
            this.Load += new System.EventHandler(this.SetUpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Donebutton;
        private Label WelcomeLabel;
        private Label BoardLabel;
        private RadioButton Radio6;
        private RadioButton Radio8;
        private RadioButton Radio10;
        private Label PlayersLabel;
        private Label P1Label;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private ErrorProvider errorProvider;
    }
}