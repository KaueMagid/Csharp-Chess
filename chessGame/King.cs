using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace chessGame
{
    class King : Piece
    {
        public King(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "K";
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

            return mat;
        }
    }
}
