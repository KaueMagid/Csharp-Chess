using board;

namespace chessGame
{
    class Tower : Piece
    {
        public Tower(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
