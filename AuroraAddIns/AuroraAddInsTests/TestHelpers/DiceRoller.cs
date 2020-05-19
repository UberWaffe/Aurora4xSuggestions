using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.Tests.TestHelpers
{
    public class DiceRoller
    {
        private Random _theDice;

        public DiceRoller()
        {
            _theDice = new Random();
        }

        public double GetDouble(double min = 0.0, double max = 1.0)
        {
            var delta = max - min;
            return (_theDice.NextDouble() * delta) + min;
        }

        public int GetInt(int min = 0, int max = 1)
        {
            return _theDice.Next(min, max);
        }
    }
}
