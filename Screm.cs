using System;
using System.Collections.Generic;
using board;
using chessGame;

namespace Chess
{
    class Screm
    {
        public static void printMath(ChessMath math)
        {
            Console.Clear();
            printBoard(math.ChessBoard);
            printCapturedPieces(math);
            if (!math.Finish)
            {
                Console.WriteLine($"\n\nTunr: {math.Turn}");
                Console.WriteLine("\n" + math.PlayerColor + " player is your turn");
                if (math.Check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("\n WINS: " + math.PlayerColor);
            }

        }
        public static void printMath(ChessMath math,bool[,] validMoves)
        {
            Console.Clear();
            printBoard(math.ChessBoard,validMoves);
            printCapturedPieces(math);
            Console.WriteLine($"\n\nTunr: {math.Turn}");
            Console.WriteLine("\n" + math.PlayerColor + " player is your turn");
            if (math.Check)
            {
                Console.WriteLine("XEQUE!");
            }

        }
        public static void printCapturedPieces(ChessMath math)
        {
            Console.WriteLine("\nCaptured Pieces:");
            Console.Write("\nWhite:");
            printConjunto(math.CapturedPieces(Color.White));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nBlack:");
            printConjunto(math.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void printConjunto(HashSet<Piece> conjunto)
        {
            Console.Write("[");
            bool bcks = false;
            foreach (Piece item in conjunto)
            {
                Console.Write(item + " ");
                bcks = true;
            }
            if (bcks)
            {
                Console.Write("\b]");
            }
            else
            {
                Console.Write("]");
            }
            
        }
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Colums; j++)
                {
                    PrintPiece(board.Piece(i, j));


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
                    if (validMoves[i, j] == true)
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
            try
            {
                char colum = s[0];
                int line = int.Parse(s[1] + "");
                return new ChessPosition(colum, line);
            }
            catch { throw new BoardException("Invalid Move"); }
            
        }
    }
}
