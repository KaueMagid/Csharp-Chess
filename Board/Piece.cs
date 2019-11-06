
namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesCount { get; protected set; }
        public Board Board { get; protected set; }


        public Piece(Board board, Color color )
        {
            Position = null;
            Color = color;
            MovesCount = 0;
            Board = board;
        }

        public void incrementMove()
        {
            MovesCount ++;
        }

        public bool ExistValidMove()
        {
            bool[,] mat = ValidMoves();
            for (int i = 0; i < Board.Colums; i++)
            {
                for (int j = 0; j < Board.Lines; j++)
                {
                    if (mat[j,i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidateMove(Position pos)
        {
            return ValidMoves()[pos.Line,pos.Colum];
        }

        public abstract bool[,] ValidMoves();

        protected bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }
    }
}
