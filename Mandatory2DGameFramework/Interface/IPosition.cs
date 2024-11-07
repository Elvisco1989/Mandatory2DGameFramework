using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.PossitionOnEath;

namespace Mandatory2DGameFramework.Interface
{
    public interface IPosition
    {
        public IPosition GetPosition(char input);

        public Position GetOutPut(char input);
    }
}
