using Mandatory2DGameFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.ObserverDesigPattern
{
    public class DeathLogger : IObserver
    {
        public void OnCreatureDeath(ICreature creature)
        {
            Console.WriteLine("Creature died: " + creature.Name);
        }
    }
   
}
