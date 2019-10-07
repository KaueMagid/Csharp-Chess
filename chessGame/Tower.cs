using board;

namespace chessGame
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Colums];
            Position pos = new Position(0, 0);

            //Up
            pos.changeValues(Position.Line - 1, Position.Colum);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //Down
            pos.changeValues(Position.Line + 1, Position.Colum);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //Right
            pos.changeValues(Position.Line, Position.Colum + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Colum = pos.Colum + 1;
            }
            //Left
            pos.changeValues(Position.Line, Position.Colum -1 );
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colum] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Colum = pos.Colum -1;
            }

            return mat;
        }
    }
}
