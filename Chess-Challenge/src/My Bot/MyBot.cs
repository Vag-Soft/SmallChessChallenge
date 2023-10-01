using ChessChallenge.API;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        bool isWhite = board.IsWhiteToMove;
        int initialDepth = 4;

        Move bestMove = board.GetLegalMoves()[0];
        AlphaBetaSearch(board, ref bestMove, initialDepth, initialDepth, -99999, 99999, true, isWhite);

        return bestMove;
    }


    //Minimax search function with alpha beta pruning
    public int AlphaBetaSearch(Board board, ref Move bestMove, int depth, int initialDepth, int a, int b, bool isMaxPlayer, bool isWhite)
    {
        if (depth == 0 || board.GetLegalMoves().Length == 0)
            return BoardEvaluation(board, isWhite);

        if (isMaxPlayer)
        {
            int value = -99999;
            foreach (Move move in board.GetLegalMoves())
            {
                if (!board.GameMoveHistory.Contains(move))
                {
                    board.MakeMove(move);
                    if (board.IsDraw())
                    {
                        board.UndoMove(move);
                        continue;
                    }

                    int childValue = AlphaBetaSearch(board, ref bestMove, depth - 1, initialDepth, a, b, false, isWhite);
                    if (childValue > value)
                    {
                        value = childValue;
                        if (initialDepth == depth)
                        {
                            bestMove = move;
                        }
                    }
                    board.UndoMove(move);
                    a = Math.Max(a, value);
                    if (a >= b)
                        break;
                }
            }
            return value;
        }
        else
        {
            int value = +99999;
            foreach (Move move in board.GetLegalMoves())
            {
                if (!board.GameMoveHistory.Contains(move))
                {
                    board.MakeMove(move);
                    if (board.IsDraw())
                    {
                        board.UndoMove(move);
                        continue;
                    }

                    int childValue = AlphaBetaSearch(board, ref bestMove, depth - 1, initialDepth, a, b, true, isWhite);
                    if (childValue < value)
                    {
                        value = childValue;
                        if (initialDepth == depth)
                        {
                            bestMove = move;
                        }
                    }
                    board.UndoMove(move);
                    a = Math.Min(a, value);
                    if (a >= b)
                        break;
                }
            }
            return value;
        }
    }
}