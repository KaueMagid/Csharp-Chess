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
    }
}
