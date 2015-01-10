using System;
using System.Drawing;
using System.Windows.Forms;
using ReverseTicTacToeLogic;

namespace ReverseTicTacToeGui
{
    class TicTacToeCellButton : Button
    {
        public TicTacToeCellButton(Point i_Location)
        {
            r_CellLocation = i_Location;
        }

        public Point CellLocation
        {
            get { return r_CellLocation; }
        }

        private readonly Point r_CellLocation;

        public void SetSymbol(eSymbol i_Symbol)
        {
            Text = i_Symbol != eSymbol.Blank ? i_Symbol.ToString() : String.Empty;
        }
    }
}
