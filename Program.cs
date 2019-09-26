using System;
using board;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);
            Screm.printBoard(tab);
            
        }
    }
}
