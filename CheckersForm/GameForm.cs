using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CheckersAI;
using CheckersEngine;

namespace CheckersForm
{
    public partial class GameForm : Form
    {
        private readonly List<Player> r_Players;
        private int m_BoardSize;
        private Board m_Board;
        private CheckerPictureBox[,] m_PictureBox;
        private Point[] m_Coordinates;
        private bool m_IsFrom = true;

        public GameForm()
        {
            m_Board = null;
            r_Players = new List<Player>();
            m_Coordinates = new Point[2];
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void GameForm_Load(object i_Sender, EventArgs i_EventArgs)
        {
            SetUpForm setUpForm = new SetUpForm();
            if (setUpForm.ShowDialog() == DialogResult.OK)
            {
                r_Players.Add(new Player(setUpForm.GetPlayer1()));
                r_Players.Add(new Player(setUpForm.GetPlayer2()));
                Player1Label.Text = r_Players[0].m_Name;
                Player2Label.Text = r_Players[1].m_Name;
                TurnLabel.Text = $"{r_Players[0].m_Name}'s turn";
                m_BoardSize = setUpForm.m_BoardSize;
                m_Board = new Board(m_BoardSize);
                m_Board.InitializeBoard();
                this.TurnLabel.Anchor = AnchorStyles.Top;
                
                if (m_BoardSize == 10)
                {
                    this.Size = new Size(750, 800);
                }

                this.GamePanel.Size = new Size(60 * m_BoardSize, 60 * m_BoardSize);
                this.GamePanel.Location = new System.Drawing.Point(
                    (ClientSize.Width / 2) - (GamePanel.Size.Width / 2),
                    (ClientSize.Height / 2) - (GamePanel.Size.Height / 2));
                m_PictureBox = new CheckerPictureBox[m_BoardSize, m_BoardSize];
                int left = 2, top = 2;
                for (int i = 0; i < m_BoardSize; i++)
                {
                    left = 2;
                    for (int j = 0; j < m_BoardSize; j++)
                    {
                        m_PictureBox[i, j] = new CheckerPictureBox();
                        Color boxColor;
                        if ((i + j) % 2 == 0)
                        {
                            boxColor = Color.White;
                            m_PictureBox[i, j].Enabled = false;
                        }
                        else
                        {
                            boxColor = Color.Black;
                        }

                        m_PictureBox[i, j].BackColor = boxColor;
                        m_PictureBox[i, j].Location = new Point(left, top);
                        m_PictureBox[i, j].Size = new Size(60, 60);
                        m_PictureBox[i, j].BoardLocation = new Point(i, j);
                        m_PictureBox[i, j].Click += onBoxClicked;

                        left += 60;
                        GamePanel.Controls.Add(m_PictureBox[i, j]);
                    }

                    top += 60;
                }

                DrawBoard();
                this.BackgroundImage = Properties.Resources.panel;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                this.Close();
            }
        }

        private void highlightBox(object i_Sender, PaintEventArgs i_EventArgs)
        {
            CheckerPictureBox box = i_Sender as CheckerPictureBox;
            Rectangle rectangle = new Rectangle(0, 0, 60, 60);
            Pen bluePen = new Pen(Color.DeepSkyBlue, 5);
            i_EventArgs.Graphics.DrawRectangle(bluePen, rectangle);
        }

        private void onBoxClicked(object i_Sender, EventArgs i_EventArgs)
        {
            CheckerPictureBox box = i_Sender as CheckerPictureBox;
            int row = box.BoardLocation.X;
            int col = box.BoardLocation.Y;

            if (m_IsFrom)
            {
                m_PictureBox[row, col].Paint += new PaintEventHandler(highlightBox);
                m_PictureBox[row, col].Refresh();
            }
            else
            {
                if (m_Coordinates[0] == new Point(row, col))
                {
                    m_IsFrom = true;
                    DrawBoard();
                    return;
                }
            }

            bool success;
            if (m_IsFrom)
            {
                m_Coordinates[0] = new Point(row, col);
                m_IsFrom = false;
            }
            else
            {
                m_Coordinates[1] = new Point(row, col);
                if (m_Coordinates[0] != m_Coordinates[1])
                {
                    success = m_Board.MovePiece(m_Coordinates[0].X, m_Coordinates[0].Y, m_Coordinates[1].X, m_Coordinates[1].Y);
                    if (!success)
                    {
                        invalidMoveMessage();
                    }

                    updateTurn();
                    DrawBoard();
                    CheckForWin();
                }

                if (m_Board.m_turn == eColor.WhiteO && r_Players[1].m_Name == "Computer")
                {
                    while (m_Board.m_turn == eColor.WhiteO)
                    {
                        int[,] aiCoords = MiniMax.GetMoveFromAI(m_Board, 7);
                        success = m_Board.MovePiece(aiCoords[0, 0], aiCoords[0, 1], aiCoords[1, 0], aiCoords[1, 1]);
                        m_PictureBox[aiCoords[0, 0], aiCoords[0, 1]].Paint -= new PaintEventHandler(highlightBox);
                        m_PictureBox[aiCoords[0, 0], aiCoords[0, 1]].Refresh();

                        Thread.Sleep(1500);
                        updateTurn();
                        DrawBoard();
                        CheckForWin();
                    }
                }

                m_IsFrom = true;
            }
        }

        private void updateTurn()
        {
            if (m_Board.m_turn == eColor.BlackX)
            {
                TurnLabel.Text = $"{r_Players[0].m_Name}'s turn";
            }
            else
            {
                TurnLabel.Text = $"{r_Players[1].m_Name}'s turn";
            }

            TurnLabel.Refresh();
        }

        private void CheckForWin()
        {
            if (m_Board.GameOn() == false)
            {
                if (m_Board.m_turn == eColor.Empty)
                {
                    makeTieMessage();
                }
                else
                {
                    if (m_Board.m_turn == eColor.BlackX)
                    {
                        int score = m_Board.m_NumberOfWhitePieces + (4 * m_Board.m_NumberOfWhiteKings) - m_Board.m_NumberOfBlackPieces - (4 * m_Board.m_NumberOfBlackKings);
                        r_Players[1].SetScore(score);
                        makeWinMessage(1);
                    }
                    else
                    {
                        int score = m_Board.m_NumberOfBlackPieces + (4 * m_Board.m_NumberOfBlackKings) - m_Board.m_NumberOfWhitePieces - (4 * m_Board.m_NumberOfWhiteKings);
                        r_Players[0].SetScore(score);
                        makeWinMessage(0);
                    }
                }

                updateScore();
            }
        }

        private void updateScore()
        {
            this.P1ScoreLabel.Text = r_Players[0].m_Score.ToString();
            this.P2ScoreLabel.Text = r_Players[1].m_Score.ToString();
            P1ScoreLabel.Refresh();
            P2ScoreLabel.Refresh();
        }

        private void invalidMoveMessage()
        {
            string message = "Invalid move!" + Environment.NewLine + "Please try again";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, string.Empty, buttons);
        }

