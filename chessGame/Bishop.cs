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
    }
}
