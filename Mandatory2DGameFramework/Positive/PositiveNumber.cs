using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Positive
{
    public  class PositiveNumber
    {
        public int Number { get; private set; }

        public PositiveNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positive");
            }
            Number = number;
        }

       
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
