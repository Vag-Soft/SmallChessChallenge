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

        Move bestMove = new Move();
        AlphaBetaSearch(board, ref bestMove, -99999, 4, -99999, 99999, true, isWhite);
        return bestMove;
    }

    //Evaluation function that takes into account the pieces of each colour
    public int BoardEvaluation(Board board, bool isWhite)
    {
        int whiteEval = board.GetPieceList(PieceType.Pawn, true).Count * 10 + (board.GetPieceList(PieceType.Knight, true).Count + board.GetPieceList(PieceType.Bishop, true).Count) * 30 + board.GetPieceList(PieceType.Rook, true).Count * 50 + board.GetPieceList(PieceType.Queen, true).Count * 90;
        int blackEval = board.GetPieceList(PieceType.Pawn, false).Count * 10 + (board.GetPieceList(PieceType.Knight, false).Count + board.GetPieceList(PieceType.Bishop, false).Count) * 30 + board.GetPieceList(PieceType.Rook, false).Count * 50 + board.GetPieceList(PieceType.Queen, false).Count * 90;
        
        if(isWhite)
            return whiteEval - blackEval;
        
        return blackEval - whiteEval;
    }

    public int AlphaBetaSearch(Board board, ref Move bestMove, int maxValue, int depth, int a, int b, bool isMaxPlayer, bool isWhite)
    {
        if (depth == 0 || board.GetLegalMoves().Length == 0)
            return BoardEvaluation(board, isWhite);

        if (isMaxPlayer)
        {
            int value = -99999;
            foreach (Move move in board.GetLegalMoves())
            {
                //Console.WriteLine(move);
                board.MakeMove(move);
                int tempValue = AlphaBetaSearch(board, ref bestMove, maxValue, depth - 1, a, b, false, isWhite);
                value = Math.Max(value, tempValue);
                if (value > maxValue)
                {
                    bestMove = move;
                }
                board.UndoMove(move);
                a = Math.Max(a, value);
                if (a >= b)
                    break;
            }
            return value;
        }
        else
        {
            int value = +99999;
            foreach (Move move in board.GetLegalMoves())
            {
                board.MakeMove(move);
                int tempValue = AlphaBetaSearch(board, ref bestMove, maxValue, depth - 1, a, b, false, isWhite);
                //value = Math.Min(value, tempValue);
                //if (value < minValue)
                //{
                //    bestMove = move;
                //}
                value = Math.Min(value, AlphaBetaSearch(board, ref bestMove, maxValue, depth - 1, a, b, true, isWhite));
                board.UndoMove(move);
                a = Math.Min(a, value);
                if (a >= b)
                    break;
            }
            return value;
        }
    }
}