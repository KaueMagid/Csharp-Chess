using board;

namespace chessGame
{
    class Pawn : Piece
    {
        public Pawn(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        
        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Colums];
            Position pos = new Position(0, 0);
            if (Color == Color.White)
            {
                int j = 1;

                if (MovesCount == 0)
                {
                    j = 2;
                }


                pos.changeValues(Position.Line - 1, Position.Colum);
                for (int i = 0; i < j; i++)
                {
                    if (Board.ValidPosition(pos) && Board.Piece(pos) == null)
                    {
                        mat[pos.Line, pos.Colum] = true;
                    }
                    else
                    {
                        break;
                    }
                    pos.Line = pos.Line - 1;
                }
                pos.changeValues(Position.Line - 1, Position.Colum - 1);
                if (Board.ValidPosition(pos) && CanMove(pos) && Board.Piece(pos) != null)
                {
                    mat[pos.Line, pos.Colum] = true;
                }
                pos.changeValues(Position.Line - 1, Position.Colum + 1);
                if (Board.ValidPosition(pos) && CanMove(pos) && Board.Piece(pos) != null)
                {
                    mat[pos.Line, pos.Colum] = true;
                }
            }
            else
            {
                int j = 1;

                if (MovesCount == 0)
                {
                    j = 2;
                }


                pos.changeValues(Position.Line + 1, Position.Colum);
                for (int i = 0; i < j; i++)
                {
                    if (Board.ValidPosition(pos) && Board.Piece(pos) == null)
                    {
                        mat[pos.Line, pos.Colum] = true;
                    }
                    else
                    {
                        break;
                    }
                    pos.Line = pos.Line + 1;
                }
                pos.changeValues(Position.Line + 1, Position.Colum - 1);
                if (Board.ValidPosition(pos) && CanMove(pos) && Board.Piece(pos) != null)
                {
                    mat[pos.Line, pos.Colum] = true;
                }
                pos.changeValues(Position.Line + 1, Position.Colum + 1);
                if (Board.ValidPosition(pos) && CanMove(pos) && Board.Piece(pos) != null)
                {
                    mat[pos.Line, pos.Colum] = true;
                }
            }
            return mat;
        }


    }
}
