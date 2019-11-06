using System;
using board;
using chessGame;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMath math = new ChessMath();
                while (!math.Finish)
                {
                    try
                    {
                        Screm.printMath(math);
                        Console.Write("Origin:");
                        Position origin = Screm.ReadPositon().toPosition();
                        Console.WriteLine();
                        math.ValidateOriginPosition(origin);

                        bool[,] validMove = math.ChessBoard.Piece(origin).ValidMoves();
                        Screm.printMath(math, validMove);

                        Console.Write("\nDestiny:");
                        Position destiny = Screm.ReadPositon().toPosition();
                        math.ValidateDestinyPosition(origin, destiny);

                        math.MakePlay(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Screm.printMath(math);
                Console.WriteLine("\nCHECKMATE!");
                Console.WriteLine(math.PlayerColor + " Wins");

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
