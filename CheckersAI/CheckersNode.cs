namespace CheckersAI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CheckersEngine;

    public class CheckersNode
    {
        internal int m_Value;
        internal Board m_State;
        internal int[,] m_Move;
        internal eColor e_Winner;

        internal bool m_IsRoot;

        public static List<CheckersNode> GetPossibleNodes(CheckersNode i_Node)
        {
            bool isSuccessor;
            List<CheckersNode> possibleNodes = new List<CheckersNode>();
            List<Tuple<int, int, int, int>> listOfAllMoves = i_Node.m_State.ReturnAllJumps();
            if (!listOfAllMoves.Any())
            {
                listOfAllMoves = i_Node.m_State.ReturnAllOneStepMoves();
            }

            foreach (var move in listOfAllMoves)
            {
                Board newState = new Board(i_Node.m_State.r_Size);
                newState.CopyBoard(i_Node.m_State);
                isSuccessor = newState.MovePiece(move.Item1, move.Item2, move.Item3, move.Item4);
                if (isSuccessor)
                {
                    CheckersNode newNode = new CheckersNode(newState, false);
                    newNode.m_Move = new int[2, 2] { { move.Item1, move.Item2 }, { move.Item3, move.Item4 } };
                    possibleNodes.Add(newNode);
                }
            }

            return possibleNodes;
        }

        public CheckersNode(Board i_State, bool i_Root)
        {
            m_State = new Board(i_State.r_Size);
            m_State.CopyBoard(i_State);
            m_IsRoot = i_Root;
            m_Move = null;
            m_Value = 0;
            if (!m_State.GameOn())
            {
                if (m_State.m_NumberOfBlackPieces + m_State.m_NumberOfBlackKings > m_State.m_NumberOfWhitePieces + m_State.m_NumberOfWhiteKings)
                {
                    e_Winner = eColor.BlackX;
                }
                else
                {
                    e_Winner = eColor.WhiteO;
                }
            }
            else
            {
                e_Winner = eColor.Empty;
            }
        }

        public int GetHeuristic()
        {
            if (e_Winner == eColor.BlackX)
            {
                return -1000;
            }
            else if(e_Winner == eColor.WhiteO)
            {
                return 1000;
            }
            else
            {
                if (m_State.m_turn == eColor.BlackX)
                {
                    return -1 * (m_State.m_NumberOfBlackPieces + (4 * m_State.m_NumberOfBlackKings) - m_State.m_NumberOfWhitePieces - (4 * m_State.m_NumberOfWhiteKings));
                }
                else
                {
                    return m_State.m_NumberOfWhitePieces + (4 * m_State.m_NumberOfWhiteKings) - m_State.m_NumberOfBlackPieces - (4 * m_State.m_NumberOfBlackKings);
                }
            }
        }
    }
}
