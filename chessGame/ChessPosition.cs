using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace chessGame
{
    class ChessPosition
    {
        public char Colum { get; set; }
        public int Line { get; set; }

        public ChessPosition(char colum, int line)
        {
            Colum = colum;
            Line = line;
        }
        public Position toPosition()
        {
            return new Position(8 - Line, Colum - 'a');
        }
        public override string ToString()
        {
            return ""+ Colum + Line; 
        }
    }
}
