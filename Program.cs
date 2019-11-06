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
                        Position origin = Screm.ReadPositon().toPosition();
                        Console.WriteLine();
                        math.ValidateOriginPosition(origin);

                        bool[,] validMove = math.ChessBoard.Piece(origin).ValidMoves();
                        Console.Clear();
                        Screm.printBoard(math.ChessBoard, validMove);

                        Console.Write("\nDestiny:");
                        Position destiny = Screm.ReadPositon().toPosition();
                        math.ValidateDestinyPosition(origin, destiny);

                        math.MakePlay(origin, destiny);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
