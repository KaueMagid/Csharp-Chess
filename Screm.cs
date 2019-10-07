using System;
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
                    PrintPiece(board.Piece(i,j));
                    
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] validMoves)
        {
            ConsoleColor backgroundO = Console.BackgroundColor;
            ConsoleColor backgroundE = ConsoleColor.DarkBlue;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Colums; j++)
                {
                    if (validMoves[i,j] == true)
                    {
                        Console.BackgroundColor = backgroundE;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = backgroundO;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece != null)
            {
                if (piece.Color == Color.White)
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
            else
            {
                Console.Write("-");
            }
            Console.Write(" ");
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
