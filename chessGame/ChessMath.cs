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
        public bool Check { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public ChessMath()
        {
            ChessBoard = new Board(8, 8);
            Turn = 1;
            PlayerColor = Color.White;
            Finish = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            InputPieces();
        }

        public void MakePlay(Position origin, Position destiny)
        {
            Piece p = Move(origin, destiny);
            if (InCheck(PlayerColor))
            {
                ReverseMove(origin, destiny, p);
                throw new BoardException("You can't move this piece, you in xeque");
            }
            if (InCheck(Adversary(PlayerColor)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckMate(Adversary(PlayerColor)))
            {
                Finish = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

        }
        public void ValidateOriginPosition(Position pos)
        {
            if (ChessBoard.Piece(pos) == null)
            {
                throw new BoardException("Don't exist piece in this position");
            }
            if (PlayerColor != ChessBoard.Piece(pos).Color)
            {
                throw new BoardException("it's not your turn");
            }
            if (!ChessBoard.Piece(pos).ExistValidMove())
            {
                throw new BoardException("This piece has no valid moves");
            }

        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!ChessBoard.Piece(origin).ValidateMove(destiny))
            {
                throw new BoardException("Invalid destiny position");
            }
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece item in Captured)
            {
                if (item.Color == color)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece item in Pieces)
            {
                if (item.Color == color)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }
        private bool InCheck(Color color)
        {
            Piece king = King(color);
            foreach (Piece item in PiecesInGame(Adversary(color)))
            {
                if (item.ValidMoves()[king.Position.Line, king.Position.Colum])
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckMate(Color color)
        {
            if (!InCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.ValidMoves();
                for (int i = 0; i < ChessBoard.Lines; i++)
                {
                    for (int j = 0; j < ChessBoard.Colums; j++)
                    {
                        if (mat[i, j])
                        {
                            Position destiny = new Position(i, j);
                            Position origin = x.Position;
                            Piece p = Move(origin, destiny);
                            bool checkTest = InCheck(color);
                            ReverseMove(origin, destiny, p);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private Piece King(Color color)
        {
            foreach (Piece item in PiecesInGame(color))
            {
                if (item is King)
                {
                    return item;
                }
            }
            throw new BoardException("Not King");
        }
        private Color Adversary(Color color)
        {
            if (color == Color.Black)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }
        private Piece Move(Position origin, Position destiny)
        {
            Piece p = ChessBoard.OutputPiece(origin);
            Piece capturedPiece = ChessBoard.OutputPiece(destiny);
            ChessBoard.InputPiece(p, destiny);
            p.incrementMove();
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }
        private void ReverseMove(Position origin, Position destiny, Piece piece)
        {
            Piece p = ChessBoard.OutputPiece(destiny);
            ChessBoard.InputPiece(p, origin);
            p.decrementMove();
            if (piece != null)
            {
                ChessBoard.InputPiece(piece, destiny);
                Captured.Remove(piece);
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
        private void InputChessPiece(Piece piece, char colum, int line)
        {
            ChessBoard.InputPiece(piece, new ChessPosition(colum, line).toPosition());
            Pieces.Add(piece);
        }
        private void InputPieces()
        {
            InputChessPiece(new Tower(ChessBoard, Color.White), 'a', 1);
            InputChessPiece(new Knight(ChessBoard, Color.White), 'b', 1);
            InputChessPiece(new Bishop(ChessBoard, Color.White), 'c', 1);
            InputChessPiece(new King(ChessBoard, Color.White), 'd', 1);
            InputChessPiece(new Queen(ChessBoard, Color.White), 'e', 1);
            InputChessPiece(new Bishop(ChessBoard, Color.White), 'f', 1);
            InputChessPiece(new Knight(ChessBoard, Color.White), 'g', 1);
            InputChessPiece(new Tower(ChessBoard, Color.White), 'h', 1);
            for (char i = 'a'; i <= 'h'; i++)
            {
                InputChessPiece(new Pawn(ChessBoard, Color.White), i, 2);
            }

            InputChessPiece(new Tower(ChessBoard, Color.Black), 'a', 8);
            InputChessPiece(new Knight(ChessBoard, Color.Black), 'b', 8);
            InputChessPiece(new Bishop(ChessBoard, Color.Black), 'c', 8);
            InputChessPiece(new King(ChessBoard, Color.Black), 'd', 8);
            InputChessPiece(new Queen(ChessBoard, Color.Black), 'e', 8);
            InputChessPiece(new Bishop(ChessBoard, Color.Black), 'f', 8);
            InputChessPiece(new Knight(ChessBoard, Color.Black), 'g', 8);
            InputChessPiece(new Tower(ChessBoard, Color.Black), 'h', 8);

            for (char i = 'a'; i <= 'h'; i++)
            {
                InputChessPiece(new Pawn(ChessBoard, Color.Black), i, 7);
            }
        }
    }
}
