﻿using System;
using board;
using chessGame;

namespace Chess
{
    class Screm
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8-i} ");
                for (int j = 0; j < board.Colums; j++)
                {
                    if(board.Piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i,j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

        public static ChessPosition ReadPositon()
        {
            string s = Console.ReadLine();
            char colum = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(colum, line);
        }
    }
}
