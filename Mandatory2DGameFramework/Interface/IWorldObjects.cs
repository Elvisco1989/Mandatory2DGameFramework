using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interface
{
    public interface IWorldObjects
    {
        WorldObject CreateWorldObject(string type, IWeapon weapon);
    }
}

