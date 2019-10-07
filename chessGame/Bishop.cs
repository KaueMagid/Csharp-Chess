using board;

namespace chessGame
{
    class Bishop : Piece
    {
        public Bishop (Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Colums];
            Position pos = new Position(0, 0);

            //Up + Right
            pos.changeValues(Position.Line - 1, Position.Colum + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Colum = pos.Colum + 1;
            }

            //Up + Left
            pos.changeValues(Position.Line - 1, Position.Colum - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Colum = pos.Colum - 1;
            }

            //Down + Right
            pos.changeValues(Position.Line + 1, Position.Colum + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Colum = pos.Colum + 1;
            }

            //Down + Left
            pos.changeValues(Position.Line + 1, Position.Colum - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Colum = pos.Colum - 1;
            }
            return mat;

        }
    }
}
