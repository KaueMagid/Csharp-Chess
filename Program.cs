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
                    Console.Clear();
                    Screm.printBoard(math.ChessBoard);
                    Console.WriteLine($"\n\nTunr: {math.Turn}");
                    Console.WriteLine("\n"+ math.PlayerColor + "player is your turn");
                    Console.Write("Origin:");
                    ChessPosition origin = Screm.ReadPositon();
                    Console.Write("Destiny:");
                    ChessPosition destiny = Screm.ReadPositon();
                    math.Move(origin.toPosition(), destiny.toPosition());

                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
