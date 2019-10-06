
namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Colums { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int colums)
        {
            Lines = lines;
            Colums = colums;
            Pieces = new Piece[lines, colums]; 
        }

        public Piece Piece(int line, int colum)
        {
            return Pieces[line, colum];
        }
        public Piece Piece(Position pos)
        {
            return Pieces[pos.Line, pos.Colum];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void InputPiece(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new BoardException("This position is occupied");
            }
            Pieces[pos.Line, pos.Colum] = p;
            p.Position = pos;
        }

        public Piece OutputPiece(Position pos)
        {
            if(Piece(pos) == null)
            {
                return null;
            }
            Piece aux = Piece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Colum] = null;
            return aux;
        }





        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines ||pos.Colum < 0 ||pos.Colum >= Colums)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid position");
            }
        }

    }
}
