using board;

namespace chessGame
{
    class Queen : Piece
    {
        public Queen(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
