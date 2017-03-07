using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication66
{
    class Game3 : Game2
    {

        int LengthHistory;
     Dictionary<int, Points> HistoryMemory = new Dictionary<int, Points>();
      // List<Points> HistoryMemory = new List<Points>();
        public Game3(int[] point):base(point)
        {
        }

        public void History(int value)
        {
            LengthHistory++;
            HistoryMemory[LengthHistory] = GetLocation(value);
        }
        public void Undo(int amount)
        {
            if (LengthHistory > 0)
            {
            int i = LengthHistory;
            this.Move(this[HistoryMemory[i].x, HistoryMemory[i].y], this);
            --i;
            }
            else throw new Exception("Невозможно отменить");
        }

        public void Redo(int amount)
        {
            if (LengthHistory > 0)
            {
           int i = LengthHistory;
            this.Move(this[HistoryMemory[i].x, HistoryMemory[i].y], this);
            ++i;
            }
        }

    }
}


