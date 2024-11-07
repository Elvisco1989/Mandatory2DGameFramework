using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interface;

namespace Mandatory2DGameFramework.PossitionOnEath
{
    public class GoSouth : IPosition
    {
        public Position GetOutPut(char input)
        {
            return Position.South;
        }

        public IPosition GetPosition(char input)
        {
            if(input == 'w')
            {
                return new GoNorth();
            }
            else if (input == 's')
            {
                return new GoEast();
            }
            else if (input == 'a')
            {
                return new GoWest();
            }
            else
            {
                return this;
            }
        }
    }
}
