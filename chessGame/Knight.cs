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
    }
}
