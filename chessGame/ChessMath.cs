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

        private void Move(Position origin, Position destiny)
        {
            Piece p = ChessBoard.OutputPiece(origin);
            Piece capturePiece = ChessBoard.OutputPiece(destiny);
            ChessBoard.InputPiece(p, destiny);
            p.incrementMove();
        }

        public void MakePlay(Position origin, Position destiny)
        {
            Move(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (ChessBoard.Piece(pos) == null)
            {
                throw new BoardException("Don't exist piece in this position");
            }
            if(PlayerColor != ChessBoard.Piece(pos).Color)
            {
                throw new BoardException("it's not your turn");
            }
            if (!ChessBoard.Piece(pos).ExistValidMove())
            {
                throw new BoardException("This piece has no valid moves");
            }

        }
        public void ValidateDestinyPosition(Position origin , Position destiny)
        {
            if (!ChessBoard.Piece(origin).ValidateMove(destiny))
            {
                throw new BoardException("Invalid destiny position");
            }
        }
        private void ChangePlayer()
        {
            if (PlayerColor == Color.White)
            {
                PlayerColor = Color.Black;
            }
            else
            {
                PlayerColor = Color.White;
            }
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
            for (char i = 'a'; i <= 'h'; i++)
            {
                ChessBoard.InputPiece(new Pawn(ChessBoard, Color.White), new ChessPosition(i, 2).toPosition());
            }

            ChessBoard.InputPiece(new Tower(ChessBoard, Color.Black), new ChessPosition('a', 8).toPosition());
            ChessBoard.InputPiece(new Knight(ChessBoard, Color.Black), new ChessPosition('b', 8).toPosition());
            ChessBoard.InputPiece(new Bishop(ChessBoard, Color.Black), new ChessPosition('c', 8).toPosition());
            ChessBoard.InputPiece(new King(ChessBoard, Color.Black), new ChessPosition('d', 8).toPosition());
            ChessBoard.InputPiece(new Queen(ChessBoard, Color.Black), new ChessPosition('e', 8).toPosition());
            ChessBoard.InputPiece(new Bishop(ChessBoard, Color.Black), new ChessPosition('f', 8).toPosition());
            ChessBoard.InputPiece(new Knight(ChessBoard, Color.Black), new ChessPosition('g', 8).toPosition());
            ChessBoard.InputPiece(new Tower(ChessBoard, Color.Black), new ChessPosition('h', 8).toPosition());
            
            for (char i = 'a'; i <= 'h'; i++)
            {
                ChessBoard.InputPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition(i, 7).toPosition());
            }
        }
    }
}
