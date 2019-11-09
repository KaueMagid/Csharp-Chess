using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace chessGame
{
    class King : Piece
    {
        private ChessMath Math;
        public King(Board tab, Color color, ChessMath math) : base(tab, color)
        {
            Math = math;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool TowerforRock(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.MovesCount == 0 && p.Color == Color;
        }

        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Colums];
            Position pos = new Position(0, 0);

            //UP
            pos.changeValues(Position.Line - 1, Position.Colum);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //Down
            pos.changeValues(Position.Line + 1, Position.Colum);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //Left
            pos.changeValues(Position.Line, Position.Colum - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //Right
            pos.changeValues(Position.Line, Position.Colum + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //UP + Right
            pos.changeValues(Position.Line - 1, Position.Colum + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //UP + Left
            pos.changeValues(Position.Line - 1, Position.Colum - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //Down + Right
            pos.changeValues(Position.Line + 1, Position.Colum + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //Down + Left
            pos.changeValues(Position.Line + 1, Position.Colum - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //# Special Move #
            //Smal Rock
            if (MovesCount == 0 && !Math.Check)
            {
                bool aux = true;
                Position posT = new Position(Position.Line, Position.Colum + 3);
                for (int i = 1; i <= 2; i++)
                {
                    if (Board.Piece(Position.Line, Position.Colum + i) != null) { aux = false; }
                }
                if (TowerforRock(posT) && aux)
                {
                    pos.changeValues(Position.Line, Position.Colum + 2);
                    mat[pos.Line, pos.Colum] = true;
                }
            }
            //# Special Move #
            //Big Rock
            if (MovesCount == 0 && !Math.Check)
            {
                bool aux = true;
                Position posT = new Position(Position.Line, Position.Colum - 4);
                for (int i = 1; i <= 3; i++)
                {
                    if (Board.Piece(Position.Line, Position.Colum - i) != null) { aux = false; }
                }
                if (TowerforRock(posT) && aux)
                {
                    pos.changeValues(Position.Line, Position.Colum - 2);
                    mat[pos.Line, pos.Colum] = true;
                }
            }
            return mat;
        }
    }
}
