using System;
using board;
using chessGame;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos = new ChessPosition('a', 1);
            ChessPosition pos2 = new ChessPosition('c', 3);

            Console.WriteLine(pos);
            Console.WriteLine(pos2);
            Console.WriteLine();
            Console.WriteLine(pos.toPosition());
            Console.WriteLine(pos2.toPosition());

        }
    }
}
