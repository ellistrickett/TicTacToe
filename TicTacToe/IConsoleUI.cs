﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IConsoleUI
    {
        void DisplayBoard();
        void Run(string[] args);
        (int, int) GetHumanMove();

    }
}
