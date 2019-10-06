using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace chessGame
{
    class ChessMath
    {
        public Board ChessBoard { get; private set; }
        public int Turn { get; private set; }
        public Color PlayerColor { get; private set; }
        public bool Finish { get; private set; }

        public ChessMath()
        {
            ChessBoard = new Board(8, 8);
            Turn = 1;
            PlayerColor = Color.White;
            Finish = false;
            InputPieces();
        }

        public void Move(Position origin, Position destini)
        {
            Piece p = ChessBoard.OutputPiece(origin);
            Piece capturePiece = ChessBoard.OutputPiece(destini);
            ChessBoard.InputPiece(p, destini);
            p.incrementMove();
        }

        private void InputPieces()
        {
            ChessBoard.InputPiece(new Tower(ChessBoard, Color.White), new ChessPosition('a', 1).toPosition());
            ChessBoard.InputPiece(new Knight(ChessBoard, Color.White), new ChessPosition('b', 1).toPosition());
            ChessBoard.InputPiece(new Bishop(ChessBoard, Color.White), new ChessPosition('c', 1).toPosition());
            ChessBoard.InputPiece(new King(ChessBoard, Color.White), new ChessPosition('d', 1).toPosition());
            ChessBoard.InputPiece(new Queen(ChessBoard, Color.White), new ChessPosition('e', 1).toPosition());
            ChessBoard.InputPiece(new Bishop(ChessBoard, Color.White), new ChessPosition('f', 1).toPosition());
            ChessBoard.InputPiece(new Knight(ChessBoard, Color.White), new ChessPosition('g', 1).toPosition());
            ChessBoard.InputPiece(new Tower(ChessBoard, Color.White), new ChessPosition('h', 1).toPosition());


            ChessBoard.InputPiece(new Tower(ChessBoard, Color.Black), new ChessPosition('a', 8).toPosition());
            ChessBoard.InputPiece(new Knight(ChessBoard, Color.Black), new ChessPosition('b', 8).toPosition());
            ChessBoard.InputPiece(new Bishop(ChessBoard, Color.Black), new ChessPosition('c', 8).toPosition());
            ChessBoard.InputPiece(new King(ChessBoard, Color.Black), new ChessPosition('d', 8).toPosition());
            ChessBoard.InputPiece(new Queen(ChessBoard, Color.Black), new ChessPosition('e', 8).toPosition());
            ChessBoard.InputPiece(new Bishop(ChessBoard, Color.Black), new ChessPosition('f', 8).toPosition());
            ChessBoard.InputPiece(new Knight(ChessBoard, Color.Black), new ChessPosition('g', 8).toPosition());
            ChessBoard.InputPiece(new Tower(ChessBoard, Color.Black), new ChessPosition('h', 8).toPosition());

        }
    }
}
