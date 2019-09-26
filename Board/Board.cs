
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

        public void InputPiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Colum] = p;
            p.Position = pos;
        }
    }
}
