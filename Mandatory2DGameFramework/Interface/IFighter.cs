using Mandatory2DGameFramework.Positive;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interface
{
    public interface IFighter 
    {
        void AttackCreature(ICreature creature);
        //void RecieveHit(int hit);


        //public void Loot(WorldObject obj);


    }
}