        private void makeTieMessage()
        {
            string message = "It's a tie!" + Environment.NewLine + "Do you want to play again?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, string.Empty, buttons);
            if (result == DialogResult.Yes)
            {
                m_Board = new Board(m_BoardSize);
                m_Board.InitializeBoard();
                DrawBoard();
            }
            else
            {
                this.Close();
            }
        }

        private void makeWinMessage(int i_WinnerIndex)
        {
            string message = $"{r_Players[i_WinnerIndex].m_Name} won!" + Environment.NewLine
                                                                       + "Do you want to play again?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, string.Empty, buttons);

            if (result == DialogResult.Yes)
            {
                m_Board = new Board(m_BoardSize);
                m_Board.InitializeBoard();
                DrawBoard();
            }
            else
            {
                this.Close();
            }
        }

        private void DrawBoard()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_PictureBox[i, j].Paint -= new PaintEventHandler(highlightBox);

                    eColor checkerColor = m_Board.m_Board[i, j].m_Color;
                    ePieceType checkerType = m_Board.m_Board[i, j].m_Type;
                    if (checkerColor == eColor.BlackX)
                    {
                        if (checkerType == ePieceType.Normal)
                        {
                            m_PictureBox[i, j].Image = Properties.Resources.BC;
                        }
                        else
                        {
                            m_PictureBox[i, j].Image = Properties.Resources.BK;
                        }
                    }

                    if (checkerColor == eColor.WhiteO)
                    {
                        if (checkerType == ePieceType.Normal)
                        {
                            m_PictureBox[i, j].Image = Properties.Resources.WC;
                        }
                        else
                        {
                            m_PictureBox[i, j].Image = Properties.Resources.WK;
                        }
                    }

                    if (checkerColor == eColor.Empty)
                    {
                        m_PictureBox[i, j].Image = null;
                    }

                    m_PictureBox[i, j].Refresh();
                    m_PictureBox[i, j].Visible = true;
                    m_PictureBox[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void GamePanel_Paint(object i_Sender, PaintEventArgs i_E)
        {
        }
    }
}