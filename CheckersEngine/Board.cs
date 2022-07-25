namespace CheckersEngine
{
    using System;
    using System.Collections.Generic;
    public class Board
    {
        public ChekersPiece[,] m_Board
        {
            get;
            private set;
        }

        private Position m_ComboMove;

        public eColor m_turn { get; internal set; }

        public int m_NumberOfBlackPieces { get; private set; }

        public int m_NumberOfWhitePieces { get; private set; }

        public int m_NumberOfWhiteKings { get; private set; }

        public int m_NumberOfBlackKings { get; private set; }

        public readonly int r_Size;

        public Board(int i_Size)
        {
            r_Size = i_Size;
            m_NumberOfBlackPieces = m_NumberOfWhitePieces = ((i_Size / 2) - 1) * (i_Size / 2);
            m_NumberOfBlackKings = m_NumberOfWhiteKings = 0;
            m_Board = new ChekersPiece[r_Size, r_Size];
            m_turn = eColor.BlackX;
            m_ComboMove = null;
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    m_Board[i, j] = new ChekersPiece(eColor.Empty, (eRow)i, (eColumn)j);
                }
            }
        }

        public void InitializeBoard()
        {
            for (int row = 0; row < (r_Size / 2) - 1; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    if ((row % 2 == 0 && col % 2 == 0) || (row % 2 == 1 && col % 2 == 1))
                    {
                        m_Board[r_Size - row - 1, col].m_Color = eColor.BlackX;
                    }
                    else
                    {
                        m_Board[row, col].m_Color = eColor.WhiteO;
                    }
                }
            }
        }

        public void ClearBoard()
        {
            foreach (ChekersPiece cell in m_Board)
            {
                cell.Clear();
            }
        }

        private bool checkIfValidTurn(eColor i_PieceColor)
        {
            if (i_PieceColor == m_turn)
            {
                return true;
            }

            return false;
        }

        public bool MovePiece(int i_FromRow, int i_FromCol, int i_ToRow, int i_ToCol)
        {
            if (!isMoveValid(i_FromRow, i_FromCol, i_ToRow, i_ToCol))
            {
                return false;
            }

            eColor pieceColor = m_Board[i_FromRow, i_FromCol].m_Color;

            m_Board[i_ToRow, i_ToCol].m_Color = pieceColor;
            m_Board[i_ToRow, i_ToCol].m_Type = m_Board[i_FromRow, i_FromCol].m_Type;
            m_Board[i_FromRow, i_FromCol].Clear();

            if (pieceColor == eColor.BlackX && i_ToRow == 0 && m_Board[i_ToRow, i_ToCol].m_Type == ePieceType.Normal)
            {
                m_Board[i_ToRow, i_ToCol].m_Type = ePieceType.King;
                m_NumberOfBlackKings++;
                m_NumberOfBlackPieces--;
            }

            if (pieceColor == eColor.WhiteO && i_ToRow == r_Size - 1 && m_Board[i_ToRow, i_ToCol].m_Type == ePieceType.Normal)
            {
                m_Board[i_ToRow, i_ToCol].m_Type = ePieceType.King;
                m_NumberOfWhiteKings++;
                m_NumberOfWhitePieces--;
            }

            if (distance(i_FromRow, i_ToRow) == 2)
            {
                int overRow = Math.Abs((i_FromRow + i_ToRow) / 2);
                int overCol = Math.Abs((i_FromCol + i_ToCol) / 2);
                ePieceType overType = m_Board[overRow, overCol].m_Type;
                m_Board[overRow, overCol].Clear();
                if (pieceColor == eColor.BlackX)
                {
                    if (overType == ePieceType.Normal)
                    {
                        m_NumberOfWhitePieces--;
                    }
                    else
                    {
                        m_NumberOfWhiteKings--;
                    }
                }
                else
                {
                    if (overType == ePieceType.Normal)
                    {
                        m_NumberOfBlackPieces--;
                    }
                    else
                    {
                        m_NumberOfBlackKings--;
                    }
                }

                if (checkForJump(i_ToRow, i_ToCol) == false)
                {
                    if (m_turn == eColor.BlackX)
                    {
                        m_turn = eColor.WhiteO;
                    }
                    else
                    {
                        m_turn = eColor.BlackX;
                    }

                    m_ComboMove = null;
                }
                else
                {
                    m_ComboMove = new Position((eRow)i_ToRow, (eColumn)i_ToCol);
                }
            }
            else
            {
                if (m_turn == eColor.BlackX)
                {
                    m_turn = eColor.WhiteO;
                }
                else
                {
                    m_turn = eColor.BlackX;
                }

                m_ComboMove = null;
            }

            return true;
        }

        private bool moveInRange(int i_FromRow, int i_FromCol, int i_ToRow, int i_ToCol)
        {
            bool flag = true;
            if (i_FromCol < 0 || i_FromCol >= r_Size)
            {
                flag = false;
            }
            else if (i_ToCol < 0 || i_ToCol >= r_Size)
            {
                flag = false;
            }
            else if (i_ToRow < 0 || i_ToRow >= r_Size)
            {
                flag = false;
            }
            else if (i_FromRow < 0 || i_FromRow >= r_Size)
            {
                flag = false;
            }

            return flag;
        }

        private bool isMoveValid(int i_FromRow, int i_FromCol, int i_ToRow, int i_ToCol)
        {
            eColor pieceColor = m_Board[i_FromRow, i_FromCol].m_Color;
            bool isValid = true;
            bool kingFlag = isKing(i_FromRow, i_FromCol);
            bool diagonalFlag = isDiagonal(i_FromRow, i_FromCol, i_ToRow, i_ToCol);
            bool isForward = isMovingForward(i_FromRow, i_ToRow, pieceColor);
            int distance = this.distance(i_FromRow, i_ToRow);

            if (!checkIfValidTurn(pieceColor))
            {
                isValid = false;
            }
            else if (m_ComboMove != null && ((int)m_ComboMove.Row != i_FromRow || (int)m_ComboMove.Column != i_FromCol))
            {
                isValid = false;
            }
            else if (moveInRange(i_FromRow, i_FromCol, i_ToRow, i_ToCol) == false)
            {
                isValid = false;
            }
            else if (isCellEmpty(i_FromRow, i_FromCol))
            {
                isValid = false;
            }
            else if (!isCellEmpty(i_ToRow, i_ToCol))
            {
                isValid = false;
            }
            else if (!diagonalFlag)
            {
                isValid = false;
            }
            else if (distance > 2)
            {
                isValid = false;
            }
            else if (!kingFlag && !isForward)
            {
                isValid = false;
            }
            else
            {
                if (distance == 1)
                {
                    if (searchForAllJumps(pieceColor))
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else if (distance == 2)
                {
                    if (IsValidJump(i_FromRow, i_FromCol, i_ToRow, i_ToCol))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        private bool isCellEmpty(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col].m_Color == eColor.Empty;
        }

        private bool isKing(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col].m_Type == ePieceType.King;
        }

        private bool isDiagonal(int i_FromRow, int i_FromCol, int i_ToRow, int i_ToCol)
        {
            int deltaRow = Math.Abs(i_FromRow - i_ToRow);
            int deltaColumn = Math.Abs(i_FromCol - i_ToCol);

            return deltaRow == deltaColumn;
        }

        private int distance(int i_FromRow, int i_ToRow)
        {
            return Math.Abs(i_FromRow - i_ToRow);
        }

        private bool isMovingForward(int i_FromRow, int i_ToRow, eColor i_Color)
        {
            bool movingForward = false;

            if (i_Color == eColor.WhiteO)
            {
                if (i_FromRow < i_ToRow)
                {
                    movingForward = true;
                }
            }
            else
            {
                if (i_FromRow > i_ToRow)
                {
                    movingForward = true;
                }
            }

            return movingForward;
        }

        internal bool IsValidJump(int i_FromRow, int i_FromCol, int i_ToRow, int i_ToCol)
        {
            if (!moveInRange(i_FromRow, i_FromCol, i_ToRow, i_ToCol))
            {
                return false;
            }

            bool isValidJump = false;
            eColor pieceColor = m_Board[i_FromRow, i_FromCol].m_Color;
            int overRow = Math.Abs((i_FromRow + i_ToRow) / 2);
            int overCol = Math.Abs((i_FromCol + i_ToCol) / 2);
            bool kingFlag = isKing(i_FromRow, i_FromCol);
            eColor overPieceColor = m_Board[overRow, overCol].m_Color;
            if (distance(i_FromRow, i_ToRow) == 2 && isDiagonal(i_FromRow, i_FromCol, i_ToRow, i_ToCol))
            {
                if (overPieceColor != pieceColor && !isCellEmpty(overRow, overCol) && pieceColor != eColor.Empty && isCellEmpty(i_ToRow, i_ToCol))
                {
                    if (kingFlag)
                    {
                        isValidJump = true;
                    }
                    else if (isMovingForward(i_FromRow, i_ToRow, pieceColor))
                    {
                        isValidJump = true;
                    }
                }
            }

            return isValidJump;
        }

        private bool searchForAllJumps(eColor i_PlayerColor)
        {
            foreach (ChekersPiece cell in m_Board)
            {
                if (cell.m_Color == i_PlayerColor)
                {
                    if (checkForJump((int)cell.m_Position.Row, (int)cell.m_Position.Column))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Tuple<int, int, int, int>> ReturnAllJumps()
        {
            List<Tuple<int, int, int, int>> allJumps = new List<Tuple<int, int, int, int>>();
            foreach (ChekersPiece cell in m_Board)
            {
                if (cell.m_Color == m_turn)
                {
                    List<Tuple<int, int, int, int>> onePieceJumps = returnJumps((int)cell.m_Position.Row, (int)cell.m_Position.Column);
                    allJumps.AddRange(onePieceJumps);
                }
            }

            return allJumps;
        }

        private bool checkForJump(int i_FromRow, int i_FromCol)
        {
            eColor pieceColor = m_Board[i_FromRow, i_FromCol].m_Color;
            bool canJump = false;

            int diagonalRowIterator = i_FromRow - 2;
            int diagonalColIterator = i_FromCol - 2;

            if (diagonalRowIterator < 0)
            {
                diagonalRowIterator = i_FromRow + 2;
            }

            if (diagonalColIterator < 0)
            {
                diagonalColIterator = i_FromCol + 2;
            }

            for (int i = diagonalRowIterator; i <= i_FromRow + 2; i++)
            {
                if (i_FromRow - 1 <= i && i <= i_FromRow + 1)
                {
                    continue;
                }

                for (int j = diagonalColIterator; j <= i_FromCol + 2; j++)
                {
                    if (i_FromCol - 1 <= j && j <= i_FromCol + 1)
                    {
                        continue;
                    }

                    if (IsValidJump(i_FromRow, i_FromCol, i, j))
                    {
                        canJump = true;
                    }
                }
            }

            return canJump;
        }

        private List<Tuple<int, int, int, int>> returnJumps(int i_FromRow, int i_FromCol)
        {
            List<Tuple<int, int, int, int>> jumps = new List<Tuple<int, int, int, int>>();
            eColor pieceColor = m_Board[i_FromRow, i_FromCol].m_Color;

            int diagonalRowIterator = i_FromRow - 2;
            int diagonalColIterator = i_FromCol - 2;

            if (diagonalRowIterator < 0)
            {
                diagonalRowIterator = i_FromRow + 2;
            }

            if (diagonalColIterator < 0)
            {
                diagonalColIterator = i_FromCol + 2;
            }

            for (int i = diagonalRowIterator; i <= i_FromRow + 2; i++)
            {
                if (i_FromRow - 1 <= i && i <= i_FromRow + 1)
                {
                    continue;
                }

                for (int j = diagonalColIterator; j <= i_FromCol + 2; j++)
                {
                    if (i_FromCol - 1 <= j && j <= i_FromCol + 1)
                    {
                        continue;
                    }

                    if (IsValidJump(i_FromRow, i_FromCol, i, j))
                    {
                        Tuple<int, int, int, int> move = new Tuple<int, int, int, int>(
                            i_FromRow,
                            i_FromCol,
                            i,
                            j);
                        jumps.Add(move);
                    }
                }
            }

            return jumps;
        }

        private bool checkForOneStepMove(int i_FromRow, int i_FromColumn)
        {
            int diagonalRowIterator = i_FromRow - 1;
            int diagonalColIterator = i_FromColumn - 1;

            if (diagonalRowIterator < 0)
            {
                diagonalRowIterator = i_FromRow + 1;
            }

            if (diagonalColIterator < 0)
            {
                diagonalColIterator = i_FromColumn + 1;
            }

            for (int i = diagonalRowIterator; i <= i_FromRow + 1; i++)
            {
                for (int j = diagonalColIterator; j <= i_FromColumn + 1; j++)
                {
                    if (moveInRange(i_FromRow, i_FromColumn, i, j))
                    {
                        if (distance(i_FromRow, i) == 1 && isDiagonal(i_FromRow, i_FromColumn, i, j))
                        {
                            if (isCellEmpty(i, j))
                            {
                                if (isMovingForward(i_FromRow, i, m_turn) || isKing(i_FromRow, i_FromColumn))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public List<Tuple<int, int, int, int>> ReturnAllOneStepMoves()
        {
            List<Tuple<int, int, int, int>> AllMoves = new List<Tuple<int, int, int, int>>();
            foreach (var cell in m_Board)
            {
                if (cell.m_Color == m_turn)
                {
                    List<Tuple<int, int, int, int>> onePieceMoves = returnOneStepMoves(
                        (int)cell.m_Position.Row,
                        (int)cell.m_Position.Column);

                    AllMoves.AddRange(onePieceMoves);
                }
            }

            return AllMoves;
        }

        private List<Tuple<int, int, int, int>> returnOneStepMoves(int i_FromRow, int i_FromColumn)
        {
            List<Tuple<int, int, int, int>> moves = new List<Tuple<int, int, int, int>>();
            for (int i = i_FromRow - 1; i <= i_FromRow + 1; i++)
            {
                for (int j = i_FromColumn - 1; j <= i_FromColumn + 1; j++)
                {
                    if (moveInRange(i_FromRow, i_FromColumn, i, j))
                    {
                        if (distance(i_FromRow, i) == 1 && isDiagonal(i_FromRow, i_FromColumn, i, j))
                        {
                            if (isCellEmpty(i, j))
                            {
                                Tuple<int, int, int, int> move = new Tuple<int, int, int, int>(
                                    i_FromRow,
                                    i_FromColumn,
                                    i,
                                    j);
                                moves.Add(move);
                            }
                        }
                    }
                }
            }

            return moves;
        }

        public bool GameOn()
        {
            bool gameOn = false;

            foreach (ChekersPiece cell in m_Board)
            {
                if (cell.m_Color == m_turn)
                {
                    if (checkForJump((int)cell.m_Position.Row, (int)cell.m_Position.Column))
                    {
                        gameOn = true;
                    }

                    if (checkForOneStepMove((int)cell.m_Position.Row, (int)cell.m_Position.Column))
                    {
                        gameOn = true;
                    }
                }
            }

            return gameOn;
        }

        public void CopyBoard(Board i_OtherBoard)
        {
            this.m_NumberOfBlackPieces = i_OtherBoard.m_NumberOfBlackPieces;
            this.m_NumberOfWhitePieces = i_OtherBoard.m_NumberOfWhitePieces;
            this.m_turn = i_OtherBoard.m_turn;
            this.m_ComboMove = i_OtherBoard.m_ComboMove;

            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    m_Board[i, j].m_Color = i_OtherBoard.m_Board[i, j].m_Color;
                    m_Board[i, j].m_Type = i_OtherBoard.m_Board[i, j].m_Type;
                }
            }
        }

        public eColor GetPieceValue(int Row, int Column)
        {
            return m_Board[Row, Column].m_Color;
        }

    }
}
