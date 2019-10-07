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
                    Console.WriteLine("\n"+ math.PlayerColor + " player is your turn");
                    Console.Write("Origin:");
                    Position origin = Screm.ReadPositon().toPosition();

                    bool[,] validMove = math.ChessBoard.Piece(origin).ValidMoves();
                    Console.Clear();
                    Screm.printBoard(math.ChessBoard,validMove);

                    Console.Write("\nDestiny:");
                    Position destiny = Screm.ReadPositon().toPosition();
                    math.Move(origin, destiny);

                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
