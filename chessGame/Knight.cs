using board;

namespace chessGame
{
    class Knight : Piece
    {
        public Knight(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Colums];
            Position pos = new Position(0, 0);

            // L
            pos.changeValues(Position.Line + 2, Position.Colum + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            // _:
            pos.changeValues(Position.Line + 2, Position.Colum - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            // :-
            pos.changeValues(Position.Line - 2, Position.Colum + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            // -:
            pos.changeValues(Position.Line - 2, Position.Colum - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //--.
            pos.changeValues(Position.Line + 1, Position.Colum + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //--^
            pos.changeValues(Position.Line - 1, Position.Colum + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //.--
            pos.changeValues(Position.Line + 1, Position.Colum - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }
            //^--
            pos.changeValues(Position.Line - 1, Position.Colum - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
            }

            return mat;
        }
    }
}
