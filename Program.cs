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
                Board tab = new Board(8, 8);
                tab.InputPiece(new King(tab, Color.Black), new Position(0, 0));
                tab.InputPiece(new Queen(tab, Color.Black), new Position(0, 1));
                tab.InputPiece(new Bishop(tab, Color.Black), new Position(0, 2));
                tab.InputPiece(new Knight(tab, Color.White), new Position(0, 3));
                tab.InputPiece(new Tower(tab, Color.Black), new Position(0, 4));
                tab.InputPiece(new Pawn(tab, Color.White), new Position(0, 5));
                Screm.printBoard(tab);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
