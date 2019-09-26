
namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesCount { get; protected set; }
        public Board Board { get; protected set; }


    }
}
