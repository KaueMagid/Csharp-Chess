namespace board
{
    class Position
    {
        public int Line { get; set; }
        public int Colum { get; set; }

        public Position(int line, int colum)
        {
            Line = line;
            Colum = colum;
        }

        public override string ToString()
        {
            return Line + "," + Colum;
        }
    }
}
