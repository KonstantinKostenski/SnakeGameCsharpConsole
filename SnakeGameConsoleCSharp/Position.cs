﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameConsoleCSharp
{
    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
