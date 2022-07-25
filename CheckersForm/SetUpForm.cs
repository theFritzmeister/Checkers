using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CheckersForm
{
    public partial class SetUpForm : Form
    {
        public int m_BoardSize { get; private set; }

        public SetUpForm()
        {
            InitializeComponent();
            m_BoardSize = 6;
        }

        private void SetUpForm_Load(object i_Sender, EventArgs i_E)
        {
        }

        private void checkBox1_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            if (checkBox1.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "Computer";
            }
        }

        private void Radio6_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            if (Radio6.Checked)
            {
                m_BoardSize = 6;
            }
        }

        private void Radio8_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            if (Radio8.Checked)
            {
                m_BoardSize = 8;
            }
        }

        private void Radio10_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            if (Radio10.Checked)
            {
                m_BoardSize = 10;
            }
        }

        private void Donebutton_Click(object i_Sender, EventArgs i_E)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_TextChanged_1(object i_Sender, EventArgs i_E)
        {
        }

        public string GetPlayer1()
        {
            return textBox1.Text;
        }

        public string GetPlayer2()
        {
            return textBox2.Text;
        }

        private void textBox1_Validating(object i_Sender, CancelEventArgs i_E)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                i_E.Cancel = true;
                textBox1.Focus();
                errorProvider.SetError(textBox1, "Please enter player 1 name.");
            }
            else
            {
                {
                    i_E.Cancel = false;
                    errorProvider.SetError(textBox1, null);
                }
            }
        }

        private void textBox2_Validating(object i_Sender, CancelEventArgs i_E)
        {
            if (checkBox1.Checked)
            {
                if ((textBox2.Text == "Computer" && checkBox1.Checked == true) || string.IsNullOrEmpty(textBox2.Text))
                {
                    i_E.Cancel = true;
                    textBox2.Focus();
                    errorProvider.SetError(textBox2, "Please enter player 2 name.");
                    return;
                }
            }

            i_E.Cancel = false;
            errorProvider.SetError(textBox2, null);
        }

        private void textBox2_TextChanged(object i_Sender, EventArgs i_E)
        {
        }
    }
}