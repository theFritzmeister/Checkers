namespace CheckersAI
{
    using CheckersEngine;
    using System;
    using System.Collections.Generic;
    using System.Security.Policy;
    public class MiniMax
    {
        private static int[,] s_BestMove;

        private static int negaMaxSearch(CheckersNode i_Node, int i_depth, int i_alpha, int i_beta, int i_Color)
        {
            if (i_depth == 0 || i_Node.e_Winner != eColor.Empty)
            {
                return i_Color * i_Node.GetHeuristic();
            }

            List<CheckersNode> childNodes = CheckersNode.GetPossibleNodes(i_Node);

            int value = int.MinValue;


            foreach (CheckersNode child in childNodes)
            {
                if(child.m_State.m_turn == i_Node.m_State.m_turn)
                {
                    value = Math.Max(value, negaMaxSearch(child, i_depth - 1, i_alpha, i_beta, i_Color));
                }
                else
                {
                    value = Math.Max(value, -negaMaxSearch(child, i_depth - 1, -i_beta, -i_alpha, -i_Color));
                }
                child.m_Value = value;
                i_alpha = Math.Max(i_alpha, value);
                if (i_alpha >= i_beta)
                {
                    break;
                }
            }

            if (i_Node.m_IsRoot)
            {
                int maxValue = value;
                foreach (CheckersNode child in childNodes)
                {
                    if (value == child.m_Value)
                    {
                        s_BestMove = child.m_Move;
                        break;
                    }
                }
            }

            return value;
        }

        public static int[,] GetMoveFromAI(Board i_Board, int depth)
        {
            CheckersNode root = new CheckersNode(i_Board, true);
            int score = negaMaxSearch(root, depth, int.MinValue, int.MaxValue, 1);
            return s_BestMove;
        }
    }
}
